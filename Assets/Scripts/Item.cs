using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item: MonoBehaviour
{
    public Sprite icono;
    public  string nombre;
    public string descripcion;
    public  int precio;
    public bool  stackea =false;
    public GameObject inventario;
    
    // Start is called before the first frame update
    void Start()
    {
        inventario=GameObject.Find("Inventario script");
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

    public Item()
    {
    }

    public void use(){
        
    }
}
