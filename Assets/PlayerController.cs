using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public Espada espada;
    public Sombrero sombrero;
    public int vidapj=1;
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;//cuando se hace publica sale en el editor de unity
    public ContactFilter2D movementFilter;
    public Animator animator;
    Vector2 movementInput;
    Rigidbody2D rb;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    bool success;
    bool animLocked=false;
    bool canMove=true;
    bool isMoving=false;
    bool atacando=false;
    void Start()
    {//busca el componente rigidbody y lo guarda en el atributo
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Debug.Log("holo");
        
        espada.daño=1;
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (movementInput == (Vector2.zero))
        // {
        //     animator.SetBool("IsMoving", false);
        // }
        // else
        // {
        //     animator.SetBool("IsMoving", true);
        // }
        // animator.SetFloat("horizontal", movementInput.x);
        // animator.SetFloat("vertical", movementInput.y);


    }
    private void FixedUpdate()
    {
        //si el movimiento no es 0 intentar moverse
        // if (movementInput != Vector2.zero)
        // {
        //     success = TryMove(movementInput);

        // }
        if(!animLocked && movementInput!=Vector2.zero){
            animator.SetFloat("horizontal", movementInput.x);
            animator.SetFloat("vertical", movementInput.y);
        }
        if( rb.bodyType==RigidbodyType2D.Dynamic){
            if(canMove==true&&movementInput !=Vector2.zero){
                rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
                isMoving=true;

            }
            else{
                isMoving=false;
            }
        }
        UpdateAnimation();
    }
    void UpdateAnimation(){
        if(!animLocked&&canMove){
            if(movementInput!=Vector2.zero){
                if(atacando){
                    animator.Play("Player_attack");

                }
                else{
                    EndSwordAttack();
                    animator.Play("Movement");
                }
            }
            else{
                if(atacando){
                    animator.Play("Player_attack");

                }
                else{
                    EndSwordAttack();
                    animator.Play("Idle");
                }
                
            }
            
        }

    }
    public void EndSwordAttack(){
        espada.StopAttack();
    }
    public void DetenerAtaque(){
        atacando=false;
    }
    public void Ataqueabajo(){
        espada.AttackDownDirection();
    }
    public void Ataquederecha(){
        espada.AttackRightDirection();
    }
    public void Ataqueizquierda(){
        espada.AttackLeftDirection();
    }
    public void Ataquearriba(){
        espada.AttackUpDirection();
     }
    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
        
    }
    void OnFire(InputValue movementValue){
        atacando=true;
        //animator.Play("swordAttack");
    }
    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Enemy"))
        {
            sombrero.vida-=1;
        }
    }

}
