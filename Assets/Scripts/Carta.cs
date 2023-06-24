using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Carta : MonoBehaviour
{
    public email scriptcorreo;
    public Button botonaceptar;
    public Missions misiondelacarta;
    private bool oprimidoAceptar=false;
    // Start is called before the first frame update
    void Awake()
    {

        
    }
    public void BtnAceptarOprimido()
    {
		scriptcorreo.controlescolaprioritaria.gestor.addMission(misiondelacarta);
        Transform botonsalida=gameObject.transform.Find("Exit");
        Transform botonext=gameObject.transform.Find("Next");
        if(botonsalida.gameObject.activeSelf){
            scriptcorreo.botonsalirOprimido();
        }
        else if(botonext.gameObject.activeSelf){
            scriptcorreo.botonsiguienteOprimido();
        }
        //
        oprimidoAceptar=false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
