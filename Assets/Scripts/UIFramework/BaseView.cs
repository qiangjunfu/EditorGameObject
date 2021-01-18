using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UIFramework.MVVM
{
    public abstract class BaseView<VM> : MonoBehaviour where VM : IViewModel
    {
      
        public abstract void BindViewModel(VM viewModel);


    }

}