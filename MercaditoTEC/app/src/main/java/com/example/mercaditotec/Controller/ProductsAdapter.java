package com.example.mercaditotec.Controller;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import com.example.mercaditotec.Entities.Producto;
import com.example.mercaditotec.R;

import java.util.ArrayList;

public class ProductsAdapter extends BaseAdapter {
    private ArrayList<Producto> listaProductos;
    private Context context;

    public ProductsAdapter(ArrayList<Producto> listaProductos, Context context) {
        this.listaProductos = listaProductos;
        this.context = context;
    }

    @Override
    public int getCount() {
        return listaProductos.size();
    }

    @Override
    public Object getItem(int position) {
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
        TextView tvUbicacion =  (TextView) convertView.findViewById(R.id.tvUbicacion);

        imgProducto.setImageResource(R.drawable.ic_menu_camera);
        tvTitulo.setText(producto.getNombre());
        tvPrecio.setText(""+producto.getPrecio()+" ₡");
        tvUbicacion.setText(producto.getUbicacion());


        return convertView;
    }
}
