using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 世界空间坐标UGUI看向目标相机
/// </summary>
public class WorldCanvasCtrl : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private Camera targetCamera;
    [SerializeField] [Range(0, 3)] private int rotType;


    void Start()
    {
        if (targetCamera == null) targetCamera = Camera.main;
        if (canvas == null) canvas = GetComponent<Canvas>();
        //canvas.renderMode = RenderMode.WorldSpace;
        canvas.worldCamera = targetCamera;
    }


    void Update()
    {
        switch (rotType)
        {
            case 0:
                LookTarget1();
                break;
            case 1:
                LookTarget2();
                break;
            case 2:
                LookTarget3();
                break;
            default:
                break;
        }
    }


    void LookTarget1()
    {
        transform.rotation = targetCamera.transform.rotation;
    }

    void LookTarget2()
    {
        Vector3 targetPos = transform.position - targetCamera.transform.position;
        Quaternion lookAtRotation = Quaternion.LookRotation(targetPos, Vector3.up);
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, lookAtRotation, Time.deltaTime);
    }

    void LookTarget3()
    {
        Vector3 dir = targetCamera.transform.position - this.transform.position;
        dir.Normalize();
        transform.rotation = Quaternion.LookRotation(-dir);
    }
}
