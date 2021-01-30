package com.example.mercaditotec.ui.Profile;

import androidx.lifecycle.ViewModelProvider;

import android.content.Context;
import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;

import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;
import android.widget.Toast;

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

public class ProfileFragment extends Fragment {
    private TextView nombre,email, telefono, puntos, calificacion;

    private ProfileViewModel mViewModel;

    public static ProfileFragment newInstance() {
        return new ProfileFragment();
    }

    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container,
                             @Nullable Bundle savedInstanceState) {
        
        View v = inflater.inflate(R.layout.profile_fragment, container, false);
        
        nombre = v.findViewById(R.id.nombrePerfil);
        email = v.findViewById(R.id.correoPerfil);
        telefono = v.findViewById(R.id.numeroPerfil);
        puntos = v.findViewById(R.id.puntosEstudiante);
        calificacion = v.findViewById(R.id.calificacionPerfil);
        
        SolicitarInfoPerfil();
        return v;
    }
    

    @Override
    public void onActivityCreated(@Nullable Bundle savedInstanceState) {
        super.onActivityCreated(savedInstanceState);
        mViewModel = new ViewModelProvider(this).get(ProfileViewModel.class);
        // TODO: Use the ViewModel
    }

    private void SolicitarInfoPerfil() {
        RequestQueue queue = Volley.newRequestQueue(getContext());

        JsonObjectRequest getRequest = new JsonObjectRequest(Request.Method.GET,
                Constants.getInstance().getURL()+"estudiantesJ/Perfil/"+Constants.getInstance().getId(),
                null,
                response -> {
                    Log.d("Response", response.toString());
                    try {
                        ColocarInfo(response);
                    } catch (JSONException e) {
                        e.printStackTrace();
                    }

                },
                error -> Log.d("Error.Response", error.toString())
        );

        queue.add(getRequest);
    }

    private void ColocarInfo(JSONObject info) throws JSONException {
        nombre.setText(info.getString("nombre")+" "+info.getString("apellidos"));
        email.setText(info.getString("correoInstitucional"));
        telefono.setText(info.getString("telefono"));
        puntos.setText(info.getString("puntosCanje"));
        calificacion.setText(info.getDouble("calificacionPromedioProductos")+"");

    }
}