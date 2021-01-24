package com.example.mercaditotec.ui.MyProducts;

import androidx.lifecycle.ViewModelProvider;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;

import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.Volley;
import com.example.mercaditotec.Constants;
import com.example.mercaditotec.GuideActivity;
import com.example.mercaditotec.MainActivity;
import com.example.mercaditotec.R;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

public class MyProductsFragment extends Fragment {

    private MyProductsViewModel mViewModel;

    public static MyProductsFragment newInstance() {
        return new MyProductsFragment();
    }

    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container,
                             @Nullable Bundle savedInstanceState) {
        View vista = inflater.inflate(R.layout.my_products_fragment, container, false);

        SolicitarMisProductos(vista.getContext());

        return vista;
    }

    @Override
    public void onActivityCreated(@Nullable Bundle savedInstanceState) {
        super.onActivityCreated(savedInstanceState);
        mViewModel = new ViewModelProvider(this).get(MyProductsViewModel.class);
        // TODO: Use the ViewModel
    }
    public void SolicitarMisProductos(Context context){
        // Initialize a new RequestQueue instance
        RequestQueue requestQueue = Volley.newRequestQueue(context);

        // Initialize a new JsonArrayRequest instance
        JsonArrayRequest jsonArrayRequest = new JsonArrayRequest(
                Request.Method.GET,
                Constants.getInstance().getURL()+"productosJ/Estudiante/9",
                null,
                new Response.Listener<JSONArray>() {
                    @Override
                    public void onResponse(JSONArray response) {
                        Log.d("Soy este we", response.toString());
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

}