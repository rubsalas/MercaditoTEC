package com.example.mercaditotec;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.widget.ListView;
import android.widget.TextView;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.Volley;
import com.example.mercaditotec.Controllers.ProductsAdapter;
import com.example.mercaditotec.Entities.Producto;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;

public class CategorieActivity extends AppCompatActivity {
    private ListView listaProductos;
    private int idCategoriaActual;
    private TextView nombreCategor;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_categorie);
        idCategoriaActual = getIntent().getExtras().getInt("id");
        nombreCategor = findViewById(R.id.nombreCategoria);
        nombreCategor.setText(getIntent().getExtras().getString("nombre"));

        listaProductos = (ListView) findViewById(R.id.lvProductosCategoria);
        SolicitarProductos();
    }

    public void SolicitarProductos(){
        RequestQueue requestQueue = Volley.newRequestQueue(getApplicationContext());
        JsonArrayRequest jsonArrayRequest = new JsonArrayRequest(
                Request.Method.GET,
                Constants.getInstance().getURL()+"productosJ/Categoria/"+idCategoriaActual,
                null,
                new Response.Listener<JSONArray>() {
                    @Override
                    public void onResponse(JSONArray response) {
                        try {
                            GenerarListaProductos(response);
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

    private void GenerarListaProductos(JSONArray productos) throws JSONException {
        Producto item;
        JSONObject actual;
        ArrayList lista = new ArrayList<>();
        for(int i = 0; i < productos.length(); i++){
            actual = productos.getJSONObject(i);
            item = new Producto(actual.getJSONArray("imagenes"),actual.getString("nombre"),
                    actual.getString("descripcion"), actual.getInt("idProducto"),
                    actual.getInt("precio"));
            lista.add(item);
        }
        listaProductos.setAdapter(new ProductsAdapter(lista, getApplicationContext()));
    }
}