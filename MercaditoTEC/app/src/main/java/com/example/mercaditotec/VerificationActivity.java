package com.example.mercaditotec;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.widget.Button;

public class VerificationActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_verification);

        findViewById(R.id.btnVerificar).setOnClickListener(v -> {
            Intent intent = new Intent (v.getContext(), RegisterActivity.class);
            startActivityForResult(intent, 0);
        });
    }
}