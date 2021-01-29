package com.example.mercaditotec.Entities;


import android.net.Uri;

import org.json.JSONArray;

import java.util.ArrayList;

public class ProductForm {
    private String nombre, descripcion;
    private int idVendedor, idCategoria;
    private float precio;
    private JSONArray metodosPago, ubicaciones;
    private ArrayList<Uri> imagenes;


    private static ProductForm instancia = null;

    public static ProductForm getInstance() {
        if (instancia == null)
            instancia = new ProductForm();

        return instancia;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public String getDescripcion() {
        return descripcion;
    }

    public void setDescripcion(String descripcion) {
        this.descripcion = descripcion;
    }

    public int getIdVendedor() {
        return idVendedor;
    }

    public void setIdVendedor(int idVendedor) {
        this.idVendedor = idVendedor;
    }

    public int getIdCategoria() {
        return idCategoria;
    }

    public void setIdCategoria(int idCategoria) {
        this.idCategoria = idCategoria;
    }

    public float getPrecio() {
        return precio;
    }

    public void setPrecio(float precio) {
        this.precio = precio;
    }

    public ArrayList<Uri> getImagenes() {
        return imagenes;
    }

    public void setImagenes(ArrayList<Uri> imagenes) {
        this.imagenes = imagenes;
    }
}