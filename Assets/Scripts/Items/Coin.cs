using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin: Item
{

    public  Coin() 
    {
        nombre="Monedas";
        descripcion="Sirve para intercambiarlas por objetos";
        precio=0;
        stackea=true;
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player"))
        {
            inventario.GetComponent<Inventario>().array.PushBack(this);
            inventario.GetComponent<Inventario>().array.Print();
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
