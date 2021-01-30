package com.example.mercaditotec.ui.Activities.PostProductForm;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.widget.EditText;
import android.widget.Toast;

import com.example.mercaditotec.CategorieActivity;
import com.example.mercaditotec.Entities.ProductForm;
import com.example.mercaditotec.R;
import com.example.mercaditotec.VerificationActivity;
import com.example.mercaditotec.ui.Activities.MyProductActivity;

public class NameDescriptionForm extends AppCompatActivity {

    private EditText nombre, descripcion;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_name_description_form);
        nombre = findViewById(R.id.nombreProductoForm);
        descripcion = findViewById(R.id.descripcionProducto);
        ProductForm.getInstance().clearAll();


        findViewById(R.id.btnContinuar).setOnClickListener(v -> {
            if (ComprobarCampos()){
                ProductForm.getInstance().setNombre(nombre.getText().toString());
                ProductForm.getInstance().setDescripcion(descripcion.getText().toString());
                Intent intent = new Intent (v.getContext(), CategorieForm.class);
                startActivityForResult(intent, 0);
            }else{
                Toast toast=Toast.makeText(getApplicationContext(),"Complete los campos Solicitados",Toast.LENGTH_SHORT);
                toast.setMargin(50,50);
                toast.show();
            }
        });
    }

    private boolean ComprobarCampos() {
        if(nombre.getText().toString().equals("")){
            nombre.setError("Obligatorio");
            if(descripcion.getText().toString().equals("")){
                descripcion.setError("Obligatorio");
                return false;
            }
            return false;
        }
        return true;
    }
}