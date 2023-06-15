using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstanciasControles : MonoBehaviour
{
    public gestorMisiones gestor;
    public Missions mision;
	public Text textoPantalla;
	public Text Mision1;
	public Text Mision2;
    private Missions[] misiones;
    // Start is called before the first frame update
    void Start()
    {
        Missions mision1 = new Missions(1,"Atrapa",1,"Atrapa los pollos");
		Missions mision2 = new Missions(2,"¿Huevos?",1,"Recoge los huevos");

        gestor = new gestorMisiones();

        gestor.addMission(mision1);
        gestor.addMission(mision2);

        misiones = gestor.emailmissionEspecial();

        for(int n=0;n<misiones.Length;n++){
            if(misiones[n].getPriority()==3){
                // string contenidoText = mision1.text;
                //string contenidoText2 = mision2.text;
            }
            if(n==0){
                Mision1.text = misiones[n].getTitle();
            }
            else{
                Mision2.text = misiones[n].getTitle();
            }
		}
    }

    public void printMision(){
        textoPantalla.text = misiones[0].getDescription();
    }

    public void printMision1(){
        textoPantalla.text = misiones[1].getDescription();
    }
}
