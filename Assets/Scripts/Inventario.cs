using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
public class Inventario: MonoBehaviour
{
    
    public ArrayList array=new(10);
   public RectTransform itemprefab;
    // Start is called before the first frame update
    void Start(){
        for(int i =0;i<10;i++){
            GameObject cartainstanciada=Instantiate(itemprefab).gameObject;
            cartainstanciada.transform.SetParent(transform);
        }
    }
    // Update is called once per frame
    void Update()
    { 
        
    }
}
public class ArrayList{
    public Item[] list;
    public int capacity;
    public int size;
    

    public ArrayList(int cap){
        capacity = cap;
        list = new Item[cap]; // asi se crea una lista en c#
        size = 0;
    }
    public void PushFront(Item key){
        AddBefore(0,key);
    }
    public void PushBack(Item key){
        if(!IsFull()){
            list[size++]=key;
        }
        else{
            UnityEngine.Debug.Log("El inventario está lleno!");
            Print();
        }

    }
    public void PopFront() {
        if (!IsEmpty()) {
            for (int i = 0; i < size - 1; i++) {
                list[i] = list[i + 1];
            }
            list[--size] = default; // no se puede usar null para dato generico en c#
        } else {
            UnityEngine.Debug.Log("List is empty.");
        }
        Print();
    }
    public void PopBack()
    {
        if (!IsEmpty())
        {
            list[--size] = default;
        }
        else
        {
            UnityEngine.Debug.Log("List is empty.");
        }
        Print();
    }
    public void AddBefore(int index, Item key)
    {
        if (!IsFull())
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
            Print();
        }
    }
    public void AddAfter(int index, Item key)
    {
        if (!IsFull())
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
            Print();
        }
    }
   public Item Get(int index)
    {
        if (index >= 0 && index < size)
        {
            return list[index];
        }
        else
        {
            UnityEngine.Debug.Log("Index out of bounds.");
            return default;
        }
    }
    public void Remove(int index)
    {
        if (index >= 0 && index < size)
        {
            for (int i = index; i < size - 1; i++)
            {
                list[i] = list[i + 1];
            }
            list[--size] = default;
        }
        else
        {
            UnityEngine.Debug.Log("Index out of bounds.");
        }
        Print();
    }

    public bool IsFull()
    {
        return size == capacity;
    }

    public bool IsEmpty()
    {
        return size == 0;
    }

    public void Print()
    {
        UnityEngine.Debug.Log("List: [");
        for (int i = 0; i < size; i++)
        {
            UnityEngine.Debug.Log(list[i].nombre + ", ");
        }
        UnityEngine.Debug.Log("]");
    }
    
}

