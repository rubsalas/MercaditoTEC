package com.example.mercaditotec.ui.Activities.BuyProduct;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.Volley;
import com.example.mercaditotec.Constants;
import com.example.mercaditotec.MainActivity;
import com.example.mercaditotec.R;
import com.google.android.material.floatingactionbutton.FloatingActionButton;

import org.json.JSONException;
import org.json.JSONObject;

public class ChatActivity extends AppCompatActivity {
    private FloatingActionButton confirmar;
    private int idCompra;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_chat);
        idCompra = getIntent().getExtras().getInt("idCompra");
        confirmar = findViewById(R.id.btnConfirmarCompra);
        
        confirmar.setOnClickListener(v -> {
            ConfirmarCompra();
        });
    }

    private void ConfirmarCompra() {
        RequestQueue queue = Volley.newRequestQueue(getApplicationContext());
        JSONObject json = new JSONObject();
        try {
            json.put("idCompraProducto", idCompra);
            json.put("confirmacionComprador", true);
        } catch (JSONException e) {
            e.printStackTrace();
        }

        JsonObjectRequest getRequest = new JsonObjectRequest(Request.Method.PUT,
                Constants.getInstance().getURL()+"comprasProductoJ/Confirmacion", json,
                (Response.Listener<JSONObject>) response -> {
                    Intent intent = new Intent (getApplicationContext(), MainActivity.class);
                    startActivityForResult(intent, 0);
                },
                (Response.ErrorListener) error -> Log.d("Error.Response", error.toString())
        );

        queue.add(getRequest);


    }
}