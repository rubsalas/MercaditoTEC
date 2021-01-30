package com.example.mercaditotec.Controllers;

import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.util.Log;
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

import org.json.JSONException;

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

        convertView = LayoutInflater.from(context).inflate(R.layout.item_lista_productos_servicios, null);
        ImageView imgProducto = (ImageView) convertView.findViewById(R.id.imgFoto);
        TextView tvTitulo =  (TextView) convertView.findViewById(R.id.tvTitulo);
        TextView tvPrecio =  (TextView) convertView.findViewById(R.id.tvPrecio);
        TextView tvDescripcion =  (TextView) convertView.findViewById(R.id.tvDescripcion);

        tvTitulo.setText(producto.getNombre());
        tvPrecio.setText("₡ "+producto.getPrecio()+"");
        if(producto.getDescripcion().length() > 65){
            tvDescripcion.setText(producto.getDescripcion().substring(0, 65)+"...");
        }else{
            tvDescripcion.setText(producto.getDescripcion());
        }





        try {
            String ruta = producto.getImagen().getJSONObject(0).getString("imagen");
            mStorageRef = FirebaseStorage.getInstance().getReference().child(ruta);
            String[] partes = ruta.split("/");
            final File tempFile = File.createTempFile(partes[1], "jpeg");
            mStorageRef.getFile(tempFile).addOnSuccessListener(taskSnapshot -> {
                Bitmap bitmap = BitmapFactory.decodeFile(tempFile.getAbsolutePath());
                imgProducto.getLayoutParams().width = 250;
                imgProducto.getLayoutParams().height = 250;
                imgProducto.setAdjustViewBounds(true);
                imgProducto.setImageBitmap(bitmap);
            }).addOnFailureListener(e -> {

            });
        } catch (IOException | JSONException e) {
            e.printStackTrace();
        }




        return convertView;
    }
}
