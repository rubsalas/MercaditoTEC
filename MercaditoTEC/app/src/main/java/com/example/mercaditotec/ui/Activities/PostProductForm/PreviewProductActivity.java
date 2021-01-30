package com.example.mercaditotec.ui.Activities.PostProductForm;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.RatingBar;
import android.widget.TextView;
import android.widget.Toast;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.Volley;
import com.example.mercaditotec.Constants;
import com.example.mercaditotec.Controllers.LoadingDialogController;
import com.example.mercaditotec.Entities.ProductForm;
import com.example.mercaditotec.LoginActivity;
import com.example.mercaditotec.MainActivity;
import com.example.mercaditotec.R;
import com.example.mercaditotec.ui.MyProducts.MyProductsFragment;
import com.google.firebase.storage.FirebaseStorage;
import com.google.firebase.storage.StorageReference;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

public class PreviewProductActivity extends AppCompatActivity {

    private TextView nombre, precio, puntos, tvDesc, lugares, tvFormasPago;
    private RatingBar calificacion;
    private LinearLayout imagenes;
    private FirebaseStorage storage;
    private LoadingDialogController cargando;
    private StorageReference storageReference;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_preview_product);

        storage = FirebaseStorage.getInstance();
        storageReference = storage.getReference();

        imagenes = findViewById(R.id.ImagenesLayoutPreview);
        nombre = findViewById(R.id.nombrePreview);
        precio = findViewById(R.id.precioMiProductoPreview);
        puntos = findViewById(R.id.puntosPreview);
        calificacion = findViewById(R.id.starsBarPreview);
        lugares = findViewById(R.id.tvLugaresPreview);
        tvDesc = findViewById(R.id.tvDescPreview);
        tvFormasPago = findViewById(R.id.tvFormasPagoPreview);
        setearInformacion();

        cargando = new LoadingDialogController(PreviewProductActivity.this);
        findViewById(R.id.btnPublicar).setOnClickListener(v -> {
            PublicarProducto();
            Toast.makeText(getApplicationContext(),"El producto se ha Publicado",Toast.LENGTH_SHORT).show();
            Intent intent = new Intent (getApplicationContext(),  MyProductsFragment.class);
            startActivityForResult(intent, 0);

        });

    }

    private void PublicarProducto() {

        JSONArray imagenesJSON = SubirImagenes();
        JSONObject producto = GenerarJson(imagenesJSON);
        PostProducto(producto);

    }

    private JSONArray SubirImagenes() {
        JSONArray JSON = new JSONArray();
        for (int i = 0; i < ProductForm.getInstance().getImagenes().size(); i++){
            String ref = "Productos/"+ProductForm.getInstance().getNombre()+i;
            StorageReference imageRef = storageReference.child(ref);
            JSONObject nuevo = new JSONObject();
            try {
                nuevo.put("imagen", ref);
                JSON.put(nuevo);
            } catch (JSONException e) {
                e.printStackTrace();
            }
            imageRef.putFile(ProductForm.getInstance().getImagenes().get(i)).addOnSuccessListener(taskSnapshot -> {

            }).addOnFailureListener(e -> {

            });

        }
        return JSON;
    }
    private JSONObject GenerarJson(JSONArray imag){
        JSONObject NewProduct = new JSONObject();
        ProductForm p = ProductForm.getInstance();
        Log.d("Soy estas imagenes", imag.toString());

        try {
            NewProduct.put("idVendedor", p.getIdVendedor());
            NewProduct.put("nombre", p.getNombre());
            NewProduct.put("descripcion", p.getDescripcion());
            NewProduct.put("idCategoria", p.getIdCategoria());
            NewProduct.put("precio", p.getPrecio());
            NewProduct.put("metodosPago", p.getMetodosPago());
            JSONArray ubicaciones = new JSONArray();
            for(int i = 0; i < p.getUbicaciones().size(); i++){
                JSONObject ubi = new JSONObject();
                ubi.put("idUbicacion", p.getUbicaciones().get(i));
                ubi.put("descripcion", p.getOtrasSenas().get(i));
                ubicaciones.put(ubi);
            }
            NewProduct.put("ubicaciones", ubicaciones);
            NewProduct.put("imagenes", imag);
        } catch (JSONException e) {
            e.printStackTrace();
        }

        return NewProduct;
    }
    private void PostProducto(JSONObject producto) {
        RequestQueue queue = Volley.newRequestQueue(getApplicationContext());
        JsonObjectRequest getRequest = new JsonObjectRequest(Request.Method.POST,
                Constants.getInstance().getURL()+"productosJ/", producto,
                (Response.Listener<JSONObject>) response -> {

                },
                (Response.ErrorListener) error -> Log.d("Error.Response", error.toString())
        );

        queue.add(getRequest);

    }

    private void setearInformacion() {
        ProductForm p = ProductForm.getInstance();
        nombre.setText(p.getNombre());
        precio.setText("₡"+p.getPrecio()+"");
        puntos.setText("Obtén "+p.getPuntosCanje()+" puntos de Canje");
        String ubiPre = "";
        for(int i =0; i < p.getUbicacionesPreviw().size(); i++){
            ubiPre = ubiPre + p.getUbicacionesPreviw().get(i);
            if(i < p.getUbicacionesPreviw().size()){
                ubiPre = ubiPre+"\n";
            }
        }
        lugares.setText(ubiPre);
        LayoutInflater inflater = LayoutInflater.from(this);
        for(int i = 0; i < p.getImagenes().size(); i++){
            View v = inflater.inflate(R.layout.item_image, imagenes, false);
            ImageView image = v.findViewById(R.id.imagenP);
            image.getLayoutParams().width = 500;
            image.getLayoutParams().height = 500;
            image.setAdjustViewBounds(true);
            image.setImageURI(p.getImagenes().get(i));
            imagenes.addView(v);
        }
        tvDesc.setText(p.getDescripcion());
        String pago = "";
        for(int i = 0; i < p.getMetodosPagoPreview().size() ;i++){
            pago = pago + p.getMetodosPagoPreview().get(i);
        }
        tvFormasPago.setText(pago);
        SolicitarInfoVendedor();

    }

    public void SolicitarInfoVendedor(){

        RequestQueue queue = Volley.newRequestQueue(getApplicationContext());
        JsonObjectRequest getRequest = new JsonObjectRequest(Request.Method.GET,
                Constants.getInstance().getURL()+"estudiantesJ/"+Constants.getInstance().getId(), null,
                (Response.Listener<JSONObject>) response -> {
                    ordenarInfoVendedor(response);
                },
                (Response.ErrorListener) error -> Log.d("Error.Response", error.toString())
        );

        queue.add(getRequest);
    }

    private void ordenarInfoVendedor(JSONObject info) {
        double cal = 0;
        int idVendedor = 0;
        try {
            cal = info.getDouble("calificacionPromedioProductos");
            idVendedor = info.getInt("idVendedor");
        } catch (JSONException e) {
            e.printStackTrace();
        }
        ProductForm.getInstance().setIdVendedor(idVendedor);
        calificacion.setRating((float) cal);
    }

}