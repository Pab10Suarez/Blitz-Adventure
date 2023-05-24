using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{   
    public float moveSpeed=1f;
    public float collisionOffset=0.05f;//cuando se hace publica sale en el editor de unity
    public ContactFilter2D movementFilter;
    public Animator animator;
    Vector2 movementInput;
    Rigidbody2D rb;
    List<RaycastHit2D> castCollisions=new List<RaycastHit2D>();
    bool success;
    void Start()
    {//busca el componente rigidbody y lo guarda en el atributo
        rb=GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
        Debug.Log("holo");
    }

    // Update is called once per frame
    void Update()
    {           if(movementInput==(Vector2.zero)){
            animator.SetBool("IsMoving",false);      
        }
        else{
            animator.SetBool("IsMoving",true);  
        }
        animator.SetFloat("horizontal",movementInput.x);
        animator.SetFloat("vertical",movementInput.y);

         
    }
    private void FixedUpdate() {
        //si el movimiento no es 0 intentar moverse
        if(movementInput !=Vector2.zero){
            success = TryMove(movementInput);
                 
        }
    }
    private bool TryMove(Vector2 direction){
        if(direction != Vector2.zero) {
            //if(countcollisions==0){
                rb.MovePosition(rb.position+movementInput*moveSpeed*Time.fixedDeltaTime);
                return true;
            //}
            //else{
            //     return false;
            // }
        }
        else{
          return false;   
        }    
    }
    //recibe 
    void OnMove(InputValue movementValue){
        movementInput=movementValue.Get<Vector2>();
    }
}
