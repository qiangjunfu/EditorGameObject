using System.Collections;
using System.Collections.Generic;
using UIFramework.MVVM;
using UnityEngine;

public class ItemViewModel : IViewModel
{
    private BindProperty<string> name;
    private BindProperty<int> id;
    private BindProperty<string> perfabName;
    private BindProperty<string> iconName;
    private BindProperty<int> count;
    private BindProperty<string> describe;


    public BindProperty<string> Name { get => name; }
    public BindProperty<int> Id { get => id; }
    public BindProperty<string> PerfabName { get => perfabName; }
    public BindProperty<string> IconName { get => iconName; }
    public BindProperty<int> Count { get => count; }
    public BindProperty<string> Describe { get => describe; }


    public ItemViewModel(string name, int id, string perfabName, string iconName, int count, string describe)
    {
        this.name = new BindProperty<string>();
        this.id = new BindProperty<int>();
        this.perfabName = new BindProperty<string>();
        this.iconName = new BindProperty<string>();
        this.count = new BindProperty<int>();
        this.describe = new BindProperty<string>();

        this.name.Value = name;
        this.id.Value = id;
        this.perfabName.Value = perfabName;
        this.iconName.Value = iconName;
        this.count.Value = count;
        this.describe.Value = describe;
    }


    public void NameChanged(string name)
    {
        this.name.Value = name;
    }
    public void IdChanged(int id)
    {
        this.id.Value = id;
    }
    public void PerfabNameChanged(string perfabName)
    {
        this.perfabName.Value = perfabName;
    }
    public void IconNameChanged(string iconName)
    {
        this.iconName.Value = iconName;
    }
    public void CountChanged(int count)
    {
        this.count.Value = count;
    }
    public void DescribeChanged(string describe)
    {
        this.describe.Value = describe;
    }
}

