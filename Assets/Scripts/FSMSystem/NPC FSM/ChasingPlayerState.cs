using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NPCFSMSystem
{
    public class ChasingPlayerState : IState
    {
        [SerializeField] private INPC mINPC;
        [SerializeField] private GameObject targetPlayer;


        public ChasingPlayerState() : base()
        {
            stateType = StateType.ChasingPlayer;
        }


        public override void DoBeforeEntering(GameObject player)
        {
            Debug.LogFormat("进入 ChasingPlayerState ");
            targetPlayer = player;
        }

        public override void DoBeforeLeaving()
        {
            Debug.LogFormat("退出 ChasingPlayerState ");
        }

        public override void Reason(GameObject npc, GameObject player)
        {
            if (targetPlayer == null)
            {
                Debug.LogErrorFormat("ChasingPlayerState -> Reason() -> targetPlayer == null ");
                return;
            }

            if (Vector3.Distance(npc.transform.position, targetPlayer.transform.position) > 30)
            {
                npc.GetComponent<INPC>().SetCurrentState(Transition.LostPlayer, null);
            }
            if (Vector3.Distance(npc.transform.position, targetPlayer.transform.position) < 5)
            {
                npc.GetComponent<INPC>().SetCurrentState(Transition.CatchUpPlayer, targetPlayer);
            }
            //或者targetPlayer死亡
        }

        public override void Act(GameObject npc, GameObject player)
        {
            Debug.LogFormat("ChasingPlayerState  追踪敌人------------ ");
            if (targetPlayer == null)
            {
                Debug.LogErrorFormat("ChasingPlayerState -> Act() -> targetPlayer == null ");
                return;
            }
            if (npc == null)
            {
                Debug.LogErrorFormat("npc == null ");
                return;
            }
            if (mINPC == null)
            {
                mINPC = npc.GetComponent<INPC>();
            }

            Vector3 moveDir = targetPlayer.transform.position - npc.transform.position;
            moveDir.y -= 9.8f;

            Quaternion quaternion = Quaternion.Slerp(npc.transform.rotation, Quaternion.LookRotation(moveDir), 5 * Time.deltaTime);
            npc.transform.eulerAngles = new Vector3(0, quaternion.eulerAngles.y, 0);

            //mCharacterController.Move(moveDir.normalized * Time.deltaTime * 2);
            mINPC.Move(moveDir.normalized * Time.deltaTime * 2);
        }

    }
}