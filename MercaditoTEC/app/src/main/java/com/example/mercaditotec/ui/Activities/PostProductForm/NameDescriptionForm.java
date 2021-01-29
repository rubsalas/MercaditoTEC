package com.example.mercaditotec.ui.Activities.PostProductForm;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;

import com.example.mercaditotec.CategorieActivity;
import com.example.mercaditotec.R;
import com.example.mercaditotec.ui.Activities.MyProductActivity;

public class NameDescriptionForm extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_name_description_form);

        findViewById(R.id.btnContinuar).setOnClickListener(v -> {
            Intent intent = new Intent (getApplicationContext(), CategorieForm.class);
            startActivityForResult(intent, 0);
        });
    }
}