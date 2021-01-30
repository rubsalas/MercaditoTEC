package com.example.mercaditotec;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.Volley;

import org.json.JSONException;
import org.json.JSONObject;

public class GuideActivity extends AppCompatActivity {

    private String idActual;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_guide);

        idActual = Constants.getInstance().getId()+"";

        findViewById(R.id.BtnConfirmar).setOnClickListener(v -> {
            try {
                ConfirmarGuia(v.getContext(), idActual);
            } catch (JSONException e) {
                e.printStackTrace();
            }
        });

    }


    public void Omitir(Context context, String id){
        RequestQueue queue = Volley.newRequestQueue(context);

        // prepare the Request
        JsonObjectRequest getRequest = new JsonObjectRequest(Request.Method.GET, Constants.getInstance().getURL()+"/estudiantesJ/"+id, null,
                new Response.Listener<JSONObject>()
                {
                    @Override
                    public void onResponse(JSONObject response) {
                        // display response
                        Log.d("Response", response.toString());
                        try {
                                Intent intent = new Intent (context, MainActivity.class);
                                intent.putExtra("id", id);
                                intent.putExtra("correo", response.getString("correoInstitucional"));
                                intent.putExtra("nombreC", response.getString("nombre")
                                        +" "+response.getString("apellidos"));
                                startActivityForResult(intent, 0);
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

    public void ConfirmarGuia(Context context, String id) throws JSONException {
        RequestQueue queue = Volley.newRequestQueue(context);

        JSONObject confirmacion = new JSONObject();
        confirmacion.put("idEstudiante", Integer.parseInt(id));
        confirmacion.put("cliente", "App");


        // prepare the Request
        JsonObjectRequest getRequest = new JsonObjectRequest(Request.Method.PUT, Constants.getInstance().getURL()+"/estudiantesJ/Guia", confirmacion,
                new Response.Listener<JSONObject>()
                {
                    @Override
                    public void onResponse(JSONObject response) {
                        // display response
                        Log.d("Response", response.toString());
                        Omitir(context, idActual);
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
}