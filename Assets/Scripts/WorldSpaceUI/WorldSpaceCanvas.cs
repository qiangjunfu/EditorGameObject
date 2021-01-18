using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WorldSpaceCanvas : MonoBehaviour
{

    public virtual void OpenCanvas()
    {
        this.gameObject.SetActive(true);
    }
    public virtual void CloseCanvas()
    {
        this.gameObject.SetActive(false);
    }
}