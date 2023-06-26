using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public InstanciasControles gestor;
    public int health;
    public Animator animator;
    private bool destruir=false;
    public AudioSource morir;
    public AudioSource dañao;
    public void mortis(){
        morir.Play();
    }
    public void Defeated(){
        gestor.slimesmoridos++;
        Destroy(gameObject);
    }
    public void TakeDamage(int daño){
        dañao.Play();
        health-=daño;
        Debug.Log(daño);
        if(health<=0){
            animator.Play("Slime_Defeated");
        }
        else{
            animator.Play("Slime_TakeDamage");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        health=2;
    }
    public void Idle(){
        animator.Play("Slime_Idle");
    }
    void FixedUpdate(){

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
