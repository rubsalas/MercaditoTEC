package com.example.mercaditotec.ui.Activities.BuyProduct;

import androidx.appcompat.app.AppCompatActivity;

import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.RatingBar;
import android.widget.TextView;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.Volley;
import com.example.mercaditotec.Constants;
import com.example.mercaditotec.Controllers.LoadingDialogController;
import com.example.mercaditotec.R;
import com.google.firebase.storage.FirebaseStorage;
import com.google.firebase.storage.StorageReference;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.File;
import java.io.IOException;

public class ProductViewActivity extends AppCompatActivity {

    private TextView nombre, precio, puntos, tvDesc, lugares, tvFormasPago, valorPuntoCanje;
    private RatingBar calificacion;
    private LinearLayout imagenes;
    private FirebaseStorage storage;
    private StorageReference storageReference;
    private int idProductoActual;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_product_view);

        imagenes = findViewById(R.id.ImagenesLayoutBuy);
        valorPuntoCanje = findViewById(R.id.TVpuntosCanje);
        nombre = findViewById(R.id.nombrePbuy);
        precio = findViewById(R.id.precioMiProductoBuy);
        puntos = findViewById(R.id.puntosBuy);
        calificacion = findViewById(R.id.starsBarBuy);
        lugares = findViewById(R.id.tvLugaresBuy);
        tvDesc = findViewById(R.id.tvDescBuy);
        tvFormasPago = findViewById(R.id.tvFormasPagoBuy);
        idProductoActual = getIntent().getExtras().getInt("id");
        setearInformacion();

        findViewById(R.id.btnComprar).setOnClickListener(v -> {

        });

    }

    private void setearInformacion() {
        SolicitarInfoProducto();
    }

    private void SolicitarInfoProducto() {
        
        RequestQueue queue = Volley.newRequestQueue(getApplicationContext());
        JsonObjectRequest getRequest = new JsonObjectRequest(Request.Method.GET,
                Constants.getInstance().getURL()+"productosJ/"+idProductoActual, null,
                (Response.Listener<JSONObject>) response -> {
                    ordenarInfoProducto(response);
                },
                (Response.ErrorListener) error -> Log.d("Error.Response", error.toString())
        );

        queue.add(getRequest);
        
    }

    private void ordenarInfoProducto(JSONObject info) {
        try {
            nombre.setText(info.getString("nombre"));
            puntos.setText("Al realizar la compra obtienes "+info.getString("puntosCanje")+" puntos de canje");
            precio.setText("₡ "+info.getInt("precio"));
            tvDesc.setText(info.getString("descripcion"));
            calificacion.setRating(Float.parseFloat(info.getDouble("calificacionPromedioVendedor")+""));
            String ubicacion = "";
            for(int i = 0; i < info.getJSONArray("ubicaciones").length(); i++){
                JSONObject actual = info.getJSONArray("ubicaciones").getJSONObject(i).getJSONObject("ubicacion");
                String ubi = "-"+actual.getString("provincia")+", "+ actual.getString("canton")+", "+
                        actual.getString("distrito")+": "+
                        info.getJSONArray("ubicaciones").getJSONObject(i).getString("descripcion")+"\n";
                ubicacion = ubicacion +ubi;
            }
            lugares.setText(ubicacion);

            String pagos = "";
            for(int i = 0; i < info.getJSONArray("metodosPago").length(); i++){
                JSONObject actual = info.getJSONArray("metodosPago").getJSONObject(i);
                String pago = "-"+actual.getString("nombre")+": "+actual.get("numeroCuenta")+"\n";
                pagos = pagos + pago;
            }
            tvFormasPago.setText(pagos);
            cargarImagenes(info.getJSONArray("imagenes"));

        } catch (JSONException e) {
            e.printStackTrace();
        }
    }

    private void cargarImagenes(JSONArray imag) {
        for(int i = 0; i < imag.length(); i++){
            try {
                String ruta = imag.getJSONObject(i).getString("imagen");
                storageReference = FirebaseStorage.getInstance().getReference().child(ruta);
                String[] partes = ruta.split("/");
                final File tempFile = File.createTempFile(partes[1], "jpeg");
                storageReference.getFile(tempFile).addOnSuccessListener(taskSnapshot -> {
                    Bitmap bitmap = BitmapFactory.decodeFile(tempFile.getAbsolutePath());
                    ColocarImagen(bitmap);


                }).addOnFailureListener(e -> {

                });
            } catch (IOException | JSONException e) {
                e.printStackTrace();
            }
        }
    }

    private void ColocarImagen(Bitmap bitmap) {
        LayoutInflater inflater = LayoutInflater.from(this);
        View v = inflater.inflate(R.layout.item_image, imagenes, false);
        ImageView image = v.findViewById(R.id.imagenP);
        image.getLayoutParams().width = 500; image.getLayoutParams().height = 500; image.setAdjustViewBounds(true);
        image.setImageBitmap(bitmap);
        imagenes.addView(v);
    }
}