package com.example.mercaditotec.ui.home;

import android.app.VoiceInteractor;
import android.content.Context;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.TextView;

import androidx.annotation.Keep;
import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.lifecycle.Observer;
import androidx.lifecycle.ViewModelProvider;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.Volley;
import com.example.mercaditotec.Constants;
import com.example.mercaditotec.R;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;

public class HomeFragment extends Fragment {

    private HomeViewModel homeViewModel;
    private ListView listaCategorias;
    private ArrayList<JSONObject> ListaCategoriasObjeto;
    private ArrayList<String> ListaCategoriasString;

    public View onCreateView(@NonNull LayoutInflater inflater,
                             ViewGroup container, Bundle savedInstanceState) {

        homeViewModel =
                new ViewModelProvider(this).get(HomeViewModel.class);
        View root = inflater.inflate(R.layout.fragment_home, container, false);


        listaCategorias = (ListView) root.findViewById(R.id.listViewCategorias);
        listaCategorias.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
            }
        });
        SolicitarCategorías();

        return root;
    }

    public void SolicitarCategorías(){
        // Initialize a new RequestQueue instance
        RequestQueue requestQueue = Volley.newRequestQueue(getContext());

        // Initialize a new JsonArrayRequest instance
        JsonArrayRequest jsonArrayRequest = new JsonArrayRequest(
                Request.Method.GET,
                Constants.getInstance().getURL()+"categorias",
                null,
                new Response.Listener<JSONArray>() {
                    @Override
                    public void onResponse(JSONArray response) {
                        Log.d("TAG", response.toString());
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
        ArrayAdapter adaptador = new ArrayAdapter<String>(getContext(),
                android.R.layout.simple_list_item_1, ListaCategoriasString);
        listaCategorias.setAdapter(adaptador);
    }


}