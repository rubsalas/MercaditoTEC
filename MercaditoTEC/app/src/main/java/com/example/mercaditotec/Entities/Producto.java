package com.example.mercaditotec.Entities;

import org.json.JSONArray;
import org.json.JSONObject;

import java.util.ArrayList;

public class Producto {
    private String nombre, descripcion;
    private JSONArray imagen;
    private int id;
    private float precio;

        public Producto(JSONArray imagen, String nombre, String descripcion, int id, float precio) {
        this.nombre = nombre;
        this.descripcion = descripcion;
        this.id = id;
        this.precio = precio;
        this.imagen = imagen;
    }

    public JSONArray getImagen() {
        return imagen;
    }

    public void setImagen(JSONArray imagen) {
        this.imagen = imagen;
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
