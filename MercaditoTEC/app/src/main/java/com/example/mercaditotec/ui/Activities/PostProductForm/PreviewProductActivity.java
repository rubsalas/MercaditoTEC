package com.example.mercaditotec.ui.Activities.PostProductForm;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Context;
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
import com.example.mercaditotec.Entities.ProductForm;
import com.example.mercaditotec.R;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

public class PreviewProductActivity extends AppCompatActivity {

    private TextView nombre, precio, puntos, tvDesc, lugares, tvFormasPago;
    private RatingBar calificacion;
    private LinearLayout imagenes;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_preview_product);

        imagenes = findViewById(R.id.ImagenesLayoutPreview);
        nombre = findViewById(R.id.nombrePreview);
        precio = findViewById(R.id.precioMiProductoPreview);
        puntos = findViewById(R.id.puntosPreview);
        calificacion = findViewById(R.id.starsBarPreview);
        lugares = findViewById(R.id.tvLugaresPreview);
        tvDesc = findViewById(R.id.tvDescPreview);
        tvFormasPago = findViewById(R.id.tvFormasPagoPreview);
        setearInformacion();


        findViewById(R.id.btnPublicar).setOnClickListener(v -> {

        });

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