using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PlayerFSMSystem
{
    public class ICharacter : MonoBehaviour
    {
        public virtual void Move(Vector3 dir) { }
        public virtual void Attack(GameObject targetPlayer) { }



        /// <summary>
        /// 执行状态转换
        /// </summary>
        //public void PerformStateTransition(Transition trans, GameObject _targetPlayer)
        //{
        //    //if (mFSMController == null)
        //    //{
        //    //    Debug.LogErrorFormat("mFSMController  == null");
        //    //    return;
        //    //}
        //    //mFSMController.PerformStateTransition(trans, _targetPlayer);
        //}


    }
}