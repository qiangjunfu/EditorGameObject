using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void StartGameDelegate(bool isStart);
public class Test1 : MonoBehaviour
{
    public bool isStart;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown ( KeyCode.Q))
        {
            isStart = true;
        }
        if (Input.GetKeyDown ( KeyCode.W ))
        {
            isStart = false;
        }
    }


    public void Test (StartGameDelegate startGameDelegate )
    {
        if (isStart )
        {
            startGameDelegate(isStart);
            isStart = false;
        }
    }
}
