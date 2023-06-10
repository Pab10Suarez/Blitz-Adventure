using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missions : MonoBehaviour
{
	
	private string title;
    public string description;
	private int difficulty;
	private int advance;
	private int priority;
	private string type;
	private int id;
	 
	
	public Missions(int id,string title,int difficulty) {
		this.title = title;
		this.difficulty=difficulty;
		this.id = id;
		setPriority();
	}
    	
	public string getTitle() {
		return title;
	}

	public void setAdvance(int advance){
		this.advance = advance;
	}

	public int getAdvance(){
		return advance;
	}

	public int getDifficulty(){
		return difficulty;
	}

	public int getPriority(){
		return priority;
	}
    public string getDescription(){
        return description;
    }

	private void setPriority(){
		int value = UnityEngine.Random.Range(1,4);
		if(value==1) setType("Segundaria");
		else if (value==2) setType("Primaria");
		else setType("Especial");
		this.priority = value;
	}

	public void setPriorit(int val){
		this.priority = val;
	}

	public void setType(string type){
		this.type = type;
	}

	public string getType(){
		return this.type;
	}

	public int getID(){
		return this.id;
	}
}
