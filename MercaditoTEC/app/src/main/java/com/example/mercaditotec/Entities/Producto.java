package com.example.mercaditotec.Entities;

public class Producto {
    private String nombre, ubicacion, imagen;
    private int id;
    private float precio;

    public Producto(String imagen, String nombre, String ubicacion, int id, float precio) {
        this.nombre = nombre;
        this.ubicacion = ubicacion;
        this.id = id;
        this.precio = precio;
        this.imagen = imagen;
    }

    public String getImagen() {
        return imagen;
    }

    public void setImagen(String imagen) {
        this.imagen = imagen;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public String getUbicacion() {
        return ubicacion;
    }

    public void setUbicacion(String ubicacion) {
        this.ubicacion = ubicacion;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public float getPrecio() {
        return precio;
    }

    public void setPrecio(float precio) {
        this.precio = precio;
    }
}
