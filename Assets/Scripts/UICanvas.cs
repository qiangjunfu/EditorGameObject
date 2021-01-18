using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvas : MonoBehaviour
{
    [SerializeField] private KnapsackView knapsackView;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public KnapsackManager GetKnapsackManager()
    {
        return knapsackView.GetKnapsackManager;
    }
}
