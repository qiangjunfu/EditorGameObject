using RTG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    //[SerializeField] private Camera mainCamera;
    [SerializeField] private GizmoManager gizmoManager3;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gizmoManager3.gameObject.activeSelf)
            {
                gizmoManager3.Close();
            }
            else
            {
                gizmoManager3.Open();
            }
        }

        if (Input.GetMouseButtonDown(1) )
        {
#if UNITY_ANDROID || UNITY_IPHONE
                if (EventSystem .current .IsPointerOverGameObject (Input.GetTouch (0).fingerId ))
#elif UNITY_STANDALONE
            if (EventSystem.current.IsPointerOverGameObject())
#endif
            {
                Debug.Log($"当前点击在UI上: {EventSystem.current.currentSelectedGameObject}");
            }
            else
            {
                ItemObject  itemObject= UnityUtility.UITool.GetObjComponentByRay<ItemObject >(Camera.main);
                if (itemObject != null)
                {
                    itemObject.OpenRecycleCanvas();
                }
            }
        }

    }
}
