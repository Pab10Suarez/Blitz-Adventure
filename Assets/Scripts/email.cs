using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class email : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Missions misionOne = new Missions("Tocar");
        Missions misionTwo = new Missions("Saltar");
        Missions misionTree = new Missions("atacar");

        Email emailOne = new Email(misionOne);
        Email emailTwo = new Email(misionTwo);
        Email emailTree = new Email(misionTree);

        mailBox<Email> MainEmail = new mailBox<Email>();
        MainEmail.addMessage(emailOne);
        MainEmail.addMessage(emailTwo);
        MainEmail.addMessage(emailTree);

        Debug.Log(MainEmail.viewMessage().acceptMission().getTitle());
        MainEmail.deleteMessege();
        Debug.Log(MainEmail.viewMessage().acceptMission().getTitle());
        Debug.Log(MainEmail.numberMessage());
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
}

class Email{
    
    private Missions missions;
	
	public Email(Missions missions) {
		this.missions = missions;
	}
	
	public Missions acceptMission() {
		return missions;
	}
}

class Missions {
	
	private string title;
	private int difficulty; 
	
	public Missions(string title) {
		this.title = title;
	}
    
	
	public string getTitle() {
		return title;
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

}

