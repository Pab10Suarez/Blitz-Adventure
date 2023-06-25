using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public int health;
    public Animator animator;
    private bool destruir=false;
    
    public void Defeated(){
        Destroy(gameObject);
    }
    public void TakeDamage(int daño){
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
