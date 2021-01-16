package com.example.mercaditotec;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;

public class GuideActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_guide);

        findViewById(R.id.BtnConfirmar).setOnClickListener(v -> {
            ConfirmacionLogin();
        });

        findViewById(R.id.BtnOmitir).setOnClickListener(v -> {
            Intent intent = new Intent (v.getContext(), MainActivity.class);
            startActivityForResult(intent, 0);
        });
    }

    public void ConfirmacionLogin(){

    }
}