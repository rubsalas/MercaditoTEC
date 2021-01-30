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
import com.example.mercaditotec.Entities.ProductForm;
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

        listaCategorias.setOnItemClickListener((parent, view, position, id) -> {
            Intent intent = new Intent (getApplicationContext(), ImagesForm.class);
            try {
                ProductForm.getInstance().setIdCategoria(ListaCategoriasObjeto.get(position).getInt("idCategoria"));
                ProductForm.getInstance().setPuntosCanje(ListaCategoriasObjeto.get(position).getInt("puntaje"));
            } catch (JSONException e) {
                e.printStackTrace();
            }
            startActivityForResult(intent, 0);
        });
        SolicitarCategorías();
    }

    public void SolicitarCategorías(){
        RequestQueue requestQueue = Volley.newRequestQueue(getApplicationContext());

        JsonArrayRequest jsonArrayRequest = new JsonArrayRequest(
                Request.Method.GET,
                Constants.getInstance().getURL()+"categorias",
                null,
                response -> {
                    try {
                        ordenarCategorias(response);
                    } catch (JSONException e) {
                        e.printStackTrace();
                    }
                },
                error -> {

                }
        );
        requestQueue.add(jsonArrayRequest);
    }

    public void ordenarCategorias(JSONArray categorias) throws JSONException {
        ListaCategoriasObjeto = new ArrayList<>();
        ListaCategoriasString = new ArrayList<>();
        for(int i = 0; i < categorias.length(); i ++){

            ListaCategoriasString.add(categorias.getJSONObject(i).getString("nombre"));
            ListaCategoriasObjeto.add(categorias.getJSONObject(i));

        }
        ArrayAdapter adaptador = new ArrayAdapter<>(getApplicationContext(),
                android.R.layout.simple_list_item_1, ListaCategoriasString);
        listaCategorias.setAdapter(adaptador);
    }
}