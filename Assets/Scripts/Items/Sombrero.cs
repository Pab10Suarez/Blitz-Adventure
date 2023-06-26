using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sombrero : Item
{
    // Start is called before the first frame update
    public int vida;
    public Sombrero(){
        this.nombre="Sombrero de Rancho";
        this.descripcion="si señor yo soy de rancho\n Te protege 2HP";
        this.vida=2;
        this.icono=Resources.Load<Sprite>("sombreroicono");
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("colision");
            if(!inventario.GetComponent<Inventario>().array.IsFull()){
                inventario.GetComponent<Inventario>().array.PushBack(this);
                inventario.GetComponent<Inventario>().array.Print();
                Destroy(gameObject);
            }

        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
