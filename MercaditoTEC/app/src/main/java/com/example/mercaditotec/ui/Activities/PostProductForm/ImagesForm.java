package com.example.mercaditotec.ui.Activities.PostProductForm;

import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;

import android.app.Activity;
import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.ImageView;
import android.widget.LinearLayout;

import com.example.mercaditotec.Entities.ProductForm;
import com.example.mercaditotec.R;
import com.google.firebase.storage.FirebaseStorage;
import com.google.firebase.storage.StorageReference;

import java.util.ArrayList;

public class ImagesForm extends AppCompatActivity {
    private ImageView foto;
    private ArrayList<Uri> imagesUris;
    private FirebaseStorage storage;
    private StorageReference storageReference;
    private LinearLayout imagenes;
    private static final int IMAGES_CODE = 0;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_images_form);

        storage = FirebaseStorage.getInstance();
        storageReference = storage.getReference();
        imagenes = findViewById(R.id.ImagenesLayout);

        findViewById(R.id.btnSelectFotos).setOnClickListener(v -> {
            elegirFotos();
        });
        findViewById(R.id.btnContinuarImages).setOnClickListener(v -> {
            Intent intent = new Intent (v.getContext(), LocationForm.class);
            ProductForm.getInstance().setImagenes(imagesUris);
            startActivityForResult(intent, 0);
        });
    }

    private void elegirFotos() {
        Intent intent = new Intent();
        intent.setType("image/*");
        intent.putExtra(Intent.EXTRA_ALLOW_MULTIPLE, true);
        intent.setAction(intent.ACTION_GET_CONTENT);
        startActivityForResult(Intent.createChooser(intent, "Seleccionar Foto(s)"), IMAGES_CODE);
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, @Nullable Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        imagesUris = new ArrayList<>();
        imagenes.removeAllViews();
        if(requestCode == IMAGES_CODE && resultCode==Activity.RESULT_OK && data != null && data.getData() != null){
            if(data.getClipData() != null){
                int count = data.getClipData().getItemCount();
                if(count >= 5){

                }else{
                    for(int i = 0; i < count; i++){
                        Uri imageUri = data.getClipData().getItemAt(i).getUri();
                        imagesUris.add(imageUri);
                    }
                }
            }else{
                Uri imageUri = data.getData();
                imagesUris.add(imageUri);
                colocarFotos();
            }
        }
    }

    private void colocarFotos() {

        LayoutInflater inflater = LayoutInflater.from(this);
        for(int i = 0; i < imagesUris.size(); i++){
            View v = inflater.inflate(R.layout.item_image, imagenes, false);
            ImageView image = v.findViewById(R.id.imagenP);
            image.setImageURI(imagesUris.get(i));
            imagenes.addView(v);
        }
    }

    /*private void subirFoto() {

        StorageReference imageRef = storageReference.child("Productos/");

        imageRef.putFile(imageUri).addOnSuccessListener(taskSnapshot -> {

        }).addOnFailureListener(e -> {

        });

    }*/
}