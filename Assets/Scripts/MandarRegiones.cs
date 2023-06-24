using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MandarRegiones : MonoBehaviour
{
    // Start is called before the first frame update
    private mapRegion instancias;
    public Text partida;
    public Text llegada;

    public MandarRegiones(){
        this.instancias = new mapRegion();
    }

    public void puntoPartLlega(){
        string par = partida.text;
        string lleg = llegada.text;

        Debug.Log(par);
        Debug.Log(lleg);

        instancias.ruta(par,lleg);
    }

}
