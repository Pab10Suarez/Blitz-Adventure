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


    // Start is called before the first frame update
    void Start()
    {
        Region region1 = new Region("Zona fertida",20);
        Region region2 = new Region("Hogar",15);
        Region region3 = new Region("Desertica",10);
        Region region4 = new Region("Bosque",8);
        Region region6 = new Region("Tierra prohibida",4);
        Region region7 = new Region("Zona fertil",25);
        Region region8 = new Region("Valle",30);


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

        off();

        mapa.camino(region6,region1);


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

        //mapa.printRoot();
        //mapa.printRoot();
    }

    public void off(){

        camino1.SetActive(false);
        camino2.SetActive(false);
        camino3.SetActive(false);
        camino4.SetActive(false);
        camino5.SetActive(false);
        camino6.SetActive(false);
    }

}
