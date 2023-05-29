using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;	
using TMPro;

public class email : MonoBehaviour
{
	public Animator animator;
	public RectTransform cartaprefab;
	Vector3 Posicionsiguientecarta;
	public Button btnClick;
	private bool oprimidoabrir;
	private bool oprimidoexit;
	private int numberEmail;
    private stack stackEmails = new stack();
    // Start is called before the first frame update
    void Start()
    {
		oprimidoabrir=false;
        btnClick.onClick.AddListener(botonabrirOprimido);
		Missions misionprueba=new Missions("Bienvenido!","Hola, bienvenido a Blitz Land, espero que disfrutes la estadia en tu nueva casa, ya que veo que eres nuevo por aca te mostraré el lugar",0);
		addMessage(misionprueba);
		Missions misionprueba2=new Missions("Ayuda en el vecindario","Necesito que me ayudes con algo lo mas pronto posible.\n-Gil (tu nuevo vecino)",0);
		addMessage(misionprueba2);
		Posicionsiguientecarta=cartaprefab.position;
	}
	void Update() {
		// si el boton es oprimido vuelve la carta visible, tambien revisa si hay cartas en el stack
		if(oprimidoabrir&&!stackEmails.empty()){
			//Va creando instancias del prefab carta para cada uno de las cartas que haya en el stack
			for(int i=0;i<stackEmails.Size();i++){
				GameObject cartainstanciada=Instantiate(cartaprefab).gameObject;
				writeMessage(cartainstanciada);
				// hace el boton next visible
				if(!stackEmails.empty()){
					GameObject btnnextmessage=cartainstanciada.transform.Find("Next").gameObject;
					btnnextmessage.transform.GetComponent<Button>().onClick.AddListener(botonsiguienteOprimido);
					btnnextmessage.SetActive(true);
				}
				//sino hace el boton de salida visible
				else{
					GameObject btnexit=cartainstanciada.transform.Find("Exit").gameObject;
					btnexit.transform.GetComponent<Button>().onClick.AddListener(botonsalirOprimido);
					btnexit.SetActive(true);
				}
				cartainstanciada.transform.SetParent(transform);
				cartainstanciada.transform.position=Posicionsiguientecarta;
				Debug.Log(Posicionsiguientecarta.x);
				cartainstanciada.transform.localScale=new Vector3(1,1,1);
				cartainstanciada.SetActive(true);
				Posicionsiguientecarta=new Vector3(Posicionsiguientecarta.x+15,Posicionsiguientecarta.y,Posicionsiguientecarta.z);
			}
		}
		if(oprimidoexit){
			 foreach (Transform child in transform) {
				GameObject.Destroy(child.gameObject);
			}
		}
	}
	void FixedUpdate() {
	}
	public void writeMessage(GameObject carta){
		//Escribe el mensaje en el prefab de una carta
			GameObject Titulo=carta.transform.Find("Titulo").gameObject; // encuentra al "niño"
			GameObject Descripcion=carta.transform.Find("Descripcion").gameObject;
			Missions ultimamision=getMessage();
			Titulo.transform.GetComponent<TextMeshProUGUI>().text=ultimamision.getTitle();
			Descripcion.transform.GetComponent<TextMeshProUGUI>().text=ultimamision.getDescription();
	}
    public void addMessage(Missions data) {
		stackEmails.add(data);
	}
	public 	Missions  getMessage() {
	 	return  stackEmails.delete();	
	}
	
	public void deleteMessege() {
		stackEmails.delete();
	}
	
	public int numberMessage() {
		return stackEmails.Size();
    }
	public void botonabrirOprimido(){
		oprimidoabrir=true;
	}
	public void botonsiguienteOprimido(){
		animator.SetTrigger("nextMessage");
	}
	public void botonsalirOprimido(){
		oprimidoexit=true;
	}

}

class stack {
	
	private Node head;
	private Node tail;
	private int size;
	
	class Node{
		private Node next;
		private Missions data;
		
		public Node(Missions data) {
			this.data = data;
		}

        public void setNext(Node next){
            this.next = next;
        }

        public Node getNext(){
            return next;
        }

        public Missions getData(){
            return data;
        }
	}
	
	public bool empty() {
		return head == null;
	}
	
	public void add(Missions data) {
		
		size++;
		
		if(empty()) {
			head = new Node(data);
			return;
		}
		
		tail = head;
		head = new Node(data);
		head.setNext(tail);
	}
	
	public Missions delete() {
		Missions data = default(Missions);
		size --;
		if(!empty()) {
			data = head.getData();
			head = head.getNext();
		}
		return data;
	}
	
	public Missions top() {
		Missions data = default(Missions);
		if(!empty()) {
			data = head.getData();
		}
		return data;
	}
	
	public int Size() {
		return size;
	}
}
public class Missions {
	private string title;
	private string description;
	private int difficulty;
	
	private int advance; 
	
	public Missions(){

	}
	public Missions(string title,string description,int difficulty) {
		this.title = title;
		this.description=description;
		this.difficulty=difficulty;
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
	public string getDescription(){
		return description;
	}

}
