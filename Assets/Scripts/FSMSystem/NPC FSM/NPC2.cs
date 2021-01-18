using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace NPCFSMSystem
{
    [RequireComponent(typeof(CharacterController))]
    public class NPC2 : INPC
    {
        [SerializeField] private Transform[] wayPoints;
        [SerializeField] private CharacterController mCharacterController;


        private void Start()
        {
            mCharacterController = GetComponent<CharacterController>();
            Transform[] _waypoints = GameObject.Find("WayPoints").GetComponentsInChildren<Transform>();
            wayPoints = new Transform[_waypoints.Length - 1];
            for (int i = 1; i < _waypoints.Length; i++)
            {
                wayPoints[i - 1] = _waypoints[i];
                Debug.Log(i + "   " + wayPoints[i - 1].name);
            }
            InitFSM();
        }

        private void InitFSM()
        {
            FollowPathState followPathState = new FollowPathState(wayPoints);
            followPathState.AddTransition(Transition.SawPlayer, StateType.ChasingPlayer);

            ChasingPlayerState chasingPlayerState = new ChasingPlayerState();
            chasingPlayerState.AddTransition(Transition.LostPlayer, StateType.FollowingPath);
            chasingPlayerState.AddTransition(Transition.CatchUpPlayer, StateType.AttackPlayer);

            AttackPlayerState attackPlayerState = new AttackPlayerState();
            attackPlayerState.AddTransition(Transition.OutAttackRange, StateType.ChasingPlayer);

            mFSMController = new FSMController();
            mFSMController.AddState(followPathState);
            mFSMController.AddState(chasingPlayerState);
            mFSMController.AddState(attackPlayerState);
        }


        private void Update()
        {
            GameObject go = CheckPlayerByHit();
            if (go != null)
            {
                //Debug.LogFormat("{0} 射线检测到的Player: {1}   ", this.gameObject.name, go.name);
            }
            mFSMController.Update(this.gameObject, go);
        }
        GameObject CheckPlayerByHit()
        {
            //打开地面层 只和角色Layer做碰撞检测
            int layerMask = 1 << LayerMask.NameToLayer("Player"); // == int layerMask_Left = 1 << 9;

            for (int i = 0; i < 14; i++)
            {
                RaycastHit hit;
                int j = i % 2 == 0 ? i / 2 : -i / 2;
                if (Physics.Raycast(transform.position, transform.forward + new Vector3(0, j * 10, 0), out hit, 15F, layerMask))
                {
                    return hit.collider.gameObject;
                }
            }
            return null;
        }


        public override void Move(Vector3 dir)
        {
            mCharacterController.Move(dir);
        }

        public override void Attack(GameObject targetPlayer)
        {
            Debug.LogFormat("攻击  {0}", targetPlayer);
        }
    }
}