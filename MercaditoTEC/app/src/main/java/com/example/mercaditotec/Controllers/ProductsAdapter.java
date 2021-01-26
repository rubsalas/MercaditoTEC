package com.example.mercaditotec.Controllers;

import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;

import com.example.mercaditotec.Entities.Producto;
import com.example.mercaditotec.R;
import com.google.android.gms.tasks.OnFailureListener;
import com.google.android.gms.tasks.OnSuccessListener;
import com.google.firebase.storage.FileDownloadTask;
import com.google.firebase.storage.FirebaseStorage;
import com.google.firebase.storage.StorageReference;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;

public class ProductsAdapter extends BaseAdapter {
    private ArrayList<Producto> listaProductos;
    private Context context;
    private StorageReference mStorageRef;

    public ProductsAdapter(ArrayList<Producto> listaProductos, Context context) {
        this.listaProductos = listaProductos;
        this.context = context;
    }

    @Override
    public int getCount() {
        return listaProductos.size();
    }

    @Override
    public Producto getItem(int position) {
        return listaProductos.get(position);
    }

    @Override
    public long getItemId(int position) {
        return listaProductos.get(position).getId();
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        Producto producto = (Producto) getItem(position);
        mStorageRef = FirebaseStorage.getInstance().getReference().child("Productos/test.png");

        convertView = LayoutInflater.from(context).inflate(R.layout.item_lista_productos_servicios, null);
        ImageView imgProducto = (ImageView) convertView.findViewById(R.id.imgFoto);
        TextView tvTitulo =  (TextView) convertView.findViewById(R.id.tvTitulo);
        TextView tvPrecio =  (TextView) convertView.findViewById(R.id.tvPrecio);
        TextView tvDescripcion =  (TextView) convertView.findViewById(R.id.tvDescripcion);

        tvTitulo.setText(producto.getNombre());
        tvPrecio.setText("₡ "+producto.getPrecio()+"");
        tvDescripcion.setText(producto.getDescripcion());

        try {
            final File tempFile = File.createTempFile("test", "png");
            mStorageRef.getFile(tempFile).addOnSuccessListener(new OnSuccessListener<FileDownloadTask.TaskSnapshot>() {
                @Override
                public void onSuccess(FileDownloadTask.TaskSnapshot taskSnapshot) {
                    Bitmap bitmap = BitmapFactory.decodeFile(tempFile.getAbsolutePath());
                    imgProducto.setImageBitmap(bitmap);
                }
            }).addOnFailureListener(new OnFailureListener() {
                @Override
                public void onFailure(@NonNull Exception e) {

                }
            });
        } catch (IOException e) {
            e.printStackTrace();
        }

        return convertView;
    }
}
