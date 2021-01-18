using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NPCFSMSystem
{
    public class FollowPathState : IState
    {
        [SerializeField] private INPC mINPC;
        [SerializeField] private GameObject targetPlayer;
        [SerializeField] private int currentWayPoint;
        [SerializeField] private Transform[] wayPoints;

        public FollowPathState(Transform[] waypoints) : base()
        {
            wayPoints = waypoints;
            currentWayPoint = 0;
            stateType = StateType.FollowingPath;
        }


        public override void DoBeforeEntering(GameObject player)
        {
            Debug.LogFormat("进入 FollowPathState ");
        }

        public override void DoBeforeLeaving()
        {
            Debug.LogFormat("退出 FollowPathState ");
        }

        public override void Reason(GameObject npc, GameObject player)
        {
            if (player != null) //只有有目标角色才转换
            {
                targetPlayer = player;

                npc.GetComponent<INPC>().SetCurrentState(Transition.SawPlayer, targetPlayer);
            }
        }



        public override void Act(GameObject npc, GameObject player)
        {
            Debug.LogFormat("FollowPathState  自动寻路------------ ");
            if (npc == null)
            {
                Debug.LogErrorFormat("npc == null ");
                return;
            }
            if (mINPC == null)
            {
                mINPC = npc.GetComponent<INPC>();
            }

            Vector3 moveDir = wayPoints[currentWayPoint].position - npc.transform.position;
            Vector3 dir = moveDir.normalized;
            dir.y -= 9.8f;

            if (moveDir.magnitude < 1.5f)
            {
                currentWayPoint++;
                if (currentWayPoint >= wayPoints.Length)
                {
                    currentWayPoint = 0;
                }
            }
            else
            {
                Quaternion quaternion = Quaternion.Slerp(npc.transform.rotation, Quaternion.LookRotation(moveDir), 5 * Time.deltaTime);
                npc.transform.eulerAngles = new Vector3(0, quaternion.eulerAngles.y, 0);
            }

            //mCharacterController.Move(moveDir.normalized * Time.deltaTime * 5);
            //mCharacterController.Move(dir * Time.deltaTime * 2);
            mINPC.Move(dir * Time.deltaTime * 2);
        }

    }
}