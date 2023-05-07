using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spells : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // DoubleLinkedList linked = new DoubleLinkedList();
        // Spell hechizo1 = new Spell("h1", 3, 4);
        // Spell hechizo2 = new Spell("h2", 3, 4);
        // Spell hechizo3 = new Spell("h3", 3, 4);
        // linked.pushBack(hechizo1);
        // linked.pushBack(hechizo2);
        // linked.pushBack(hechizo3);
        // linked.print_list();
        // Spell hechizo45 = new Spell("h45", 3, 4);
        // linked.addAfter("h1", hechizo45);
        // linked.print_list();
        // linked.remove("h45");
        // linked.print_list();
        ListSpells hechizos = new ListSpells();
        hechizos.addSpell("h1",3,4);
        hechizos.addSpell("h2",3,4);
        hechizos.addSpell("h3",3,4);
        hechizos.printSpells();
        hechizos.addAfter("h1","h45",3,4);
        hechizos.printSpells();
        hechizos.deleteSpell("h45");
        hechizos.printSpells();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

class ListSpells
{
    private DoubleLinkedList listSpells = new DoubleLinkedList();

    public void addSpell(string title,int cost, int level) {
		//stackEmails.add(data);
        listSpells.pushBack(new Spell(title, cost, level));
	}
	
	public 	Node  findSpell(string title) {
		//return (T) stackEmails.top();	 
        return listSpells.find(title);
	}
	
	public void deleteSpell(string title) {
		//stackEmails.delete(); si esta de primero popFront, si esta al final, popBack, sino remove
        listSpells.remove(title);
	}
	
	public int numberSpells() {
		return listSpells.getSize();
    }

    public void printSpells()
    {
        listSpells.print_list();
    }

    public void addAfter(string nodeTitle, string title,int cost, int level)
    {
        Spell newSpell = new Spell(title, cost, level);
        listSpells.addAfter(nodeTitle, newSpell);
    }
}


public class Spell {
	
	private string title;
	//private int difficulty;
    private int cost;
	//private int advance; 
    private int level; 
	
	public Spell(string title,int cost, int level) {
		this.title = title;
		this.cost=cost;
        this.level=level;
	}
    
	
	public string getTitle() {
		return title;
	}

	public int getLevel(){
		return level;
	}

	public int getCost(){
		return cost;
	}

}

////////////////////////////////////////////////////////////////////////////////////////////////////


public class Node
{
    public Spell key;
    public Node next;
    public Node prev;

    public Node(Spell key)
    {
        this.key = key;
        next = null;
        prev = null;
    }
}

public class DoubleLinkedList
{
    public Node head;
    public Node tail;
    private int size;

    public DoubleLinkedList()
    {
        head = null;
        tail = null;
    }

    public int getSize()
    {
        return size;
    }

    public void pushBack(Spell key)
    {
        size++;
        Node node = new Node(key);
        if (tail == null)
        {
            head = tail = node;
            node.prev = null;
        }
        else
        {
            tail.next = node;
            node.prev = tail;
            tail = node;
        }
    }

    public void popBack()
    {
        if (head == null)
        {
            UnityEngine.Debug.LogError("Error, lista vacia");
        }
        if (head == tail)
        {
            head = tail = null;
            size--;
        }
        else
        {
            size--;
            tail = tail.prev;
            tail.next = null;
        }
    }

    public void popFront()
    {
        if (head == null)
        {
            UnityEngine.Debug.LogError("Error, lista vacia");
        }
        head = head.next;
        size--;
        if (head == null)
        {
            tail = null;
        }
    }

    public void pushFront(Spell key)
    {
        size++;
        Node node = new Node(key);
        node.next = head;
        head = node;
        if (tail == null)
        {
            tail = head;
        }
    }

    public void addAfter(string nodeTitle, Spell key) {
        Node node = find(nodeTitle);
        if (node != null) {
            size--;
            Node node2 = new Node(key);
            node2.next = node.next;
            node2.prev = node;
            node.next = node2;
            if (node2.next != null) {
                node2.next.prev = node2;
            }
            if (tail == node) {
                tail = node2;
            }
        } else {
            UnityEngine.Debug.LogError("El nodo de referencia no existe");
        }
    }

    public Node find(string title) {
        Node actual = head;
        while (actual != null) {
            if (actual.key.getTitle() == title) {
                return actual;
            }
            actual = actual.next;
        }
        return null;
    }

    // public void remove(string title)
    // {
    //     Node node = find(node1);
    //     node.next.prev = node.prev;
    //     node.prev.next = node.next;
    // }

    public void remove(string title) {
        Node node = find(title);
        if (node != null) {
            size--;
            if (node.prev != null) {
                node.prev.next = node.next;
            } else {
                head = node.next;
            }
            if (node.next != null) {
                node.next.prev = node.prev;
            } else {
                tail = node.prev;
            }
        } else {
            UnityEngine.Debug.LogError("El nodo a eliminar no existe");
        }
    }

    public void print_list()
    {
        Node actual = head;
        UnityEngine.Debug.Log("[");
        while (actual != null)
        {
            if (actual.next != null)
            {
                UnityEngine.Debug.Log(actual.key.getTitle() + " ");
                actual = actual.next;
            }
            else
            {
                UnityEngine.Debug.Log(actual.key.getTitle());
                actual = actual.next;
            }
        }
        UnityEngine.Debug.Log("]");
    }
}