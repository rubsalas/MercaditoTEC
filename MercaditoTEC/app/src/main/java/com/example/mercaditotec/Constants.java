package com.example.mercaditotec;

import androidx.appcompat.app.AppCompatActivity;

public class Constants extends AppCompatActivity {

    public String URL = "https://mercaditotec.azurewebsites.net/api/";
    public int id;
    public String email, nombreCompleto;

    private static Constants instancia = null;
    private Constants(){}
    public static Constants getInstance()
    {
        if (instancia == null)
            instancia = new Constants();

        return instancia;
    }

    public String getURL() {
        return URL;
    }

    public void setURL(String URL) {
        this.URL = URL;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getNombreCompleto() {
        return nombreCompleto;
    }

    public void setNombreCompleto(String nombreCompleto) {
        this.nombreCompleto = nombreCompleto;
    }
}
