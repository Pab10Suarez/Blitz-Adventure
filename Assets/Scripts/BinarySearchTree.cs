using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinarySearchTree : MonoBehaviour {
    // Clase Nodo
    class Node {
        public int key;
        public Node parent, leftChild, rightChild;

        public Node(int value) {
            key = value;
            parent = null;
            leftChild = null;
            rightChild = null;
        }
    }

    // Raiz del arbol
    Node root;

    // Insertar un nuevo nodo en el árbol
    void Insert(int value) {
        root = InsertNode(root, value);
    }

    Node InsertNode(Node root, int value) {
        if (root == null) {
            root = new Node(value);
        }
        else if (value < root.key) {
            Node newNode = new Node(value);
            newNode.parent = root;
            root.leftChild = InsertNode(root.leftChild, value);
        }
        else if (value > root.key) {
            Node newNode = new Node(value);
            newNode.parent = root;
            root.rightChild = InsertNode(root.rightChild, value);
        }
        return root; 
    }

    // Buscar un nodo en el árbol
    bool Search(int value) {
        return SearchNode(root, value);
    }

    bool SearchNode(Node root, int value) {
        if (root == null) {
            return false;
        }
        else if (root.key == value) {
            return true;
        }
        else if (value < root.key) {
            return SearchNode(root.leftChild, value);
        }
        else {
            return SearchNode(root.rightChild, value);
        }
    }

    // Recorrido en orden del árbol
    void Inorder(Node root) {
        if (root != null) {
            Inorder(root.leftChild);
            Debug.Log(root.key);
            Inorder(root.rightChild);
        }
    }

    // Llamadas de ejemplo
    void Start() {
        Insert(10);
        Insert(5);
        Insert(15);
        Insert(7);
        Insert(3);

        Debug.Log("Inorder traversal of binary search tree is:");
        Inorder(root);

        Debug.Log("Is 7 present in the binary search tree?");
        Debug.Log(Search(7));
    }
}