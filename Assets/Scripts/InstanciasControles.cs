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
    public Text MisionP1;
	public Text MisionP2;
    public Text MisionS1;
	public Text MisionS2;
    public Text Difficulty;
    private Missions[] misiones;
    private Missions[] dataEspeciales = new Missions[2];
    private Missions[] dataPrincipal = new Missions[2];
    private Missions[] dataSegundarias = new Missions[2];
    // Start is called before the first frame update
    void Start()
    {
        Missions mision1 = new Missions(1,"Atrapa",1,"Atrapa los pollos");
		Missions mision2 = new Missions(2,"¿Huevos?",1,"Recoge los huevos");

        Missions mision3 = new Missions(3,"Salta",2,"Salta sobre 5 obstaculos");
		Missions mision4 = new Missions(4,"Enemigo",2,"Acaba con el enemigo");


        gestor = new gestorMisiones();

        gestor.addMission(mision1);
        gestor.addMission(mision2);
        gestor.addMission(mision3);
        gestor.addMission(mision4);

        misiones = gestor.emailmissionEspecial();

        for(int n=0;n<misiones.Length;n++){

            if(misiones[n].getPriority()==3){

                string contenidoText = Mision1.text;
                string contenidoText2 = Mision2.text;
                string defecto = "New Text";
                if(contenidoText.ToUpper()==defecto.ToUpper()){
                    printMision(misiones[n]);
                    dataEspeciales[0] = misiones[n];
                }else if(contenidoText2.ToUpper()==defecto.ToUpper()){
                    printMision1(misiones[n]);
                    dataEspeciales[1] = misiones[n];
                }
            }
            else if(misiones[n].getPriority()==2){
                //Debug.Log(misiones[n].getPriority());
                string tituloP1 = MisionP1.text;
                string tituloP2 = MisionP2.text;
                string defecto = "New Text";
                if(tituloP1.ToUpper()==defecto.ToUpper()){
                    printMisionP(misiones[n]);
                    dataPrincipal[0] = misiones[n];
                }else if(tituloP2.ToUpper()==defecto.ToUpper()){
                    printMision1P(misiones[n]);
                    dataPrincipal[1] = misiones[n];
                }
            }
            else if(misiones[n].getPriority()==1){
                Debug.Log(misiones[n].getPriority());
                string tituloS1 = MisionS1.text;
                string tituloS2 = MisionS2.text;
                string defecto = "New Text";
                if(tituloS1.ToUpper()==defecto.ToUpper()){
                    printMisionS(misiones[n]);
                    dataSegundarias[0] = misiones[n];
                }else if(tituloS2.ToUpper()==defecto.ToUpper()){
                    printMision1S(misiones[n]);
                    dataSegundarias[1] = misiones[n];
                }

            }
		}
    }

    //-------------------------------------------ESPECIALES MS---------------------------------------------------//
    private void printMision(Missions msm){
        Mision1.text = msm.getTitle();

    }

    private void printMision1(Missions msm){
        Mision2.text = msm.getTitle();
    }

    public void changeFlagEspecial1(){
        prueba();
    }

    public void changeFlagEspecial2(){
        prueba1();
    }

    private void prueba(){
        textoPantalla.text = dataEspeciales[0].getDescription();

        string value = dataEspeciales[0].getTitle()+"\nDIFICULTAD: "+ dataEspeciales[0].getDifficulty();
        Difficulty.text =  value;
    }

    private void prueba1(){
        textoPantalla.text = dataEspeciales[1].getDescription();
        string value = dataEspeciales[1].getTitle()+"\nDIFICULTAD: "+ dataEspeciales[1].getDifficulty();
        Difficulty.text =  value;
    }

    //--------------------------------------------------PRIMARIAS MS-------------------------------------------------------------//

    private void printMisionP(Missions msm){
        MisionP1.text = msm.getTitle();

    }

    private void printMision1P(Missions msm){
        MisionP2.text = msm.getTitle();
    }

    public void changeFlagPrincipal1(){
        pruebaPrincipal();
    }

    public void changeFlagPrincipal2(){
        pruebaPrincipal1();
    }

    private void pruebaPrincipal(){
        textoPantalla.text = dataPrincipal[0].getDescription();

        string value = dataPrincipal[0].getTitle()+"\nDIFICULTAD: "+ dataPrincipal[0].getDifficulty();
        Difficulty.text =  value;
    }

    private void pruebaPrincipal1(){
        textoPantalla.text = dataPrincipal[1].getDescription();

        string value = dataPrincipal[1].getTitle()+"\nDIFICULTAD: "+ dataPrincipal[1].getDifficulty();
        Difficulty.text =  value;
    }

    //----------------------------------------------------SEGUNDARIAS---------------------------------------------------------------

    private void printMisionS(Missions msm){
        MisionS1.text = msm.getTitle();

    }

    private void printMision1S(Missions msm){
        MisionS2.text = msm.getTitle();
    }

    public void changeFlagSegundaria(){
        pruebaSegundaria();
    }

    public void changeFlagSegundaria1(){
        pruebaSegundaria1();
    }

    private void pruebaSegundaria(){
        textoPantalla.text = dataSegundarias[0].getDescription();

        string value = dataSegundarias[0].getTitle()+"\nDIFICULTAD: "+ dataSegundarias[0].getDifficulty();
        Difficulty.text =  value;
    }

    private void pruebaSegundaria1(){
        textoPantalla.text = dataSegundarias[1].getDescription();
        string value = dataSegundarias[1].getTitle()+"\nDIFICULTAD: "+ dataSegundarias[1].getDifficulty();
        Difficulty.text =  value;
    }


}
