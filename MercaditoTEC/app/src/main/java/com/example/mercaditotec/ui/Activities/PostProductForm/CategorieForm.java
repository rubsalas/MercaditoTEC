package com.example.mercaditotec.ui.Activities.PostProductForm;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.Volley;
import com.example.mercaditotec.CategorieActivity;
import com.example.mercaditotec.Constants;
import com.example.mercaditotec.R;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;

public class CategorieForm extends AppCompatActivity {
    private ListView listaCategorias;
    private ArrayList<JSONObject> ListaCategoriasObjeto;
    private ArrayList<String> ListaCategoriasString;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R .layout.activity_categorie_form);

        listaCategorias = (ListView) findViewById(R.id.listCategoriasForm);
        listaCategorias.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                Intent intent = new Intent (getApplicationContext(), ImagesForm.class);
                startActivityForResult(intent, 0);
            }
        });
        SolicitarCategorías();

    }

    public void SolicitarCategorías(){
        // Initialize a new RequestQueue instance
        RequestQueue requestQueue = Volley.newRequestQueue(getApplicationContext());

        // Initialize a new JsonArrayRequest instance
        JsonArrayRequest jsonArrayRequest = new JsonArrayRequest(
                Request.Method.GET,
                Constants.getInstance().getURL()+"categorias",
                null,
                new Response.Listener<JSONArray>() {
                    @Override
                    public void onResponse(JSONArray response) {
                        try {
                            ordenarCategorias(response);
                        } catch (JSONException e) {
                            e.printStackTrace();
                        }
                    }
                },
                new Response.ErrorListener(){
                    @Override
                    public void onErrorResponse(VolleyError error){

                    }
                }
        );
        requestQueue.add(jsonArrayRequest);
    }

    public void ordenarCategorias(JSONArray categorias) throws JSONException {
        ListaCategoriasObjeto = new ArrayList<JSONObject>();
        ListaCategoriasString = new ArrayList<String>();
        for(int i = 0; i < categorias.length(); i ++){

            ListaCategoriasString.add(categorias.getJSONObject(i).getString("nombre"));
            ListaCategoriasObjeto.add(categorias.getJSONObject(i));

        }
        Log.d("TAG", ListaCategoriasString.toString());
        ArrayAdapter adaptador = new ArrayAdapter<String>(getApplicationContext(),
                android.R.layout.simple_list_item_1, ListaCategoriasString);
        listaCategorias.setAdapter(adaptador);
    }
}