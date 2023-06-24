using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TablaHashMapa : MonoBehaviour
{
    public Region r;
    private TableHash<string,Region> data = new TableHash<string, Region>();

    public void add(string key,Region value){
        r = value;
        data.put(key,r);
    }

    public Region getValue(string key){
        r=data.get(key);
        return r;
    }
}

class TableHash<K, V> : IMap<K, V>
{
    private HashNode<K,V>[] table;
	private int Size;
	private int capacity;
    private K value;

    public TableHash() {
        this.capacity = 10;
		this.table = new HashNode<K,V>[this.capacity];
		this.Size = 0;
	}
	
	public TableHash(int capacity) {
		this.capacity = capacity;
		this.table = new HashNode<K,V>[this.capacity];
		this.Size = 0;
	}



    public  void put(K key,V value) {
        this.value = key;
		int index = this.index(GetHashCode());
		HashNode<K,V> chain = this.table[index];
		HashNode<K,V> head = this.table[index];
		HashNode<K,V> node = new HashNode<K,V>(key,value);
		node.setNext(head);
		
		while(chain !=null) {
			if(chain.getKey().Equals(key)) {
				chain.setValue(value);
				return;
			}
			
			chain = chain.getNext();
		}
		
		this.table[index] = node;
		this.Size++;
		rehashing();
	}

    public V remove(K key) {
        this.value = key;
		int index = this.index(GetHashCode());
		HashNode<K,V> chain = this.table[index];
		HashNode<K,V> head = this.table[index];
		HashNode<K,V> prev = null;
		
		while(chain !=null) {
			if(chain.getKey().Equals(key)) {
				break;
			}
			prev = chain;
			chain = chain.getNext();
		}
		
		V value = default(V);
		if(chain==null) return default(V);
		else if(prev !=null) {
			value = chain.getValue();
			prev.setNext(chain.getNext());
		}else {
			value = chain.getValue();
			this.table[index] = head.getNext();
		}
		
		Size--;
		return value;
	}

    public V get(K key) {
        this.value = key;
		int index = this.index(GetHashCode());
		HashNode<K,V> chain = this.table[index];
		while(chain !=null) {
			if(chain.getKey().Equals(key)) return chain.getValue();
			chain = chain.getNext();
		}
		
		return default(V);
	}

    public bool hasKey(K key) {
        this.value = key;
        int index = this.index(GetHashCode());
        HashNode<K, V> chain = this.table[index];
        while (chain != null) {
            if(chain.getKey().Equals(key)) return true;
            chain = chain.getNext();
        }
        return false;
    }

    public int size() {
        return this.Size;
    }

    private int index(int hash) {
		int i = hash % capacity;
		i = i<0 ? i*-1: i;
		return i;
	}

    private void rehashing() {
		
		if((Size*1.0)/(capacity*1.0) > 0.9) {
			this.capacity *=2;
			this.Size =0;
			HashNode<K,V>[]  temp = table;
			
			table = new HashNode<K,V>[capacity];
			
			for(int i=0;i<temp.Length;i++) {
				
				HashNode<K,V>  chain = temp[i];
				
				while(chain !=null) {
					this.put(chain.getKey(), chain.getValue());
					chain = chain.getNext();
				}
			}
		}
	}


    public override int GetHashCode()
    {
        return value.GetHashCode();
    }


}

interface IMap<K,V>{

    void put(K key, V value);
    V remove(K key);
    V get(K key);
    bool hasKey(K key);
    int size();
}

class HashNode<K,V> {
	
	private K key;
    private V value;
    private HashNode<K, V> next;

    public HashNode(K key, V value) {
        this.key = key;
        this.value = value;
    }

    public K getKey() {
        return key;
    }

    public void setKey(K key) {
        this.key = key;
    }

    public V getValue() {
        return value;
    }

    public void setValue(V value) {
        this.value = value;
    }

    public HashNode<K, V> getNext() {
        return next;
    }

    public void setNext(HashNode<K, V> next) {
        this.next = next;
    }
}
