package com.example.mercaditotec;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.widget.EditText;
import android.widget.Toast;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.Volley;
import com.example.mercaditotec.Controller.LoadingDialogController;

import org.json.JSONException;
import org.json.JSONObject;


public class LoginActivity extends AppCompatActivity {

    EditText correo, contrasena;
    private LoadingDialogController cargando;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login_);

        correo = findViewById(R.id.Correo_Institucional);
        contrasena = findViewById(R.id.Password);
        correo.setText("lack@estudiantec.cr");
        contrasena.setText("1234");

        cargando = new LoadingDialogController(LoginActivity.this);
        findViewById(R.id.Ingresar).setOnClickListener(v -> {
            cargando.iniciarAnimacion();
            try {
                LoginEstudiante(this, correo.getText().toString(), contrasena.getText().toString());
            } catch (JSONException e) {
                e.printStackTrace();
            }

        });

        findViewById(R.id.BtnRegistro).setOnClickListener(v -> {
            Intent intent = new Intent (v.getContext(), VerificationActivity.class);
            startActivityForResult(intent, 0);
        });
    }

    public void LoginEstudiante(Context context, String email, String contrasena) throws JSONException {
        RequestQueue queue = Volley.newRequestQueue(context);
        JSONObject credenciales = new JSONObject();
        credenciales.put("correoInstitucional", email);
        credenciales.put("contrasena", contrasena);


        JsonObjectRequest getRequest = new JsonObjectRequest(Request.Method.POST, Constants.getInstance().getURL()+"estudiantesJ/Login", credenciales,
                new Response.Listener<JSONObject>()
                {
                    @Override
                    public void onResponse(JSONObject response) {
                        // display response
                        Log.d("Response", response.toString());
                        try {
                            if(response.getInt("value") > 0){
                                ValidacionLogin(context, ""+response.getInt("value"));
                            }else if(response.getInt("value") == 0){
                                cargando.dismissDialog();
                                Context context = getApplicationContext();
                                CharSequence text = "Los credenciales son Incorrectos";
                                int duration = Toast.LENGTH_SHORT;

                                Toast toast = Toast.makeText(context, text, duration);
                                toast.show();
                            }else if(response.getInt("value") == -1){
                                Context context = getApplicationContext();
                                cargando.dismissDialog();
                                CharSequence text = "El correo no está registrado";
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

    public void ValidacionLogin(Context context, String id){
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
                            if(response.getBoolean("haIngresadoApp")){
                                Intent intent = new Intent (context, MainActivity.class);
                                intent.putExtra("id", response.getString("idEstudiante"));
                                intent.putExtra("correo", response.getString("correoInstitucional"));
                                intent.putExtra("nombreC", response.getString("nombre")
                                        +" "+response.getString("apellidos"));
                                Constants.getInstance().setId(Integer.parseInt(id));
                                startActivityForResult(intent, 0);
                            }else{
                                Intent intent = new Intent (context, GuideActivity.class);
                                intent.putExtra("id", response.getString("idEstudiante"));
                                startActivityForResult(intent, 0);
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