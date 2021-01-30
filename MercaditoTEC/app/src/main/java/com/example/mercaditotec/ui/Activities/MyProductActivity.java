package com.example.mercaditotec.ui.Activities;

import androidx.appcompat.app.AppCompatActivity;

import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.RatingBar;
import android.widget.TextView;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.Volley;
import com.example.mercaditotec.Constants;
import com.example.mercaditotec.R;
import com.google.firebase.storage.FirebaseStorage;
import com.google.firebase.storage.StorageReference;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.File;
import java.io.IOException;
import java.util.concurrent.BlockingDeque;

public class MyProductActivity extends AppCompatActivity {
    private int idProductoActual;
    private TextView nombre, precio, puntos, tvDesc, lugares, tvFormasPago;
    private RatingBar calificacion;
    private StorageReference mStorageRef;
    private LinearLayout imagenes;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_my_product);
        idProductoActual = getIntent().getExtras().getInt("id");
        nombre = findViewById(R.id.nombreMiProducto);
        imagenes = findViewById(R.id.ImagenesLayoutMyProduct);
        precio = findViewById(R.id.precioMiProducto);
        puntos = findViewById(R.id.puntosMiProducto);
        calificacion = findViewById(R.id.starsBar);
        lugares = findViewById(R.id.tvLugares);
        tvDesc = findViewById(R.id.tvDesc);
        tvFormasPago = findViewById(R.id.tvFormasPago);
        SolicitarProducto();
    }

    public void SolicitarProducto(){
        RequestQueue queue = Volley.newRequestQueue(getApplicationContext());

        JsonObjectRequest getRequest = new JsonObjectRequest(Request.Method.GET,
                Constants.getInstance().getURL()+"productosJ/"+idProductoActual,
                null,
                new Response.Listener<JSONObject>()
                {
                    @Override
                    public void onResponse(JSONObject response) {
                        // display response
                        Log.d("Response", response.toString());
                        try {
                            setearInfo(response);
                        } catch (JSONException e) {
                            e.printStackTrace();
                        }
                    }
                },
                new Response.ErrorListener()
                {
                    @Override
                    public void onErrorResponse(VolleyError error) {
                        Log.d("Error.Response", error.toString());
                    }
                }
        );

// add it to the RequestQueue

        queue.add(getRequest);
    }

    private void setearInfo(JSONObject info) throws JSONException {
        nombre.setText(info.getString("nombre"));
        precio.setText("₡ "+info.getInt("precio"));
        puntos.setText(info.getString("puntosCanje")+" puntos de Canje");
        tvDesc.setText(info.getString("descripcion"));
        double cal = info.getDouble("calificacionPromedioVendedor");
        calificacion.setRating((float) cal);
        lugares.setText(lugaresEntrega(info.getJSONArray("ubicaciones")));
        tvFormasPago.setText(metodosPago(info.getJSONArray("metodosPago")));
        ColocarImagenes(info.getJSONArray("imagenes"));
    }

    public String lugaresEntrega(JSONArray lugaresEntrega) throws JSONException {
        String ubicacionFinal = "";
        String actual;
        JSONObject ubicacionActual;
        for (int i = 0; i < lugaresEntrega.length(); i++){
            actual = "";
            ubicacionActual = lugaresEntrega.getJSONObject(i).getJSONObject("ubicacion");
            actual = ubicacionActual.getString("provincia") +", "+
                    ubicacionActual.getString("canton") +", "+
                    ubicacionActual.getString("distrito");
            if(i != lugaresEntrega.length() - 1){
                actual = actual+"\n";
            }
            ubicacionFinal = ubicacionFinal + actual;
        }
        return ubicacionFinal;
    }

    public String metodosPago(JSONArray metodos) throws JSONException {
        String pago = "";
        String actual = "";
        for(int i = 0; i < metodos.length(); i++){
            actual = metodos.getJSONObject(i).getString("nombre")+" a la cuenta "+ metodos.getJSONObject(i).getString("numeroCuenta");
            if(i != metodos.length() - 1){
                actual = actual+"\n";
            }
            pago = pago + actual;
        }

        return pago;
    }

    public void ColocarImagenes(JSONArray imagenes){

        for(int i = 0; i < imagenes.length(); i++){
            try {
                String ruta = imagenes.getJSONObject(i).getString("imagen");
                mStorageRef = FirebaseStorage.getInstance().getReference().child(ruta);
                String[] partes = ruta.split("/");
                final File tempFile = File.createTempFile(partes[1], "jpeg");
                mStorageRef.getFile(tempFile).addOnSuccessListener(taskSnapshot -> {
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
        image.setImageBitmap(bitmap);
        image.getLayoutParams().width = 500; image.getLayoutParams().height = 500; image.setAdjustViewBounds(true);
        imagenes.addView(v);
    }
}