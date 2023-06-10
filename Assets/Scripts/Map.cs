using UnityEngine;

public class Map : MonoBehaviour
{

    linkedList lista = new linkedList();
    travelMap mapa = new travelMap();
    // Start is called before the first frame update
    void Start()
    {
        Region r1 = new Region("Suba",3);
        Region r2 = new Region("Antonio nariño",5);
        Region r3 = new Region("Chapinero",4);
        Region r4 = new Region("Julio",6);
        Region r5 = new Region("Paloquemado",2);

        lista.push(r1);
        lista.push(r2);
        lista.push(r3);
        lista.push(r4);
        lista.push(r5);

        mapa.setRegions(lista);
        mapa.createTree();
        Debug.Log(mapa.search(r4,r5));
        

        mapa.travelRegions();

        //mapa.imprimir();
        

    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}

class travelMap
{
    private Node root;
    private linkedList regions;
    private linkedList TravelRegions = new linkedList();

    class Node{

        private Node parent;
		private Node right;
		private Node left;
		private Region key;
		private int Height;

        public Node(Region region){
            this.key = region;
        }

        public void setParent(Node parent){
            this.parent = parent;
        }
        public Node getParent(){
            return this.parent;
        }
        public void setRight(Node right){
            this.right = right;
        }
        public Node getRight(){
            return this.right;
        }
        public void setLeft(Node left){
            this.left = left;
        }
        public Node getLeft(){
            return this.left;
        }
        public void setKey(Region key){
            this.key = key;
        }
        public Region getKey(){
            return this.key;
        }
        public void setHeight(int Height){
            this.Height = Height;
        }
        public int getHeight(){
            return this.Height;
        }
    }


	public void createTree() {
        while(regions.Top()!=null){
            Region v = regions.PopFront();
            arbol(v);
        }
	}

    public void raiz(){
        Debug.Log("raiz"+root.getKey().getId());
    }

    private void arbol(Region r){
        root = insert(root,r);
    }

    private Node insert(Node node, Region key) {
        if (node == null) {
            return new Node(key);
        } else if (node.getKey().getId()>key.getId()) {
            node.setLeft(insert(node.getLeft(), key));
            Node aux = node.getLeft();
            aux.setParent(node);
        } else if (node.getKey().getId()<key.getId()) {
            node.setRight(insert(node.getRight(), key));
            Node aux = node.getRight();
            aux.setParent(node);
        } else {
            Debug.Log("duplicate Key!");
        }
        return rebalance(node);
    }

	private Node rebalance(Node z) {
        updateHeight(z);
        int balance = getBalance(z);
        if (balance > 1) {
            if (height(z.getRight().getRight()) > height(z.getRight().getLeft())) {
                z = rotateLeft(z);
            } else {
                z.setRight(rotateRight(z.getRight()));
                z = rotateLeft(z);
            }
        } else if (balance < -1) {
            if (height(z.getLeft().getLeft()) > height(z.getLeft().getRight())) {
                z = rotateRight(z);
            } else {

                z.setLeft(rotateLeft(z.getLeft()));
                z = rotateRight(z);
            }
        }
        return z;
    }
    private void updateHeight(Node n) {
        int value = 1 + System.Math.Max(height(n.getLeft()), height(n.getRight()));
        n.setHeight(value);
    }

    private int height(Node n) {

        if(n==null){
            return -1;
        }
        return n.getHeight();
    }

	 private int getBalance(Node z) {	
		 if(z==null) {
			 return 0;
		 }
		 return height(z.getRight()) - height(z.getLeft());
	}


    private Node rotateRight(Node y) {
        Node x = y.getLeft();
        Node z = x.getRight();
        x.setRight(y);
        y.setLeft(z);
        y.setParent(x);
        updateHeight(y);
        updateHeight(x);
        return x;
    }

    private Node rotateLeft(Node y) {
        Node x = y.getRight();
        Node z = x.getLeft();
        x.setLeft(y);
        y.setRight(z);
        y.setParent(x);
        updateHeight(y);
        updateHeight(x);
        return x;
    }
    
    public int search(Region x,Region y) {
    	Node N = find(x);

    	if(y.getId()==N.getKey().getId()) {
    		return 1;
    	}
    	else if(N.getRight()==null && N.getLeft()==null) {
    		return 1 + search(N.getParent().getKey(),y);
    	}
		int value = minimo(N,y);
		if(value>0) {
			return value;
		}
        TravelRegions.push(N.getKey());
    	return 1 + search(N.getParent().getKey(),y);

    }

    private Node find(Region key) {
        Node current = root;
        while (current != null) {
            if (current.getKey().getId()==key.getId()) {
               break;
            }
            else if(current.getKey().getId()<key.getId()) {
            	current = current.getRight();
            }
            else {
            	current = current.getLeft();
            }
        }
        return current;
    }

    private int minimo(Node z, Region y) {
        Node aux;
        if(z==null) {
            return -1000;
        }else if(z.getKey().getId()==y.getId()){
            return 1;
        }else if(y.getId()<z.getKey().getId()) {
            aux = min(z);
            if(aux.getKey().getId()>y.getId()) return -1000;
            TravelRegions.push(z.getKey());
            z.getKey().setFormTravel(true);
            return 1 + minimo(z.getLeft(),y);
        }else if(y.getId()>z.getKey().getId()) {
            aux = max(z);
            if(aux.getKey().getId()<y.getId()) return -1000;
            TravelRegions.push(z.getKey());
            z.getKey().setFormTravel(true);
            return 1 + minimo(z.getRight(),y);
        }

        return 0;
    }

    private Node min(Node z) {
    	while(z.getLeft()!=null) {
    		 z = z.getLeft();
    	}
    	return z;
    }
    
    private Node max(Node z) {
    	while(z.getRight()!=null) {
    		 z = z.getRight();
    	}
    	return z;
    }

        
	public void imprimir() {
		 
		 InOrderTraversal(root);
	 }
	 
	 private void InOrderTraversal(Node raiz) {
		 
		 if(raiz==null) {
			 return;
		 }
		 InOrderTraversal(raiz.getLeft());
		 Debug.Log(raiz.getKey().getName()+" ");
		 InOrderTraversal(raiz.getRight()); 
	 } 

    
    public void setRegions(linkedList regions) {
		this.regions = regions;
	}
	
	public linkedList getRegions(){
		return regions;
	}

    public void travelRegions(){
        while(TravelRegions.Top()!=null){
            Region v = TravelRegions.PopFront();
            Debug.Log(v.getName());
        }
    }
}

class Region 
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

class linkedList
{

    private Node head;
    private Node tail;

    class Node 
    {
        private Node next;
        private Region region;

        public Node(Region r){
            this.region = r;
        }

        public Region getRegion() {
		    return region;
	    }
        public Node getNext() {
            return next;
        }
        public void setNext(Node next) {
            this.next = next;
        }
    }

    public bool empty() { 
        
        return head==null;
    }

    public void push(Region data) { 
    
        if(empty()) {
            head = new Node(data);
            tail= head;
            return;
        }
        tail.setNext(new Node(data));
        tail = tail.getNext();
	}

    public Region PopFront() {
		Region r = null;
		if(!empty()) {
            r = head.getRegion();
            head = head.getNext();
		}

        return r;
	}

    public Region Top(){
        if(head!=null){
            return head.getRegion();
        }
        return null;
    }

}
