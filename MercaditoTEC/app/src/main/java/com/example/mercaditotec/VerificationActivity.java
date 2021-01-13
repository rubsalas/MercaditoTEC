package com.example.mercaditotec;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.Volley;

import org.json.JSONException;
import org.json.JSONObject;

public class VerificationActivity extends AppCompatActivity {
    EditText email, contrasena;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_verification);

        email = findViewById(R.id.correo_verificacion);
        contrasena = findViewById(R.id.contrasena_verificacion);

        findViewById(R.id.btnVerificar).setOnClickListener(v -> {
            try {
                VerificarEstudiante(this, email.getText().toString(), contrasena.getText().toString());
            } catch (JSONException e) {
                e.printStackTrace();
            }
        });

        findViewById(R.id.btnCancelar).setOnClickListener(v -> {
            Intent intent = new Intent (v.getContext(), LoginActivity.class);
            startActivityForResult(intent, 0);
        });
    }

    public void VerificarEstudiante(Context context, String email, String contrasena) throws JSONException {
        RequestQueue queue = Volley.newRequestQueue(context);
        JSONObject credenciales = new JSONObject();
        credenciales.put("correoInstitucional", email);
        credenciales.put("contrasena", contrasena);

        // prepare the Request
        JsonObjectRequest getRequest = new JsonObjectRequest(Request.Method.POST, "https://mercaditotec.azurewebsites.net/api/datic", credenciales,
                new Response.Listener<JSONObject>()
                {
                    @Override
                    public void onResponse(JSONObject response) {
                        // display response
                        Log.d("Response", response.toString());
                        try {
                            if(response.getInt("value") == 2){
                                Context context = getApplicationContext();
                                CharSequence text = "Ya estás registrado en MercaditoTEC";
                                int duration = Toast.LENGTH_SHORT;

                                Toast toast = Toast.makeText(context, text, duration);
                                toast.show();
                            }else if(response.getInt("value") == 1){
                                Intent intent = new Intent (context, RegisterActivity.class);
                                intent.putExtra("correo", email);
                                startActivityForResult(intent, 0);
                            }else if(response.getInt("value") == 0){
                                Context context = getApplicationContext();
                                CharSequence text = "Credenciales Incorrectos";
                                int duration = Toast.LENGTH_SHORT;

                                Toast toast = Toast.makeText(context, text, duration);
                                toast.show();
                            }else if(response.getInt("value") == -1){
                                Context context = getApplicationContext();
                                CharSequence text = "El correo no pertenece a un Estudiante";
                                int duration = Toast.LENGTH_SHORT;

                                Toast toast = Toast.makeText(context, text, duration);
                                toast.show();
                            }
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
}