using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espada : Item
{
    public int daño;
    public AudioSource sonido;
    BoxCollider2D swordCollider;
    Vector2 Ataquederecha;
    Vector2 Ataqueabajo ;

    public Espada()
    {

        this.daño = 2;
        this.nombre = "Espada de Caballero";
        this.descripcion="Sirve para defenderse contras pequeñas criaturas\n Hace "+daño+" puntos de daño";
        this.icono=Resources.Load<Sprite>("espadaicono");
    }
    // Start is called before the first frame update
    void Start()
    {
        Ataquederecha=new Vector2((float)0.3611833, (float)-0.3779988);
        Ataqueabajo= new Vector2((float)0, (float)-0.4189231);
        Debug.Log(Ataquederecha);
        swordCollider = gameObject.GetComponent<BoxCollider2D>();

    }

    public void AttackRightDirection()
    {
        if(!equipable){
        swordCollider.size = new Vector2((float)0.4251317, (float)0.7329685);
        swordCollider.enabled = true;
        swordCollider.offset = Ataquederecha;
        }

        //Debug.Log(swordCollider.offset);

    }

    public void AttackLeftDirection()
    {
        if(!equipable){
        swordCollider.size = new Vector2((float)0.4251317, (float)0.7329685);
        swordCollider.enabled = true;
        swordCollider.offset = new Vector2(Ataquederecha.x * -1, Ataquederecha.y);
        }
    }
    public void AttackUpDirection()
    {
        if(!equipable){
        swordCollider.size = new Vector2((float)0.774071, (float)0.4189231);
        swordCollider.enabled = true;
        swordCollider.offset = new Vector2((float)-0.1, (float)-0.1);
        }
    }
    public void AttackDownDirection()
    {
        if(!equipable){
        swordCollider.size = new Vector2((float)0.774071, (float)0.4189231);
        swordCollider.offset = Ataqueabajo;
        swordCollider.enabled = true;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Enemy")&&!equipable)
        {
            //hacer daño al enemigo
            Enemigo enemigo=other.GetComponent<Enemigo>();
            enemigo.TakeDamage(daño);
            Debug.Log("ATACAO");
            
        }
        if(other.CompareTag("Player"))
        {
            Debug.Log("colision");
            if(!inventario.GetComponent<Inventario>().array.IsFull()){
                sonido.Play();
                inventario.GetComponent<Inventario>().array.PushBack(this);
                inventario.GetComponent<Inventario>().array.Print();
                Destroy(gameObject);
            }

        }
    }
    public void StopAttack(){
        swordCollider.enabled=false;
    }
    public void StartAttack(){
         swordCollider.enabled=true;    
    }
    // Update is called once per frame
    void Update()
    {

    }
}
