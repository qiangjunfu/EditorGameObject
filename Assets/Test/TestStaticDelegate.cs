using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStaticDelegate : MonoBehaviour
{
    public static PickUpItemDelegate PickUpItemEvent;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            Item item = new Item("旗门3", 3, "ItemView", "icon2", 1, "高山回转旗门"); item = new Item("旗门3", 3, "ItemView", "icon2", 1, "高山回转旗门");
            bool b = PickUpItemEvent(item);
            Debug.Log("是否能拾取物品 " + b);
        }
    }
}
