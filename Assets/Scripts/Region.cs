using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Region : MonoBehaviour
{
    private string name;
	private int id;
	private bool formTravel;
	
	
	public Region(string name,int id) {
		
		this.name = name;
		this.id = id;
		this.formTravel= false;
	}
	public string getName() {
		return name;
	}
	public void setName(string name) {
		this.name = name;
	}
	public int getId() {
		return id;
	}
	public void setId(int id) {
		this.id = id;
	}
	public bool isFormTravel() {
		return formTravel;
	}
	public void setFormTravel(bool formTravel) {
		this.formTravel = formTravel;
	}

    
}
