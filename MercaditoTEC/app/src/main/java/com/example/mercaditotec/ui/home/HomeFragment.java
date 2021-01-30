package com.example.mercaditotec.ui.home;

import android.app.VoiceInteractor;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.LinearLayout;
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
import com.example.mercaditotec.CategorieActivity;
import com.example.mercaditotec.Constants;
import com.example.mercaditotec.MainActivity;
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
    private LinearLayout imagenes;

    public View onCreateView(@NonNull LayoutInflater inflater,
                             ViewGroup container, Bundle savedInstanceState) {

        homeViewModel =
                new ViewModelProvider(this).get(HomeViewModel.class);
        View root = inflater.inflate(R.layout.fragment_home, container, false);

        imagenes = root.findViewById(R.id.ImagenesLayoutHome);

        listaCategorias = (ListView) root.findViewById(R.id.listViewCategorias);
        listaCategorias.setOnItemClickListener((parent, view, position, id) -> {
            Intent intent = new Intent (getContext(), CategorieActivity.class);
            try {
                intent.putExtra("id",
                        ListaCategoriasObjeto.get(position).getInt("idCategoria"));
                intent.putExtra("nombre",
                        ListaCategoriasObjeto.get(position).getString("nombre"));
            } catch (JSONException e) {
                e.printStackTrace();
            }
            startActivityForResult(intent, 0);
        });
        SolicitarCategorías();
        cargarFotos();

        return root;
    }

    public void SolicitarCategorías(){
        RequestQueue requestQueue = Volley.newRequestQueue(getContext());

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
        Log.d("TAG", ListaCategoriasString.toString());
        ArrayAdapter adaptador = new ArrayAdapter<>(getContext(),
                android.R.layout.simple_list_item_1, ListaCategoriasString);
        listaCategorias.setAdapter(adaptador);
    }
    public void cargarFotos(){
        LayoutInflater inflater = LayoutInflater.from(getContext());
        View v = inflater.inflate(R.layout.item_image, imagenes, false);
        ImageView image = v.findViewById(R.id.imagenP);
        image.setImageResource(R.drawable.audifonos);
        image.getLayoutParams().width = 500; image.getLayoutParams().height = 500; image.setAdjustViewBounds(true);
        imagenes.addView(v);

        v = inflater.inflate(R.layout.item_image, imagenes, false);
        image = v.findViewById(R.id.imagenP);
        image.setImageResource(R.drawable.bicicleta);
        image.getLayoutParams().width = 500; image.getLayoutParams().height = 500; image.setAdjustViewBounds(true);
        imagenes.addView(v);

        v = inflater.inflate(R.layout.item_image, imagenes, false);
        image = v.findViewById(R.id.imagenP);
        image.setImageResource(R.drawable.bolso);
        image.getLayoutParams().width = 500; image.getLayoutParams().height = 500; image.setAdjustViewBounds(true);
        imagenes.addView(v);

        v = inflater.inflate(R.layout.item_image, imagenes, false);
        image = v.findViewById(R.id.imagenP);
        image.setImageResource(R.drawable.camara);
        image.getLayoutParams().width = 500; image.getLayoutParams().height = 500; image.setAdjustViewBounds(true);
        imagenes.addView(v);

        v = inflater.inflate(R.layout.item_image, imagenes, false);
        image = v.findViewById(R.id.imagenP);
        image.setImageResource(R.drawable.computadora);
        image.getLayoutParams().width = 500; image.getLayoutParams().height = 500; image.setAdjustViewBounds(true);
        imagenes.addView(v);

        v = inflater.inflate(R.layout.item_image, imagenes, false);
        image = v.findViewById(R.id.imagenP);
        image.setImageResource(R.drawable.disco);
        image.getLayoutParams().width = 500; image.getLayoutParams().height = 500; image.setAdjustViewBounds(true);
        imagenes.addView(v);

        v = inflater.inflate(R.layout.item_image, imagenes, false);
        image = v.findViewById(R.id.imagenP);
        image.setImageResource(R.drawable.gameboy);
        image.getLayoutParams().width = 500; image.getLayoutParams().height = 500; image.setAdjustViewBounds(true);
        imagenes.addView(v);

        v = inflater.inflate(R.layout.item_image, imagenes, false);
        image = v.findViewById(R.id.imagenP);
        image.setImageResource(R.drawable.guitarra);
        image.getLayoutParams().width = 500; image.getLayoutParams().height = 500; image.setAdjustViewBounds(true);
        imagenes.addView(v);

        v = inflater.inflate(R.layout.item_image, imagenes, false);
        image = v.findViewById(R.id.imagenP);
        image.setImageResource(R.drawable.hoodie);
        image.getLayoutParams().width = 500; image.getLayoutParams().height = 500; image.setAdjustViewBounds(true);
        imagenes.addView(v);

        v = inflater.inflate(R.layout.item_image, imagenes, false);
        image = v.findViewById(R.id.imagenP);
        image.setImageResource(R.drawable.lego);
        image.getLayoutParams().width = 500; image.getLayoutParams().height = 500; image.setAdjustViewBounds(true);
        imagenes.addView(v);

        v = inflater.inflate(R.layout.item_image, imagenes, false);
        image = v.findViewById(R.id.imagenP);
        image.setImageResource(R.drawable.lentes);
        image.getLayoutParams().width = 500; image.getLayoutParams().height = 500; image.setAdjustViewBounds(true);
        imagenes.addView(v);

        v = inflater.inflate(R.layout.item_image, imagenes, false);
        image = v.findViewById(R.id.imagenP);
        image.setImageResource(R.drawable.libro);
        image.getLayoutParams().width = 500; image.getLayoutParams().height = 500; image.setAdjustViewBounds(true);
        imagenes.addView(v);

        v = inflater.inflate(R.layout.item_image, imagenes, false);
        image = v.findViewById(R.id.imagenP);
        image.setImageResource(R.drawable.parlante);
        image.getLayoutParams().width = 500; image.getLayoutParams().height = 500; image.setAdjustViewBounds(true);
        imagenes.addView(v);

        v = inflater.inflate(R.layout.item_image, imagenes, false);
        image = v.findViewById(R.id.imagenP);
        image.setImageResource(R.drawable.raqueta);
        image.getLayoutParams().width = 500; image.getLayoutParams().height = 500; image.setAdjustViewBounds(true);
        imagenes.addView(v);

        v = inflater.inflate(R.layout.item_image, imagenes, false);
        image = v.findViewById(R.id.imagenP);
        image.setImageResource(R.drawable.reloj);
        image.getLayoutParams().width = 500; image.getLayoutParams().height = 500; image.setAdjustViewBounds(true);
        imagenes.addView(v);

        v = inflater.inflate(R.layout.item_image, imagenes, false);
        image = v.findViewById(R.id.imagenP);
        image.setImageResource(R.drawable.sillon);
        image.getLayoutParams().width = 500; image.getLayoutParams().height = 500; image.setAdjustViewBounds(true);
        imagenes.addView(v);

        v = inflater.inflate(R.layout.item_image, imagenes, false);
        image = v.findViewById(R.id.imagenP);
        image.setImageResource(R.drawable.sombrero);
        image.getLayoutParams().width = 500; image.getLayoutParams().height = 500; image.setAdjustViewBounds(true);
        imagenes.addView(v);

        v = inflater.inflate(R.layout.item_image, imagenes, false);
        image = v.findViewById(R.id.imagenP);
        image.setImageResource(R.drawable.telefono);
        image.getLayoutParams().width = 500; image.getLayoutParams().height = 500; image.setAdjustViewBounds(true);
        imagenes.addView(v);

        v = inflater.inflate(R.layout.item_image, imagenes, false);
        image = v.findViewById(R.id.imagenP);
        image.setImageResource(R.drawable.tenis);
        image.getLayoutParams().width = 500; image.getLayoutParams().height = 500; image.setAdjustViewBounds(true);
        imagenes.addView(v);


    }

}