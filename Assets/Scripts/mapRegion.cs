using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mapRegion : MonoBehaviour
{

    public Map mapa;
    public Region region;
    public Text nameRegion2;
    public Text nameRegion4;
    public Text nameRegion7;
    public Text nameRegion6;
    public Text nameRegion3;
    public Text nameRegion1;
    public Text nameRegion8;
    public GameObject camino1;
    public GameObject camino2;
    public GameObject camino3;
    public GameObject camino4;
    public GameObject camino5;
    public GameObject camino6;
    private TablaHashMapa hashMap = new TablaHashMapa();
    public Text partida;
    public Text llegada;
    private Region region1;
    private Region region2;
    private Region region3;
    private Region region4;
    private Region region6;
    private Region region7;
    private Region region8;
        
    


    // Start is called before the first frame update
    void Start()
    {
        region1 = new Region("Zona fertida",20);
        region2 = new Region("Hogar",15);
        region3 = new Region("Desertica",10);
        region4 = new Region("Bosque",8);
        region6 = new Region("Tierra prohibida",4);
        region7 = new Region("Zona fertil",25);
        region8 = new Region("Valle",30);


        mapa = new Map();

        mapa.addRegion(region1);
        mapa.addRegion(region2);
        mapa.addRegion(region3);
        mapa.addRegion(region4);
        mapa.addRegion(region6);
        mapa.addRegion(region7);
        mapa.addRegion(region8);

        nameRegion2.text = region2.getName();
        nameRegion4.text = region4.getName();
        nameRegion7.text = region7.getName();
        nameRegion6.text = region6.getName();
        nameRegion3.text = region3.getName();
        nameRegion1.text = region1.getName();
        nameRegion8.text = region8.getName();

        hashMap.add("Zona fertida",region1);
        hashMap.add("Hogar",region2);
        hashMap.add("Desertica",region3);
        hashMap.add("Bosque",region4);
        hashMap.add("Tierra prohibida",region6);
        hashMap.add("Zona fertil",region7);
        hashMap.add("Valle",region8);

        off();

    }

    public void off(){

        camino1.SetActive(false);
        camino2.SetActive(false);
        camino3.SetActive(false);
        camino4.SetActive(false);
        camino5.SetActive(false);
        camino6.SetActive(false);
    }

    public void puntoPartLlega(){
        string par = partida.text;
        string lleg = llegada.text;

        ruta(par,lleg);
    }

    public void ruta(string partida,string llegada){
        
        Region regionPartida = hashMap.getValue(partida);
        Region regionLlegada = hashMap.getValue(llegada);


        mapa.camino(regionPartida,regionLlegada);
        recorridoCamino();

    }

    public void recorridoCamino(){
        if(region1.isFormTravel()==true){
            camino1.SetActive(true);
        }

        if(region8.isFormTravel()==true){
            camino2.SetActive(true);
        }

        if(region7.isFormTravel()==true){
            camino3.SetActive(true);
        }

        if(region4.isFormTravel()==false){
            camino4.SetActive(true);
        }

        if(region6.isFormTravel()==true){
            camino5.SetActive(true);
        }

        if(region3.isFormTravel()==true){
            camino6.SetActive(true);
        }
    }



}
