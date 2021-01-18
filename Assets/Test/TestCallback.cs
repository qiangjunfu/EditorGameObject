using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCallback : MonoBehaviour
{
    public Test1 test1;

    private void Start()
    {
        test1.Test(T1);
    }

    private void Update()
    {
        test1.Test(T1);
    }

    private void T1(bool isStart)
    {
        Debug.Log("11111111");
    }
}


