package com.example.mercaditotec.ui.Activities;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.util.Log;
import android.widget.Button;
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

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.concurrent.BlockingDeque;

public class MyProductActivity extends AppCompatActivity {
    private int idProductoActual;
    private TextView nombre, precio, puntos, tvDesc, lugares, tvFormasPago;
    private RatingBar calificacion;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_my_product);
        idProductoActual = getIntent().getExtras().getInt("id");
        nombre = findViewById(R.id.nombreMiProducto);
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
}