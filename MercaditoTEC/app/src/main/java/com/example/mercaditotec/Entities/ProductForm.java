package com.example.mercaditotec.Entities;


import android.net.Uri;

import org.json.JSONArray;

import java.util.ArrayList;

public class ProductForm {
    private String nombre, descripcion;
    private int idVendedor;
    private int idCategoria;

    private int puntosCanje;
    private float precio;
    private JSONArray metodosPago;
    private ArrayList<Uri> imagenes;
    private ArrayList<Integer> ubicaciones;
    private ArrayList<String> ubicacionesPreviw;
    private ArrayList<String> metodosPagoPreview;


    private static ProductForm instancia = null;
    ProductForm(){
        this.nombre = "";
        this.descripcion = "";
        this.idVendedor = 0;
        this.idCategoria = 0;
        this.precio = 0;
        this.metodosPago = new JSONArray();
        this.imagenes = new ArrayList<>();
        this.ubicaciones = new ArrayList<>();
        this.ubicacionesPreviw = new ArrayList<>();
    }
    public static ProductForm getInstance() {
        if (instancia == null)
            instancia = new ProductForm();

        return instancia;
    }

    public ArrayList<String> getUbicacionesPreviw() {
        return ubicacionesPreviw;
    }

    public void setUbicacionesPreviw(ArrayList<String> ubicacionesPreviw) {
        this.ubicacionesPreviw = ubicacionesPreviw;
    }

    public int getPuntosCanje() {
        return puntosCanje;
    }

    public void setPuntosCanje(int puntosCanje) {
        this.puntosCanje = puntosCanje;
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

    public void setPrecio(String precio) {
        this.precio = Float.parseFloat(precio);
    }

    public ArrayList<Uri> getImagenes() {
        return imagenes;
    }
    public void setImagenes(ArrayList<Uri> imagenes) {
        this.imagenes = imagenes;
    }

    public ArrayList<Integer> getUbicaciones() {
        return ubicaciones;
    }

    public void setUbicaciones(ArrayList<Integer> ubicaciones) {
        this.ubicaciones = ubicaciones;
    }

    public void clearAll() {
        this.nombre = "";
        this.descripcion = "";
        this.idVendedor = 0;
        this.idCategoria = 0;
        this.precio = 0;
        this.metodosPago = new JSONArray();
        this.imagenes = new ArrayList<>();
        this.ubicaciones = new ArrayList<>();
        this.ubicacionesPreviw = new ArrayList<>();
    }

    public JSONArray getMetodosPago() {
        return metodosPago;
    }

    public void setMetodosPago(JSONArray metodosPago) {
        this.metodosPago = metodosPago;
    }
    public void clearMetodosPago() {
        this.metodosPago = new JSONArray();
    }

    public ArrayList<String> getMetodosPagoPreview() {
        return metodosPagoPreview;
    }

    public void setMetodosPagoPreview(ArrayList<String> metodosPagoPreview) {
        this.metodosPagoPreview = metodosPagoPreview;
    }

    public void clearMetodosPreview() {
        this.metodosPagoPreview = new ArrayList<>();
    }
}