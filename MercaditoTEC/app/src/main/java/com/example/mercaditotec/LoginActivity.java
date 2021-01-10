package com.example.mercaditotec;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.widget.Button;
import android.widget.EditText;

import Communication.HttpRequests;

public class LoginActivity extends AppCompatActivity {

    Button BtnIngresar, BtnRegistro;
    EditText correo, contrasena;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login_);

        correo = findViewById(R.id.Correo_Institucional);
        contrasena = findViewById(R.id.Password);

        BtnIngresar = findViewById(R.id.Ingresar);
        BtnIngresar.setOnClickListener(v -> {
            HttpRequests com = new HttpRequests();
            com.getTest(this);

            /*Intent intent = new Intent (v.getContext(), MainActivity.class);
            startActivityForResult(intent, 0);*/

        });

        BtnRegistro = findViewById(R.id.BtnRegistro);
        BtnRegistro.setOnClickListener(v -> {
            Intent intent = new Intent (v.getContext(), VerificationActivity.class);
            startActivityForResult(intent, 0);
        });
    }
}