using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class PruebasHash : MonoBehaviour
{

    private TableHash<string, Item> tablaHa = new TableHash<string, Item>(1020000);
    public ArrayList arrayItem = new ArrayList(1000000);

    internal TableHash<string, Item> TablaHa { get => tablaHa; set => tablaHa = value; }

    string[] values ={"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q",
                      "R","S","T","U","V","X","Y","Z"};

    Stopwatch sw = new Stopwatch();
    

    void Start()
    {
        for(int n=0;n<1000000;n++){
            string key= values[Random.Range(0,values.Length)]+values[Random.Range(0,values.Length)]+values[Random.Range(0,values.Length)]+
                        values[Random.Range(0,values.Length)]+values[Random.Range(0,values.Length)]+values[Random.Range(0,values.Length)];

            string name= values[Random.Range(0,values.Length)]+values[Random.Range(0,values.Length)]+values[Random.Range(0,values.Length)]+
                         values[Random.Range(0,values.Length)];

            string descri= values[Random.Range(0,values.Length)]+values[Random.Range(0,values.Length)]+values[Random.Range(0,values.Length)]+
                         values[Random.Range(0,values.Length)];

            int ran = Random.Range(0,10000000);

            Item pruebaItem = new Item(name,descri,ran);

            tablaHa.put(key,pruebaItem);
        }

        sw.Start();
        Item itemSearch = new Item("RDaniel","EstructurasDeDatos",26);
        tablaHa.put("RdanielJM",itemSearch);

        UnityEngine.Debug.Log(tablaHa.get("RdanielJM").descripcion);

        Item itemSearc = new Item("RDaniel","Cat"+values[Random.Range(0,values.Length)],21);
        tablaHa.put("RdanielJM",itemSearc);

        UnityEngine.Debug.Log(tablaHa.get("RdanielJM").descripcion);

        UnityEngine.Debug.Log("SIZE: "+tablaHa.size());

        sw.Stop();

        // UnityEngine.Debug.Log(sw.Elapsed);
        // UnityEngine.Debug.Log(sw.Elapsed.Milliseconds);


        // for(int n=0;n<1000000;n++){

        //     string key= values[Random.Range(0,values.Length)]+values[Random.Range(0,values.Length)]+values[Random.Range(0,values.Length)]+
        //                 values[Random.Range(0,values.Length)]+values[Random.Range(0,values.Length)]+values[Random.Range(0,values.Length)];

        //     string name= values[Random.Range(0,values.Length)]+values[Random.Range(0,values.Length)]+values[Random.Range(0,values.Length)]+
        //                  values[Random.Range(0,values.Length)];

        //     string descri= values[Random.Range(0,values.Length)]+values[Random.Range(0,values.Length)]+values[Random.Range(0,values.Length)]+
        //                  values[Random.Range(0,values.Length)];

        //     int ran = Random.Range(0,10000000);

        //     Item pruebaItem = new Item(name,descri,ran);
        //     arrayItem.PushFront(pruebaItem);
        // }

        // int rang = Random.Range(0,1000000);
        // UnityEngine.Debug.Log(arrayItem.Get(rang).nombre);
        // UnityEngine.Debug.Log("----------------------------------------------------------");
        // sw.Start();
        // Item addItem = new Item("Daniel","Hola",200);
        // arrayItem.Update(rang,addItem);
        // sw.Stop();
        // UnityEngine.Debug.Log(sw.Elapsed);
        // UnityEngine.Debug.Log(sw.Elapsed.Milliseconds);

        // UnityEngine.Debug.Log("----------------------------------------------------------");

        // UnityEngine.Debug.Log(arrayItem.Get(rang).nombre);
    }


}
