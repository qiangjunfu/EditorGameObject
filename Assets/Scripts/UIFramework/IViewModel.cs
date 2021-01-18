using UnityEngine;


namespace UIFramework.MVVM
{
    public interface IViewModel
    {
        BindProperty<string> Name { get; }
        BindProperty<int> Id { get; }

    }
}