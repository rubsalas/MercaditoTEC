package com.example.mercaditotec.Controller;

import android.app.Activity;
import android.app.AlertDialog;
import android.view.LayoutInflater;

import com.example.mercaditotec.R;

public class LoadingDialogController {
    private Activity activity;
    private AlertDialog dialog;

    public LoadingDialogController(Activity activity) {
        this.activity = activity;
    }

    public void iniciarAnimacion(){
        AlertDialog.Builder builder = new AlertDialog.Builder(activity);
        LayoutInflater inflater = activity.getLayoutInflater();
        builder.setView(inflater.inflate(R.layout.loading_dialog,null));
        builder.setCancelable(true);

        dialog = builder.create();
        dialog.show();
    }

    public  void dismissDialog(){
        dialog.dismiss();
    }
}
