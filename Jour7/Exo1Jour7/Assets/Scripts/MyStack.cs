using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MyStack<T>
{
    private T[] _tab;
    private int _size;
    private int _capacity;

    public int ElementCount
    {
        get
        {
            int count = 0;
            for (int i = 0; i < _tab.GetLength(0); i++)
            {
                if (_tab[i] != null)
                    count++;
            }
            return count;
        }
    }
    public T Last
    {
        get { return GetLastElement(); }
        //set { GetLastElement() = value; }
    }

    private T GetLastElement()
    {
        int indexOfLastElement = 0;
        for (int i = 0; i < _tab.Length; i++)
        {
            if (_tab[i] == null)
            {
                indexOfLastElement = i - 1;
                break;
            }
        }
        return _tab[indexOfLastElement];
    }


    public MyStack()
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
            Array.Copy(temp, _tab, _size);
        }

        for (int i = 0; i < _tab.Length; i++)
        {
            if (_tab[i] == null)
            {
                _tab[i] = toAdd;
                _size++;
                break;
            }
        }
        //_tab[_size] = toAdd;
        //_size++;
    }

    public void PopLast()
    {
        //T lastItem = _tab[_tab.Length - 1];
        int indexOfLastElement = 0;
        for (int i = 0; i < _tab.Length; i++)
        {
            if (_tab[i] == null)
            {
                indexOfLastElement = i - 1;
                break;
            }
        }
        _tab[indexOfLastElement] = default(T);
    }
}