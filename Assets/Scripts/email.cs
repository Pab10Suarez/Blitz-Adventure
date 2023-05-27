using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;		


public class email : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
}

class mailBox<T>
{
    private int numberEmail;
    private stack<T> stackEmails = new stack<T>();

    public void addMessage(T data) {
		stackEmails.add(data);
	}
	
	public 	T  viewMessage() {
		return (T) stackEmails.top();	
	}
	
	public void deleteMessege() {
		stackEmails.delete();
	}
	
	public int numberMessage() {
		
		return stackEmails.Size();
    }

	public Email searchMessage(int data){
		return stackEmails.find(data);
	}
}

class Email{
    
	private int id;
    private Missions missions;
	
	public Email(int id,Missions missions) {
		this.id = id;
		this.missions = missions;
	}
	
	public Missions acceptMission() {
		return missions;
	}

	public int getID(){
		return this.id;
	}
}

class Missions {
	
	private string title;
	private string description;
	private int difficulty;
	
	private int advance; 
	
	public Missions(string title,string description,int difficulty) {
		this.title = title;
		this.description=description;
		this.difficulty=difficulty;
	}
    
	
	public string getTitle() {
		return title;
	}

	public void setAdvance(int advance){
		this.advance = advance;
	}

	public int getAdvance(){
		return advance;
	}

	public int getDifficulty(){
		return difficulty;
	}
	public string getDescription(){
		return description;
	}

}

class stack<T> {
	
	private Node<T> head;
	private Node<T> tail;
	private int size;
	
	class Node<T>{
		private Node<T> next;
		private T data;
		
		public Node(T data) {
			this.data = data;
		}

        public void setNext(Node<T> next){
            this.next = next;
        }

        public Node<T> getNext(){
            return next;
        }

        public T getData(){
            return data;
        }
	}
	
	public bool empty() {
		return head == null;
	}
	
	public void add(T data) {
		
		size++;
		
		if(empty()) {
			head = new Node<T>(data);
			return;
		}
		
		tail = head;
		head = new Node<T>(data);
		head.setNext(tail);
	}
	
	public T delete() {
		T data = default(T);
		size --;
		if(!empty()) {
			data = (T) head.getData();
			head = head.getNext();
		}
		return data;
	}
	
	public T top() {
		T data = default(T);
		if(!empty()) {
			data = (T) head.getData();
		}
		return data;
	}
	
	public int Size() {
		return size;
	}

	public Email find(int data){
		Node<T> head2= head;
		while(head2!=null){
			Email v = head2.getData() as Email;
			int value = v.getID();
			if(value==data){
				return v;
			}
			head2 = head2.getNext();
		}
		return null;
	}
}

