using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stack<T> : MonoBehaviour
{
    private class Node
    {
        public T value { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }

        public Node(T t)
        {
            value = t;
            Next = null;
            Previous = null;
        }
    }

    private Node head;
    private Node top;
    private int length = 0;

    public void Push(T newData)
    {
        Node newNode = new Node(newData);

        if (head == null)
        {
            head = newNode;
            top = newNode;
        }
        else
        {
            newNode.Previous = top;
            top.Next = newNode;
            top = newNode;
        }

        length++;
    }

    public T Pop()
    {
        if (length == 0)
        {
            Debug.Log("Pila vacia");
            return default;
        }

        T value = top.value;

        if (top.Previous != null)
        {
            top = top.Previous;
            top.Next = null;
        }
        else
        {
            top = null;
            head = null;
        }

        length--;
        return value;
    }

    public T Peek()
    {
       if(length == 0)
        {
            Debug.Log("Pila vacia");
        }

        return top.value;
    }

    public int Count()
    {
        return length;
    }

    public void Clear()
    {
        head = null;
        top = null;
        length = 0;
    }
}
