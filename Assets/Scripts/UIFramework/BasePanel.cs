using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UIFramework
{
    public class BasePanel : MonoBehaviour
    {

        public virtual void OpenPanel()
        {
            this.gameObject.SetActive(true);
        }
        public virtual void ClosePanel()
        {
            this.gameObject.SetActive(false);
        }

        public virtual void BackStep()
        {

        }
        public virtual void NextStep()
        {

        }

        public virtual void MoveToTop()
        {
            this.transform.SetAsFirstSibling();
        }
        public virtual void MoveToBottom()
        {
            this.transform.SetAsLastSibling();
        }
        

    }
}