using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventario: MonoBehaviour
{
    public int capacidadjugador=14;
    public ArrayList array=new(14);
   public RectTransform itemprefab;
   public Button boton;
   public Button botonsalir;
   private bool oprimidosalir;
   private bool oprimidoabrir;
   private bool primeravez;
   public GameObject inventariogameobject;
    // Start is called before the first frame update
    void Start(){
        oprimidoabrir=false;
        primeravez=true;
        boton.onClick.AddListener(BotonOprimido);
        botonsalir.onClick.AddListener(BotonSalirOprimido);
        
    }
    // Update is called once per frame
    void Update()
    {   
        
        if(oprimidoabrir){
            if(primeravez){
                // va poniendo los slots dependiendo de la capacidad de ljugador
                for(int i =0;i<capacidadjugador;i++){
                    GameObject objetoinstanciado=Instantiate(itemprefab).gameObject;
                    objetoinstanciado.transform.SetParent(inventariogameobject.transform);
                    Item itemactual=array.Get(i);
                    Debug.Log(i);
                    //Debug.Log(!object.ReferenceEquals(itemactual, null));
                    // la forma de revisar si es igual a null en unity 
                    if(!object.ReferenceEquals(itemactual, null)){
                        Debug.Log("entrocosa");
                        Sprite icono=itemactual.icono;
                        objetoinstanciado.transform.Find("Itempicture").GetComponent<SpriteRenderer>().sprite=icono;
                    }
                }
                primeravez=false;
             }
             else{
                for(int i =0;i<capacidadjugador;i++){
                    Item itemactual=array.Get(i);
                    Debug.Log(i);
                    //Debug.Log(!object.ReferenceEquals(itemactual, null));
                    // la forma de revisar si es igual a null en unity 
                    if(!object.ReferenceEquals(itemactual, null)){
                        Debug.Log("entrocosa");
                        Sprite icono=itemactual.icono;
                        Transform objetoslot=inventariogameobject.transform.GetChild(i+3);
                        objetoslot.Find("Itempicture").GetComponent<SpriteRenderer>().sprite=icono;
                    }
                }
             }  
            inventariogameobject.SetActive(true);
            oprimidoabrir=false;
        }
        if(oprimidosalir){
            inventariogameobject.SetActive(false);
            oprimidosalir=false;
        }
    }
    public void BotonOprimido(){  
        oprimidoabrir=true;
    }
    public void BotonSalirOprimido(){
        oprimidosalir=true;
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
            return null;
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
            UnityEngine.Debug.Log(list[i].nombre + ", "+i);
        }
        UnityEngine.Debug.Log("]");
    }
    
}

