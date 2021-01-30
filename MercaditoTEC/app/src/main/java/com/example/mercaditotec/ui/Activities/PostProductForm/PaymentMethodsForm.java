package com.example.mercaditotec.ui.Activities.PostProductForm;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.TextView;

import com.example.mercaditotec.Entities.ProductForm;
import com.example.mercaditotec.R;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;

public class PaymentMethodsForm extends AppCompatActivity {
    private CheckBox efectivo, transferencia, sinpe;
    private TextView cuenta, numero, precio;
    private EditText etNumero, etCuenta;
    private int transF, sinpeF;
    private Boolean completo;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_payment_methods_form);
        transF = 0;
        sinpeF = 0;
        efectivo = findViewById(R.id.CBEfectivo);
        transferencia = findViewById(R.id.CBtransferencia);
        precio = findViewById(R.id.precioInput);
        sinpe = findViewById(R.id.CBSinpe);
        cuenta = findViewById(R.id.tvCuenta);
        numero = findViewById(R.id.tvNumero);
        etNumero = findViewById(R.id.EtSinpe);
        etCuenta = findViewById(R.id.ETCuenta);

        etCuenta.setVisibility(View.INVISIBLE);
        etNumero.setVisibility(View.INVISIBLE);
        numero.setVisibility(View.INVISIBLE);
        cuenta.setVisibility(View.INVISIBLE);

        transferencia.setOnClickListener(v -> {
            if(transF == 0){
                etCuenta.setVisibility(View.VISIBLE);
                cuenta.setVisibility(View.VISIBLE);
                transF = 1;
            }else{
                etCuenta.setVisibility(View.INVISIBLE);
                cuenta.setVisibility(View.INVISIBLE);
                transF = 0;
            }
        });

        sinpe.setOnClickListener(v -> {
            if(sinpeF == 0){
                etNumero.setVisibility(View.VISIBLE);
                numero.setVisibility(View.VISIBLE);
                sinpeF = 1;
            }else{
                etNumero.setVisibility(View.INVISIBLE);
                numero.setVisibility(View.INVISIBLE);
                sinpeF = 0;
            }
        });

        findViewById(R.id.btnContinuarPagos).setOnClickListener(v -> {
            ProductForm.getInstance().clearMetodosPago();
            ProductForm.getInstance().clearMetodosPreview();
            int count = 0;
            if(efectivo.isChecked()){
                count++;
                AgregarEfectivo();
            }
            if(transferencia.isChecked()){
                count++;
                AgregarTrasferencia();
            }
            if(sinpe.isChecked()){
                count++;
                AgregarSinpe();
            }
            if(ProductForm.getInstance().getMetodosPago().length() == count){
                if(precio.getText().length() != 0){
                    if(count != 0){
                        ProductForm.getInstance().setPrecio(precio.getText().toString());
                        Intent intent = new Intent (getApplicationContext(), PreviewProductActivity.class);
                        startActivityForResult(intent, 0);
                        Log.d("TAG", ProductForm.getInstance().getMetodosPagoPreview().toString());
                    }
                }else{
                    precio.setError("Obligatorio");
                }
            }
        });
    }

    private void AgregarEfectivo() {
        JSONArray jsonA = ProductForm.getInstance().getMetodosPago();
        JSONObject nuevo = new JSONObject();

        try {
            nuevo.put("idMetodoPago",  1);
            nuevo.put("numeroCuenta",  "");
        } catch (JSONException e) {
            e.printStackTrace();
        }
        ArrayList metodo = ProductForm.getInstance().getMetodosPagoPreview();
        metodo.add("-Efectivo\n");
        ProductForm.getInstance().setMetodosPagoPreview(metodo);
        jsonA.put(nuevo);
        ProductForm.getInstance().setMetodosPago(jsonA);
    }

    private void AgregarTrasferencia() {
        if(etCuenta.getText().length() != 0){
            JSONArray jsonA = ProductForm.getInstance().getMetodosPago();
            JSONObject nuevo = new JSONObject();
            try {
                nuevo.put("idMetodoPago",  2);
                nuevo.put("numeroCuenta",  etCuenta.getText());
            } catch (JSONException e) {
                e.printStackTrace();
            }
            jsonA.put(nuevo);
            ArrayList metodo = ProductForm.getInstance().getMetodosPagoPreview();
            metodo.add("-Transferencia Bancaria: "+etCuenta.getText()+"\n");
            ProductForm.getInstance().setMetodosPagoPreview(metodo);
            ProductForm.getInstance().setMetodosPago(jsonA);
        }else{
            etCuenta.setError("Obligatorio");
        }
    }

    private void AgregarSinpe() {
        if(etNumero.getText().length() != 0){
            JSONArray jsonA = ProductForm.getInstance().getMetodosPago();
            JSONObject nuevo = new JSONObject();
            try {
                nuevo.put("idMetodoPago",  3);
                nuevo.put("numeroCuenta",  etNumero.getText());
            } catch (JSONException e) {
                e.printStackTrace();
            }
            jsonA.put(nuevo);
            ArrayList metodo = ProductForm.getInstance().getMetodosPagoPreview();
            metodo.add("-SINPE Móvil: "+etNumero.getText()+"\n");
            ProductForm.getInstance().setMetodosPagoPreview(metodo);
            ProductForm.getInstance().setMetodosPago(jsonA);
        }else{
            etNumero.setError("Obligatorio");
        }
    }

}