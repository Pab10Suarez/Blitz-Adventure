using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkedList<T>
{
    Nodo<T> head;
  Nodo<T> tail;
  Nodo<T> [] list;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  public LinkedList(){
    this.head=null;
  }
    public void pushFront(T key){
    //si está vacia
    Nodo<T> n=new Nodo<T>(key,head,null);
    if(head!=null){
    
    head.prev=n; // el prev del current head es el nuevo nodo
    head=n;
    }
     else{
      head=n;  
      tail=n;
     }
  }
  public void pushBack(T key){
      Nodo<T> n=new Nodo<T>(key,null,tail);
      if(head==null){
        pushFront(key);
      }
      else{
        tail.next=n;
        tail=n;
      }
    
  }
  //métodos para stack
    public Nodo<T> popBack(){
    if(head != null){
      Nodo<T> auxiliar = tail;
      auxiliar.prev=null;
      tail=tail.prev;
      tail.next=null;
      return auxiliar;
    }
    else{
      Debug.Log("la lista está vacia");
      return null;
        
    }
  }
  public Nodo<T> popFront(){
    if(head != null){
      Nodo<T> auxiliar = head;
      head=head.next;
      return auxiliar;
    }
    else{
      Debug.Log("la lista está vacia");
      return null;
        
    }
  }
  public Nodo<T> Top(){
      return head;
  }
  public Nodo<T> Back(){
      return tail; 
  }
  public void print(){
      Nodo<T> nodo= head; //nodo auxiliar
      while(nodo!=null){
        Debug.Log(nodo);
        if(nodo.next!=null){
            Debug.Log(" ");
        }
        nodo=nodo.next;  
      }
      
  }
  public void reverse(){
      LinkedList<T> listaux= new LinkedList<T>();
      while(this.tail!=null){
          //System.out.println(Back().key);
          listaux.pushBack(this.popBack().key);
      } 
      while(listaux.head!=null){
          pushBack(listaux.popFront().key);
      }
     
  }
  public T get(int index){
       Nodo<T> nodo= head; 
      
       for(int i=0;i<index;i++){
               //System.out.println("get()"+nodo.key);
               nodo=nodo.next;
       }
       //System.out.println("get()==="+nodo.key);
       return nodo.key;
  }
}

  //----clase nodo---
 public class Nodo<T>{
  public T key;
  public Nodo<T> next;
  public Nodo<T> prev;
  public Nodo(T key, Nodo<T> next,Nodo<T> prev){
    this.key=key;
    this.next=next;
    this.prev=prev;
  }
  public T getKey() {
  	return key;
  }
  public void setKey(T key) {
  	this.key = key;
  }
  public Nodo<T> getNext() {
  	return next;
  }
  public void setNext(Nodo<T> next) {
  	this.next = next;
  }
public override string ToString()
{
    return key.ToString();
}
}
