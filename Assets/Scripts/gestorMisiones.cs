using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System;

public class gestorMisiones : MonoBehaviour
{

	private queuePriority cola = new queuePriority(4);

	public void deleteMision(Missions mision) {
		cola.delete(mision.getID());
	}
	

	public void addMission(Missions mision){
		cola.insert(mision);
	}

	public Missions[] emailmissionEspecial(){
		Missions[] values = cola.travel();
		return values;
	}
}


public class Email{
    
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

class arrayStack<T>{
	private T[] data;
	private int capacity;
	private int index;

	public arrayStack(int capacity){
		this.capacity = capacity;
		this.index =0;
		data = new T[capacity];
	}

	public bool empty(){
		return index==0;
	}

	public bool full(){
		return index==capacity;
	}

	public void add(T dato){
		if(!full()){
			data[index++] = dato;
		}
	}

	public T delete(){
		T value = default(T);
		if(!empty()){
			index = index -1;
			value = (T) data[index];
		}

		return value;
	}

	public T top(){
		T value = default(T);
		if(!empty()){
			int aux = index-1;
			value = (T) data[aux];
		}

		return value;
	}

	public int Size(){
		return index;
	}


	public Email find(int id){

		if(!empty()){
			for(int n=0; n<data.Length;n++){
				Email emaill = data[n] as Email;
				int ID = emaill.getID();
				if(id==ID){
					return emaill;
				}
			}
		}
		return null;
	}
}

class queuePriority{

	private int size;
	private int maxSize;
	private Missions[] data;

	public queuePriority(int maxSize){
		this.maxSize = maxSize;
		this.size = 0;
		data = new Missions[maxSize];
	}

	public Boolean  empty(){
		return size==0;
	}

	public Boolean full(){
		return size==maxSize;
	}

	public void insert(Missions dato) {
		
		if(full()) return;
		data[size++]= dato;
		siftUp(size-1); 
	}
	
	private void siftUp(int i) {

		Missions email = data[parent(i)];
		Missions ema = data[i];

		int valueParent = email.getPriority();
		int value = ema.getPriority();
		
		while(i>0 && valueParent < value) {
			
			Missions value1 = data[parent(i)]; 
			data[(i-1)/2] = data[i];
			data[i] = value1;
			i = parent(i);

			email = data[parent(i)];
			ema = data[i];
			valueParent = email.getPriority();
			value = ema.getPriority();
		}
	}

	private void siftDown(int i) { 
		
		int maxIndex = i;
		int lchild = leftChild(i);
		int dato,dato1;
		Missions email,ema;
		
		if(lchild<= size) {
			email = data[lchild];
			dato = email.getPriority();
			ema = data[maxIndex];
			dato1 = ema.getPriority();
			if(dato>dato1)maxIndex = lchild;
		}

		int rchild = rightChild(i);

		if(rchild<=size) {
			ema = data[maxIndex];
			dato1 = ema.getPriority();
			email = data[rchild];
			dato = email.getPriority();
			if(dato>dato1) maxIndex = rchild;
		}
		
		if (i!= maxIndex) {
			Missions value = data[i];
			data[i] = data[maxIndex];
			data[maxIndex] = value;
			siftDown(maxIndex);
		}
	}

	private Missions extractMax() {
		size = size - 1;
		Missions value = data[0];
		data[0] = data[size];
		siftDown(0);
		return value;
	}


	public Missions[] sorting() {
		return heapSort(data);
	}

	private Missions[] heapSort(Missions[] value) {
		
		for( int n=0; n<value.Length;n++) {
			insert(value[n]);
		}
		for( int n=value.Length -1; n>-1;n--) {
			value[n] = extractMax();
		}
		return value;
	}

	public void remove(int i) {

		Missions mis = data[i];
		mis.setPriorit(1000000000);
		data[i] = mis;
		siftUp(i+1);
		siftDown(i);
	}

	public Missions[] travel(){
		Missions [] values  = new Missions[data.Length];
		for(int n=0;n<data.Length;n++){
			//UnityEngine.Debug.Log(data[n].getTitle()+ " "+data[n].getPriority());
			values[n] = data[n];
		}
		return values;

	}

	public void delete(int valor){
		int id = find(valor);
		if(id!=-1){
			remove(id);
		}else UnityEngine.Debug.Log("Elemento no encontrado");
	}

	public int find(int valor){
		for(int n=0;n<data.Length;n++){
			if (data[n].getID()==valor) return n;
		}
		return -1;
	}
	

	private int leftChild(int i) {
		return (2*i) + 1;
	}
	
	private int rightChild(int i) {
		return (2*i) +2;
	}
	
	private int parent(int i) {
		return (i-1)/2;
	}
}

// pila
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