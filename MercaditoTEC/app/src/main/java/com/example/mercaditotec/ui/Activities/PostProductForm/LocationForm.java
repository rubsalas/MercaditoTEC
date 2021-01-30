package com.example.mercaditotec.ui.Activities.PostProductForm;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.Volley;
import com.example.mercaditotec.Constants;
import com.example.mercaditotec.Entities.ProductForm;
import com.example.mercaditotec.R;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;

public class LocationForm extends AppCompatActivity {
    private Spinner provincias, cantones, distritos;
    private int distritoSeleccionado;
    private TextView ubiActuales;
    private EditText otrasSenas;
    private ArrayList<JSONObject> ListaProvinciasObjeto, ListaCantonesObjeto, ListaDistritosObjeto;
    private ArrayList<String> ListaProvinciasString, ListaCantonesString, ListaDistritosString;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_location_form);

        provincias = findViewById(R.id.provinciaCB);
        cantones = findViewById(R.id.cantonCB);
        distritos = findViewById(R.id.distritoCB);
        ubiActuales = findViewById(R.id.ubiActualesForm);
        otrasSenas = findViewById(R.id.otrasSenales);
        provincias.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parentView, View selectedItemView, int position, long id) {
                try {
                    SolicitarCantones(ListaProvinciasObjeto.get(position).getInt("idProvincia"));
                } catch (JSONException e) {
                    e.printStackTrace();
                }
            }

            @Override
            public void onNothingSelected(AdapterView<?> parentView) {
                // your code here
            }

        });

        cantones.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parentView, View selectedItemView, int position, long id) {
                try {
                    SolicitarDistritos(ListaCantonesObjeto.get(position).getInt("idCanton"));
                } catch (JSONException e) {
                    e.printStackTrace();
                }
            }

            @Override
            public void onNothingSelected(AdapterView<?> parentView) {
                // your code here
            }

        });

        distritos.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parentView, View selectedItemView, int position, long id) {
                try {
                    distritoSeleccionado = ListaDistritosObjeto.get(position).getInt("idUbicacion");
                } catch (JSONException e) {
                    e.printStackTrace();
                }
            }

            @Override
            public void onNothingSelected(AdapterView<?> parentView) {
                // your code here
            }

        });

        findViewById(R.id.btnConfirmarLocaciones).setOnClickListener(v -> {
            if(ProductForm.getInstance().getUbicaciones().size() != 0){
                Intent intent = new Intent (getApplicationContext(), PaymentMethodsForm.class);
                startActivityForResult(intent, 0);
            }else{

            }
        });

        findViewById(R.id.addUbicacion).setOnClickListener(v -> {
            Log.d("Distrito", distritos.getSelectedItemPosition()+"" );


            try {
                int idUbi = ListaDistritosObjeto.get(distritos.getSelectedItemPosition()).getInt("idUbicacion");
                ArrayList ubicaciones = ProductForm.getInstance().getUbicaciones();
                ArrayList ubicacionesPreview = ProductForm.getInstance().getUbicacionesPreviw();
                ArrayList otrasSenass = ProductForm.getInstance().getOtrasSenas();
                if(!Existe(idUbi, ubicaciones)){
                    String addUbi = "-"+ListaProvinciasObjeto.get(provincias.getSelectedItemPosition()).getString("nombre")+", "+
                            ListaCantonesObjeto.get(cantones.getSelectedItemPosition()).getString("nombre")+", "+
                            ListaDistritosObjeto.get(distritos.getSelectedItemPosition()).getString("distrito")+": "+
                            otrasSenas.getText().toString();
                    ubicacionesPreview.add(addUbi);
                    ubiActuales.setText(ubiActuales.getText()+"\n"+addUbi);
                    ubicaciones.add(idUbi);
                    otrasSenass.add(otrasSenas.getText());
                    ProductForm.getInstance().setOtrasSenas(otrasSenass);
                    ProductForm.getInstance().setUbicaciones(ubicaciones);
                    ProductForm.getInstance().setUbicacionesPreviw(ubicacionesPreview);
                }else{
                    Log.d("TAG", "Ya está la ubi");
                }

            } catch (JSONException e) {
                e.printStackTrace();
            }
        });

        SolicitarProvincias();
    }

    public boolean Existe(int idUbi, ArrayList<Integer> ubicaciones){
        for(int i = 0; i < ubicaciones.size(); i++){
            if(ubicaciones.get(i) == idUbi){
                return true;
            }
        }
        return false;
    }

    public void SolicitarProvincias(){
        RequestQueue requestQueue = Volley.newRequestQueue(getApplicationContext());

        JsonArrayRequest jsonArrayRequest = new JsonArrayRequest(
                Request.Method.GET,
                Constants.getInstance().getURL()+"provincias",
                null,
                response -> {
                    try {
                        ordenarProvincias(response);
                    } catch (JSONException e) {
                        e.printStackTrace();
                    }
                },
                error -> {

                }
        );
        requestQueue.add(jsonArrayRequest);
    }


    public void ordenarProvincias(JSONArray info) throws JSONException {
        ListaProvinciasObjeto = new ArrayList<>();
        ListaProvinciasString = new ArrayList<>();
        for(int i = 0; i < info.length(); i ++){

            ListaProvinciasString.add(info.getJSONObject(i).getString("nombre"));
            ListaProvinciasObjeto.add(info.getJSONObject(i));

        }
        ArrayAdapter adaptador = new ArrayAdapter<>(getApplicationContext(),
                android.R.layout.simple_list_item_1, ListaProvinciasString);
        provincias.setAdapter(adaptador);
    }
    public void SolicitarCantones(int idProv){
        RequestQueue requestQueue = Volley.newRequestQueue(getApplicationContext());

        JsonArrayRequest jsonArrayRequest = new JsonArrayRequest(
                Request.Method.GET,
                Constants.getInstance().getURL()+"cantones/Provincia/"+idProv,
                null,
                response -> {

                    try {
                        ordenarCantones(response);
                    } catch (JSONException e) {
                        e.printStackTrace();
                    }
                },
                error -> {

                }
        );
        requestQueue.add(jsonArrayRequest);
    }


    public void ordenarCantones(JSONArray info) throws JSONException {
        ListaCantonesObjeto = new ArrayList<>();
        ListaCantonesString = new ArrayList<>();
        for(int i = 0; i < info.length(); i ++){

            ListaCantonesString.add(info.getJSONObject(i).getString("nombre"));
            ListaCantonesObjeto.add(info.getJSONObject(i));

        }
        ArrayAdapter adaptador = new ArrayAdapter<>(getApplicationContext(),
                android.R.layout.simple_list_item_1, ListaCantonesString);
        cantones.setAdapter(adaptador);
    }

    public void SolicitarDistritos(int idCant){
        RequestQueue requestQueue = Volley.newRequestQueue(getApplicationContext());

        JsonArrayRequest jsonArrayRequest = new JsonArrayRequest(
                Request.Method.GET,
                Constants.getInstance().getURL()+"ubicaciones/Canton/"+idCant,
                null,
                response -> {
                    try {
                        ordenarDistritos(response);
                    } catch (JSONException e) {
                        e.printStackTrace();
                    }
                },
                error -> {

                }
        );
        requestQueue.add(jsonArrayRequest);
    }


    public void ordenarDistritos(JSONArray info) throws JSONException {
        ListaDistritosObjeto = new ArrayList<>();
        ListaDistritosString = new ArrayList<>();
        for(int i = 0; i < info.length(); i ++){

            ListaDistritosString.add(info.getJSONObject(i).getString("distrito"));
            ListaDistritosObjeto.add(info.getJSONObject(i));

        }
        ArrayAdapter adaptador = new ArrayAdapter<>(getApplicationContext(),
                android.R.layout.simple_list_item_1, ListaDistritosString);
        distritos.setAdapter(adaptador);
    }
}