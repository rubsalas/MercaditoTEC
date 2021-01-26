package com.example.mercaditotec.ui.Activities;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.util.Log;
import android.widget.Button;
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

public class MyProductActivity extends AppCompatActivity {
    private int idProductoActual;
    private TextView nombre, precio, puntos;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_my_product);
        idProductoActual = getIntent().getExtras().getInt("id");
        nombre = findViewById(R.id.nombreMiProducto);
        precio = findViewById(R.id.precioMiProducto);
        puntos = findViewById(R.id.puntosMiProducto);
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
        precio.setText(info.getInt("precio")+"");
        puntos.setText(info.getString("puntosCanje"));
    }
}