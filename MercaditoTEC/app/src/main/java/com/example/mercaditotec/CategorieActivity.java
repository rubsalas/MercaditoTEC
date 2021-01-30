package com.example.mercaditotec;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.database.DataSetObserver;
import android.os.Bundle;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ListView;
import android.widget.Spinner;
import android.widget.SpinnerAdapter;
import android.widget.TextView;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.Volley;
import com.example.mercaditotec.Controllers.ProductsAdapter;
import com.example.mercaditotec.Entities.Producto;
import com.example.mercaditotec.ui.Activities.BuyProduct.ProductViewActivity;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.Collections;

public class CategorieActivity extends AppCompatActivity {
    private ListView listaProductos;
    private ArrayList<String> listaOrdenar;
    private int idCategoriaActual;
    private TextView nombreCategor;
    private ProductsAdapter productsAdapter;
    private Spinner CBordenar;
    private Button ordenar;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_categorie);
        idCategoriaActual = getIntent().getExtras().getInt("id");
        nombreCategor = findViewById(R.id.nombreCategoria);
        nombreCategor.setText(getIntent().getExtras().getString("nombre"));
        CBordenar = findViewById(R.id.CBordenar);
        listaOrdenar = new ArrayList<>();
        listaOrdenar.add("Precio: del más bajo al más alto");
        listaOrdenar.add("Precio: del más alto al más bajo");
        ArrayAdapter adaptador = new ArrayAdapter<>(getApplicationContext(),
                android.R.layout.simple_list_item_1, listaOrdenar);
        CBordenar.setAdapter(adaptador);

        listaProductos = (ListView) findViewById(R.id.lvProductosCategoria);
        listaProductos.setOnItemClickListener((parent, view, position, id) -> {
            Intent intent = new Intent (getApplicationContext(), ProductViewActivity.class);
            intent.putExtra("id", productsAdapter.getItem(position).getId());
            startActivityForResult(intent, 0);
        });
        ordenar = findViewById(R.id.btnFiltrar);
        ordenar.setOnClickListener(v -> {
            SolicitarProductosAscendentemente();
        });

        SolicitarProductos();
    }

    public void SolicitarProductosAscendentemente(){
        RequestQueue requestQueue = Volley.newRequestQueue(getApplicationContext());
        JsonArrayRequest jsonArrayRequest = new JsonArrayRequest(
                Request.Method.GET,
                Constants.getInstance().getURL()+"productosJ/Categoria/"+idCategoriaActual+"/Precio",
                null,
                response -> {
                    try {
                        GenerarListaProductosOrdenada(response);
                    } catch (JSONException e) {
                        e.printStackTrace();
                    }
                },
                error -> {

                }
        );
        requestQueue.add(jsonArrayRequest);
    }

    private void GenerarListaProductosOrdenada(JSONArray productos) throws JSONException {
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
        if(CBordenar.getSelectedItemPosition() == 0){
            productsAdapter = new ProductsAdapter(lista, getApplicationContext());
            listaProductos.setAdapter(productsAdapter);
        }else{
            Collections.reverse(lista);
            productsAdapter = new ProductsAdapter(lista, getApplicationContext());
            listaProductos.setAdapter(productsAdapter);
        }

    }

    public void SolicitarProductos(){
        RequestQueue requestQueue = Volley.newRequestQueue(getApplicationContext());
        JsonArrayRequest jsonArrayRequest = new JsonArrayRequest(
                Request.Method.GET,
                Constants.getInstance().getURL()+"productosJ/Categoria/"+idCategoriaActual,
                null,
                response -> {
                    try {
                        GenerarListaProductos(response);
                    } catch (JSONException e) {
                        e.printStackTrace();
                    }
                },
                error -> {

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
        productsAdapter = new ProductsAdapter(lista, getApplicationContext());
        listaProductos.setAdapter(productsAdapter);
    }
}