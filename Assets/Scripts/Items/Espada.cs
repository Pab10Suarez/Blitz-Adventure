using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espada : Item
{
    public int daño;
    BoxCollider2D swordCollider;
    Vector2 Ataquederecha;
    Vector2 Ataqueabajo ;

    public Espada(int daño, string nombre)
    {
        this.daño = daño;
        this.nombre = nombre;
    }

    // Start is called before the first frame update
    void Start()
    {
        Ataquederecha=new Vector2((float)0.3611833, (float)-0.3779988);
        Ataqueabajo= new Vector2((float)0.774071, (float)0.4189231);
        Debug.Log(Ataquederecha);
        swordCollider = gameObject.GetComponent<BoxCollider2D>();

    }

    public void AttackRightDirection()
    {
        swordCollider.size = new Vector2((float)0.4251317, (float)0.7329685);
        swordCollider.enabled = true;
        swordCollider.offset = Ataquederecha;
        //Debug.Log(swordCollider.offset);

    }

    public void AttackLeftDirection()
    {
        swordCollider.size = new Vector2((float)0.4251317, (float)0.7329685);
        swordCollider.enabled = true;
        swordCollider.offset = new Vector2(Ataquederecha.x * -1, Ataquederecha.y);
    }
    public void AttackUpDirection()
    {
        swordCollider.size = new Vector2((float)0.774071, (float)0.4189231);
        swordCollider.enabled = true;
        swordCollider.offset = new Vector2((float)Ataqueabajo.x, (float)-Ataqueabajo.y);
    }
    public void AttackDownDirection()
    {
        Debug.Log(swordCollider.name);
        swordCollider.size = new Vector2((float)0.774071, (float)0.4189231);
        swordCollider.offset = Ataqueabajo;
        swordCollider.enabled = true;
        
    }
    private void OntriggerEnter2D(Collider2D other){
        if(other.CompareTag("Enemy"))
        {
            //hacer daño al enemigo
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
