using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espada : Item
{
    int daño;
    BoxCollider2D swordCollider;
    Vector2 Ataquederecha = new Vector2((float)0.37, (float)-0.39);
    Vector2 Ataqueabajo = new Vector2((float)0.15, (float)-0.55);

    public Espada(int daño, string nombre)
    {
        this.daño = daño;
        this.nombre = nombre;
    }

    // Start is called before the first frame update
    void Start()
    {
        swordCollider = gameObject.GetComponent<BoxCollider2D>();

    }

    public void AttackRightDirection()
    {
        swordCollider.size = new Vector2((float)0.3736006, (float)0.7303656);
        swordCollider.enabled = true;
        transform.position = Ataquederecha;

    }

    public void AttackLeftDirection()
    {
        swordCollider.size = new Vector2((float)0.3736006, (float)0.7303656);
        swordCollider.enabled = true;
        transform.position = new Vector2(Ataquederecha.x * -1, Ataquederecha.y);
    }
    public void AttackUpDirection()
    {
        swordCollider.size = new Vector2((float)0.7657752, (float)0.5045968);
        swordCollider.enabled = true;
        transform.position = new Vector2((float)Ataqueabajo.x, (float)-Ataqueabajo.y);
    }
    public void AttackDownDirection()
    {
        Debug.Log(swordCollider.name);
        swordCollider.size = new Vector2((float)0.7657752, (float)0.5045968);
        swordCollider.enabled = true;
        transform.position = Ataqueabajo;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
