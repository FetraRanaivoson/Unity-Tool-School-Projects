using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack<T>
{
    private T[] _tab;
    private int _size;
    private int _capacity;

    public Stack()
    {
        _capacity = 10;
        _tab = new T[_capacity];
    }

    public void Add(T toAdd)
    {
        if (_size == _capacity)
        {
            T[] temp = _tab;
            _capacity += 10;
            _tab = new T[_capacity];
            Array.Copy(temp,_tab,_size);
        }

        _tab[_size] = toAdd;
        _size++;
    }
}
