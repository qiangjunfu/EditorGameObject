using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NPCFSMSystem
{
    public class AttackPlayerState : IState
    {
        [SerializeField] private INPC mINPC;
        [SerializeField] private GameObject targetPlayer;

        public AttackPlayerState() : base()
        {
            stateType = StateType.AttackPlayer;
        }

        public override void DoBeforeEntering(GameObject player)
        {
            Debug.LogFormat("进入 AttackPlayerState ");
            targetPlayer = player;
        }

        public override void DoBeforeLeaving()
        {
            Debug.LogFormat("退出 AttackPlayerState ");
        }

        public override void Reason(GameObject npc, GameObject player)
        {
            if (targetPlayer == null)
            {
                Debug.LogErrorFormat("AttackPlayerState -> Reason() -> targetPlayer == null ");
                return;
            }

            if (Vector3.Distance(npc.transform.position, targetPlayer.transform.position) > 5)
            {
                npc.GetComponent<INPC>().SetCurrentState(Transition.OutAttackRange, targetPlayer);
            }
        }


        public override void Act(GameObject npc, GameObject player)
        {
            if (targetPlayer == null)
            {
                Debug.LogErrorFormat("AttackPlayerState -> Act() -> targetPlayer == null ");
                return;
            }
            if (npc == null)
            {
                Debug.LogErrorFormat("AttackPlayerState -> Act() -> npc == null ");
                return;
            }
            if (mINPC == null)
            {
                mINPC = npc.GetComponent<INPC>();
            }
            mINPC.Attack(targetPlayer);
        }
    }
}