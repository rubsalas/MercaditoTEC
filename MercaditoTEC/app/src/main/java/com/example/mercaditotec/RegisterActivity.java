package com.example.mercaditotec;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.Volley;

import org.json.JSONException;
import org.json.JSONObject;

public class RegisterActivity extends AppCompatActivity {
    EditText nombre, apellidos, telefono;
    TextView correoP;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_register);
        nombre = findViewById(R.id.nombreUsuario);
        apellidos = findViewById(R.id.apellidosUsuario);
        telefono = findViewById(R.id.telefonoUsuario);

        String correo = getIntent().getExtras().getString("correo");
        correoP = (TextView) findViewById(R.id.correoPantalla);
        correoP.setText(correo);

        findViewById(R.id.BtnCancelar).setOnClickListener(v -> {
            Intent intent = new Intent (v.getContext(), LoginActivity.class);
            startActivityForResult(intent, 0);
        });

        findViewById(R.id.BtnRegistrarse).setOnClickListener(v -> {
            try {
                RegistroEstudiante(v.getContext(), correo,
                        nombre.getText().toString(), apellidos.getText().toString(),
                        telefono.getText().toString());
            } catch (JSONException e) {
                e.printStackTrace();
            }
        });

    }

    public void RegistroEstudiante(Context context,String correo, String nombre, String apellidos, String telefono) throws JSONException {
        RequestQueue queue = Volley.newRequestQueue(context);
        JSONObject estudiante = new JSONObject();
        estudiante.put("nombre", nombre);
        estudiante.put("apellidos", apellidos);
        estudiante.put("telefono", telefono);
        estudiante.put("correoInstitucional", correo);

        // prepare the Request
        JsonObjectRequest getRequest = new JsonObjectRequest(Request.Method.POST,
                Constants.getInstance().getURL()+"/estudiantesJ/Registro", estudiante,
                new Response.Listener<JSONObject>()
                {
                    @Override
                    public void onResponse(JSONObject response) {
                        // display response
                        Log.d("Response", response.toString());
                        try {
                            if(response.getInt("value") > 0){
                                Context context = getApplicationContext();
                                CharSequence text = "Registro Completado!";
                                int duration = Toast.LENGTH_LONG;

                                Toast toast = Toast.makeText(context, text, duration);
                                toast.show();
                                Intent intent = new Intent (context, LoginActivity.class);
                                startActivityForResult(intent, 0);
                            }else{
                                Context context = getApplicationContext();
                                CharSequence text = "El registro no se pudo completar";
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
        queue.add(getRequest);
    }
}