using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridView : MonoBehaviour
{
    [SerializeField] private Grid grid;
    public Grid GetGrid { get => grid; }


    public void SetGrid(Grid grid)
    {
        this.grid = grid;
    }


}
