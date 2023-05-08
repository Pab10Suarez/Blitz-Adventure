using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    string nombre;
    string descripcion;
    int precio;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Item(string nombre, string descripcion, int precio){
        this.nombre=nombre;
        this.descripcion=descripcion;
        this.precio=precio;
    }
}
