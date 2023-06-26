using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrafoMatrix : MonoBehaviour
{
    // Start is called before the first frame update
    private grafoMatrix grafoRegion = new grafoMatrix(5);
    void Start()
    {
        Region r1 = new Region("Bogota",2);
        Region r2 = new Region("Cali",23);
        Region r3 = new Region("Sibundoy",28);
        Region r4 = new Region("Manizales",34);
        Region r5 = new Region("Barranquilla",1);
        
        grafoRegion.addVertice(r1);
        grafoRegion.addVertice(r2);
        grafoRegion.addVertice(r3);
        grafoRegion.addVertice(r4);
        grafoRegion.addVertice(r5);

        grafoRegion.addArista(r1,r2);
        grafoRegion.addArista(r2,r3);
        grafoRegion.addArista(r3,r5);
        grafoRegion.addArista(r2,r5);

        
        //grafoRegion.viewAdy();
        //grafoRegion.calcularIndigree();
        grafoRegion.shortPath(r1,r5);
        //grafoRegion.viewIndegree();
        //Debug.Log(grafoRegion.size());
    }
}

public class grafoMatrix
{
    private int [,] matrixAdya;
    private int []  indegrre;
    private Region[] dataGraph;
    private int nodos;
    private int index;
    private string result;

    public grafoMatrix(){

        matrixAdya = new int[10,10];
        indegrre = new int[10];
        dataGraph = new Region[10];
        this.nodos = 10;

    }

    public grafoMatrix(int nodos){

        matrixAdya = new int[nodos,nodos];
        indegrre = new int[nodos];
        dataGraph = new Region[nodos];
        this.nodos = nodos;
    }

    public void addArista(Region pInicio,Region pFinal){
        int n = Find(pInicio);
        int i = Find(pFinal);

        //Debug.Log(n + "| "+i);

        if(n<matrixAdya.Length && n<matrixAdya.Length){
            matrixAdya[n,i] = 1;
            matrixAdya[i,n] = 1;
        }
    }

    public void addVertice(Region data){
        if(index<dataGraph.Length){
            dataGraph[index++] = data;
            return;
        }
        Debug.Log("Full Array");
    }

    public Region getValue(Region value){
        Region dato = default(Region);
        for(int n=0;n<dataGraph.Length;n++){
            if(dataGraph[n].getId()==value.getId()){
                dato = dataGraph[n];
                break;
            }
        }
        return dato;
    }

    public int Find(Region value){
        int i =-1;
        for(int n=0;n<dataGraph.Length;n++){
            if(dataGraph[n].getId()==value.getId()){
                i = n;
                break;
            }
        }
        return i; 
    }

    public void viewAdy(){
        
        string chain ="";
        for(int i=0;i<nodos;i++){
            chain = "";
            for(int n=0;n<nodos;n++){
                chain += matrixAdya[i,n].ToString()+" ";
            }
            Debug.Log(chain);
        }
    }

    public int saarchIndegre(){

        bool flag =false;
        int n=0;

        for(n=0;n<nodos;n++){
            if(indegrre[n]==0){
                flag = true;
                break;
            }
        }

        if(flag) return n;
        return -1;
    }

    public int size(){
        return index;
    }

    public void viewIndegree(){
        int n=0;
        for(n=0;n<nodos;n++){
            Debug.Log(dataGraph[n].getName()+"<--"+indegrre[n]);
        }
    }

    public void calcularIndigree(){ //Metodo para saber cuantos vertices tienen conexion con n vertice
        int n=0;
        int m=0;

        for(n=0;n<nodos;n++){
            for(m=0;m<nodos;m++){
                if(matrixAdya[n,m]==1) indegrre[n]++;
            }
        }
    }

    public int obtainAdy(int row,int column){
        return matrixAdya[row,column];
    }

    private void decrementIndegree(int value){
        indegrre[value] = -1;
        int n=0;
        for(n=0;n<nodos;n++){
            if(matrixAdya[value,n]==1) indegrre[n]--;
        }
    }

    public void shortPath(Region star,Region end){

        int inicio = Find(star);
        int Final = Find(end);
        int distance =0;
        int n=0;
        int m=0;

        int[,] table = new int[nodos,3];

        for(n=0;n<nodos;n++){
            table[n,0]=0;
            table[n,1]=int.MaxValue;
            table[n,2]=0;
        }

        table[inicio,1]=0;
        //viewTable(table);

        for(distance=0; distance<nodos;distance++){
            for(n=0;n<nodos;n++){
                if((table[n,0]==0) && (table[n,1] ==distance)){
                    table[n,0]=1;

                    for(m=0;m<nodos;m++){
                        if(obtainAdy(n,m)==1){
                            if(table[m,1] == int.MaxValue){
                                table[m,1] = distance +1;
                                table[m,2]=n;
                            }
                        }
                    }
                }
            }
        }

        viewTable(table);

        List<int> rut = new List<int>();
        int nodo=Final;

        while(nodo !=inicio){
            rut.Add(nodo);
            nodo = table[nodo,2];
        }

        rut.Add(inicio);
        rut.Reverse();

        string rutaa = "";
        foreach(int posicion in rut){
            dataGraph[posicion].setFormTravel(true);
            rutaa += dataGraph[posicion].getName()+" ";
        }

        //Debug.Log(rutaa);
        this.result = rutaa;
    }

    public string totalReccorrido(){
        return this.result;
    }


    private void viewTable(int[,] ptable){

        int n=0;
        for(n=0;n<ptable.GetLength(0);n++){
            Debug.Log(dataGraph[n].getName()+" -- "+ptable[n,0]+"  "+ptable[n,1]+"  "+ptable[n,2]);
        }

    }
}
