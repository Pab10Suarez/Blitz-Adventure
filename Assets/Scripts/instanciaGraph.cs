using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class instanciaGraph : MonoBehaviour
{
    
    public grafoMatrix mapGrafo;
    private Region region1;
    private Region region2;
    private Region region3;
    private Region region4;
    private Region region6;
    private Region region7;
    private Region region8;
    public Text RutaSeguir;
    public Text partida;
    public Text llegada;
    private TablaHashMapa hashMap = new TablaHashMapa();
    public GameObject imgPaz;
    public GameObject imgDes;
    public GameObject imgCol;
    public GameObject imgHog;
    public GameObject imgMar;
    public GameObject imgBos;
    public GameObject imgMon;


    void Start()
    {
        region1 = new Region("Zona paz",20);
        region2 = new Region("Desierto",15);
        region3 = new Region("Colina",10);
        region4 = new Region("Hogar",8);
        region6 = new Region("Villa mar",4);
        region7 = new Region("Bosque",25);
        region8 = new Region("Monumentos",30);

        hashMap.add("Zona paz",region1);
        hashMap.add("Desierto",region2);
        hashMap.add("Colina",region3);
        hashMap.add("Hogar",region4);
        hashMap.add("Villa mar",region6);
        hashMap.add("Bosque",region7);
        hashMap.add("Monumentos",region8);

        mapGrafo = new grafoMatrix(7);
        addVertice();
        addArista();

        //mapGrafo.shortPath(region3,region8);
    }

    public void addArista(){

        mapGrafo.addArista(region1,region4);
        mapGrafo.addArista(region1,region6);
        mapGrafo.addArista(region6,region1);
        mapGrafo.addArista(region6,region4);
        mapGrafo.addArista(region6,region7);
        mapGrafo.addArista(region7,region4);
        mapGrafo.addArista(region7,region6);
        mapGrafo.addArista(region7,region8);
        mapGrafo.addArista(region2,region4);
        mapGrafo.addArista(region3,region4);
        mapGrafo.addArista(region3,region8);
        mapGrafo.addArista(region8,region4);
        mapGrafo.addArista(region8,region3);
        mapGrafo.addArista(region8,region7);
        mapGrafo.addArista(region4,region1);
        mapGrafo.addArista(region4,region2);
        mapGrafo.addArista(region4,region3);
        mapGrafo.addArista(region4,region6);
        mapGrafo.addArista(region4,region7);
        mapGrafo.addArista(region4,region8);
    }

    public void addVertice(){
        mapGrafo.addVertice(region1);
        mapGrafo.addVertice(region2);
        mapGrafo.addVertice(region3);
        mapGrafo.addVertice(region4);
        mapGrafo.addVertice(region6);
        mapGrafo.addVertice(region7);
        mapGrafo.addVertice(region8);
    }

    public void puntoPartLlega(){
        string par = partida.text;
        string lleg = llegada.text;

        recorridoCorto(par,lleg);
    }

    public void recorridoCorto(string star, string end){
        Region regionPartida = hashMap.getValue(star);
        Region regionLlegada = hashMap.getValue(end);

        mapGrafo.shortPath(regionPartida,regionLlegada);

        string message = "Necesitas pasa por los siguientes \n lugares \n "+mapGrafo.totalReccorrido();
        RutaSeguir.text = message;
        off();
        recorridoCamino();

    }

    public void off(){
        imgPaz.SetActive(false);
        imgDes.SetActive(false);
        imgCol.SetActive(false);
        imgHog.SetActive(false);
        imgMar.SetActive(false);
        imgBos.SetActive(false);
        imgMon.SetActive(false);
        
    }

      public void recorridoCamino(){
        if(region1.isFormTravel()==true){
            imgPaz.SetActive(true);
            region1.setFormTravel(false);
        }

        if(region2.isFormTravel()==true){
            imgDes.SetActive(true);
            region2.setFormTravel(false);
        }

        if(region3.isFormTravel()==true){
            imgCol.SetActive(true);
            region3.setFormTravel(false);
        }

        if(region4.isFormTravel()==true){
            imgHog.SetActive(true);
            region4.setFormTravel(false);
        }

        if(region6.isFormTravel()==true){
            imgMar.SetActive(true);
            region6.setFormTravel(false);
        }

        if(region7.isFormTravel()==true){
            imgBos.SetActive(true);
            region7.setFormTravel(false);
        }

        if(region8.isFormTravel()==true){
            imgMon.SetActive(true);
            region8.setFormTravel(false);
        }
    }




}
