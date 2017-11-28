using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KNFramework;
using System;

public class test : MonoBehaviour
{
    public List<testItem> _testList = new List<testItem>();
    public LinkedList<testItem> _testLinkedList = new LinkedList<testItem>();
    private void Start()
    {
        // TestList();
        this.Log(Debuger.DebugColor.Gold, "--------------------------------------------------");
        // TestLinkedList();
    }

    private void TestRemoveAdd()
    {
        for(int i = 0; i < 10; i++)
        {
            _testLinkedList.AddFirst(new testItem(i));
        }

        foreach(var item in _testLinkedList)
        {
            this.Log(Debuger.DebugColor.Blue, item.m_index + "");
            if (item.m_index == 3)
            {
                
            }
        }
    }

    private void TestList()
    {
        this.Log(Debuger.DebugColor.Green, DateTime.Now.ToLongTimeString() + DateTime.Now.Millisecond);
        for (int i = 0; i < 100000; i++)
        {
            testItem ti = new testItem();
            _testList.Add(ti);
        }
        this.Log(Debuger.DebugColor.Green, DateTime.Now.ToLongTimeString() + DateTime.Now.Millisecond);
        for(int i = 0; i < 100000; i++)
        {
            testItem ti = new testItem();
            _testList.Insert(0, ti);
        }
        this.Log(Debuger.DebugColor.Green, DateTime.Now.ToLongTimeString() + DateTime.Now.Millisecond);
        for(int i = 0; i < 100000; i++)
        {
            _testList.RemoveAt(0);
        }
        this.Log(Debuger.DebugColor.Green, DateTime.Now.ToLongTimeString() + DateTime.Now.Millisecond);
        int j = 0;
        foreach (var item in _testList)
        {
            if(j == 50000)
            {
                break;
            }
            j++;
        }
        this.Log(Debuger.DebugColor.Green, DateTime.Now.ToLongTimeString() + DateTime.Now.Millisecond);
    }

    private void TestLinkedList()
    {
        this.Log(Debuger.DebugColor.Red, DateTime.Now.ToLongTimeString() + DateTime.Now.Millisecond);
        for (int i = 0; i < 100000; i++)
        {
            testItem ti = new testItem();
            _testLinkedList.AddLast(ti);
        }
        this.Log(Debuger.DebugColor.Red, DateTime.Now.ToLongTimeString() + DateTime.Now.Millisecond);
        for (int i = 0; i < 100000; i++)
        {
            testItem ti = new testItem();
            _testLinkedList.AddFirst(ti);
        }
        this.Log(Debuger.DebugColor.Red, DateTime.Now.ToLongTimeString() + DateTime.Now.Millisecond);
        for(int i = 0; i < 100000; i++)
        {
            _testLinkedList.RemoveFirst();
        }
        this.Log(Debuger.DebugColor.Red, DateTime.Now.ToLongTimeString() + DateTime.Now.Millisecond);
        int j = 0;
        foreach (var item in _testList)
        {
            if (j == 50000)
            {
                break;
            }
            j++;
        }
        this.Log(Debuger.DebugColor.Red, DateTime.Now.ToLongTimeString() + DateTime.Now.Millisecond);
    }
}

public class testItem
{
    public testItem()
    {

    }

    public testItem(int index)
    {
        m_index = index;
    }

    public int m_index;
}

