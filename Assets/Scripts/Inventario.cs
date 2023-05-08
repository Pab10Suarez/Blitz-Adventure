using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
public class Inventario: MonoBehaviour
{
    // Start is called before the first frame update
        void Start(){
        Stopwatch sw= new Stopwatch();
        int test=100000000;
        inventario<Item> objetoprueba= new inventario<Item>(test);
        for(int i=0; i<test;i++){
            objetoprueba.pushBack(new Item("nombrestest","descripciontest",1));
        }
        sw.Start();   
        objetoprueba.get(Random.Range(0,test));
        sw.Stop();
        UnityEngine.Debug.Log("Get "+test);
        UnityEngine.Debug.Log(sw.Elapsed);
    }
    // Update is called once per frame
    void Update()
    { 
        
    }
}
class inventario<T>{
    public T[] list;
    public int capacity;
    public int size;
    

    public inventario(int cap){
        capacity = cap;
        list = new T[cap]; // asi se crea una lista en c#
        size = 0;
    }
    public void pushFront(T key){
        addBefore(0,key);
    }
    public void pushBack(T key){
        if(!isFull()){
            list[size++]=key;
        }
        else{
            UnityEngine.Debug.Log("El inventario está lleno!");
            print();
        }

    }
    public void popFront() {
        if (!isEmpty()) {
            for (int i = 0; i < size - 1; i++) {
                list[i] = list[i + 1];
            }
            list[--size] = default(T); // no se puede usar null para dato generico en c#
        } else {
            UnityEngine.Debug.Log("List is empty.");
        }
        print();
    }
    public void popBack()
    {
        if (!isEmpty())
        {
            list[--size] = default(T);
        }
        else
        {
            UnityEngine.Debug.Log("List is empty.");
        }
        print();
    }
    public void addBefore(int index, T key)
    {
        if (!isFull())
        {
            for (int i = size; i > index; i--)
            {
                list[i] = list[i - 1];
            }
            list[index] = key;
            size++;
        }
        else
        {
            UnityEngine.Debug.Log("List is full.");
            print();
        }
    }
    public void addAfter(int index, T key)
    {
        if (!isFull())
        {
            for (int i = size; i > index + 1; i--)
            {
                list[i] = list[i - 1];
            }
            list[index + 1] = key;
            size++;
        }
        else
        {
            UnityEngine.Debug.Log("List is full.");
            print();
        }
    }
   public T get(int index)
    {
        if (index >= 0 && index < size)
        {
            return list[index];
        }
        else
        {
            UnityEngine.Debug.Log("Index out of bounds.");
            return default(T);
        }
    }
    public void remove(int index)
    {
        if (index >= 0 && index < size)
        {
            for (int i = index; i < size - 1; i++)
            {
                list[i] = list[i + 1];
            }
            list[--size] = default(T);
        }
        else
        {
            UnityEngine.Debug.Log("Index out of bounds.");
        }
        print();
    }

    public bool isFull()
    {
        return size == capacity;
    }

    public bool isEmpty()
    {
        return size == 0;
    }

    public void print()
    {
        UnityEngine.Debug.Log("List: [");
        for (int i = 0; i < size; i++)
        {
            UnityEngine.Debug.Log(list[i] + ", ");
        }
        UnityEngine.Debug.Log("]");
    }
}

