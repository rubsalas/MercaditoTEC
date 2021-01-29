package com.example.mercaditotec.ui.MyProducts;

import android.content.Intent;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ListView;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.lifecycle.ViewModelProvider;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.Volley;
import com.example.mercaditotec.Constants;
import com.example.mercaditotec.Controllers.ProductsAdapter;
import com.example.mercaditotec.Entities.Producto;
import com.example.mercaditotec.R;
import com.example.mercaditotec.ui.Activities.MyProductActivity;
import com.example.mercaditotec.ui.Activities.PostProductForm.NameDescriptionForm;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;

public class MyProductsFragment extends Fragment {

    private MyProductsViewModel myProductsViewModel;
    private ListView listaMisProductos;
    private ProductsAdapter productsAdapter;

    public View onCreateView(@NonNull LayoutInflater inflater,
                             ViewGroup container, Bundle savedInstanceState) {

        myProductsViewModel =
                new ViewModelProvider(this).get(MyProductsViewModel.class);
        View v = inflater.inflate(R.layout.my_products_fragment, container, false);
        listaMisProductos = (ListView) v.findViewById(R.id.listViewProductos);
        SolicitarMisProductos();

        listaMisProductos.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                Producto producto = productsAdapter.getItem(position);
                Intent intent = new Intent (getContext(), MyProductActivity.class);

                intent.putExtra("id", producto.getId());
                startActivityForResult(intent, 0);
            }
        });

        v.findViewById(R.id.btnVenderProducto).setOnClickListener(v1 -> {
            Intent intent = new Intent (getContext(), NameDescriptionForm.class);
            startActivityForResult(intent, 0);
        });

        return v;
    }

    public void SolicitarMisProductos(){
            RequestQueue requestQueue = Volley.newRequestQueue(getContext());
            JsonArrayRequest jsonArrayRequest = new JsonArrayRequest(
                    Request.Method.GET,
                    Constants.getInstance().getURL()+"productosJ/Estudiante/"+Constants.getInstance().getId(),
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
            item = new Producto("",actual.getString("nombre"),
                    actual.getString("descripcion"), actual.getInt("idProducto"),
                    actual.getInt("precio"));
            lista.add(item);
        }
        productsAdapter = new ProductsAdapter(lista, getContext());
        listaMisProductos.setAdapter(productsAdapter);
    }

}