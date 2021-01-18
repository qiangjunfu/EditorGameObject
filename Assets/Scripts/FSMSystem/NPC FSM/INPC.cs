using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPCFSMSystem
{
    public class INPC : MonoBehaviour
    {
        [SerializeField] protected FSMController mFSMController;



        public virtual void Move(Vector3 dir) { }
        public virtual void Attack(GameObject targetPlayer) { }



        /// <summary>
        /// 执行状态转换
        /// </summary>
        public void SetCurrentState(Transition trans, GameObject _targetPlayer)
        {
            if (mFSMController == null)
            {
                Debug.LogErrorFormat("mFSMController  == null");
                return;
            }
            mFSMController.SetCurrentState(trans, _targetPlayer);
        }
    }
}