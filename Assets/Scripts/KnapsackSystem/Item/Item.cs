using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Item
{
    public string name;
    public int id;
    public string perfabName;
    public string iconName;
    public int count;
    public string describe;


    public Item() { }
    public Item(string name, int id, string perfabName, string iconName, int count, string describe)
    {
        this.name = name;
        this.id = id;
        this.perfabName = perfabName;
        this.iconName = iconName;
        this.count = count;
        this.describe = describe;
    }


    public override string ToString()
    {
        string str = $"name:{name } , id:{id} , perfabName:{perfabName } , iconName:{iconName } , count:{count } , describe:{describe }";
        return str;
    }
}
