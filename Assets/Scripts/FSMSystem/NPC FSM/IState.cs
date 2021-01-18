using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NPCFSMSystem
{
    /// <summary>
    /// 状态转换条件
    /// </summary>
    public enum Transition
    {
        NullTransition = 0,
        /// <summary>
        /// 转换条件: 角色和NPC距离<30米  看见角色,状态由寻路-->追踪角色
        /// </summary>
        SawPlayer,
        /// <summary>
        /// 转换条件: 角色和NPC距离>30米  丢失角色,状态由追踪-->寻路
        /// </summary>
        LostPlayer,
        /// <summary>
        /// 转换条件: 30米>角色和NPC距离>5米  超出攻击范围,状态由攻击-->追踪
        /// </summary>
        OutAttackRange,
        /// <summary>
        /// 转换条件: 角色和NPC距离<5米  追上角色,状态由追踪-->攻击
        /// </summary>
        CatchUpPlayer
    }

    /// <summary>
    /// 状态类型
    /// </summary>
    public enum StateType
    {
        NullState = 0,
        /// <summary>
        /// 状态类型: 寻路状态
        /// </summary>
        FollowingPath,
        /// <summary>
        /// 状态类型: 追踪角色
        /// </summary>
        ChasingPlayer,
        /// <summary>
        /// 状态类型: 攻击角色
        /// </summary>
        AttackPlayer
    }


    public abstract class IState
    {
        protected Dictionary<Transition, StateType> stateDic;
        /// <summary>
        /// 自身状态类型
        /// </summary>
        protected StateType stateType;
        /// <summary>
        /// 获取自身状态类型
        /// </summary>
        public StateType GetStateType { get { return stateType; } }



        public IState()
        {
            stateDic = new Dictionary<Transition, StateType>();
        }


        public void AddTransition(Transition trans, StateType id)
        {
            if (trans == Transition.NullTransition)
            {
                Debug.LogError("trans == Transition.NullTransition");
                return;
            }
            if (id == StateType.NullState)
            {
                Debug.LogError("id == StateID.NullStateID");
                return;
            }

            if (stateDic.ContainsKey(trans))
            {
                Debug.LogErrorFormat("stateDic.ContainsKey(trans) == true   ", stateDic, trans);
                return;
            }

            stateDic.Add(trans, id);
        }

        public void DeleteTransition(Transition trans)
        {
            if (trans == Transition.NullTransition)
            {
                Debug.LogError("trans == Transition.NullTransition");
                return;
            }
            if (!stateDic.ContainsKey(trans))
            {
                Debug.LogErrorFormat("stateDic.ContainsKey(trans) == false   ", stateDic, trans);
                return;
            }

            stateDic.Remove(trans);
        }
        /// <summary>
        /// 通过转换条件获得对应状态
        /// </summary>
        public StateType GetStateByTransition(Transition trans)
        {
            if (stateDic.ContainsKey(trans))
            {
                return stateDic[trans];
            }
            Debug.LogErrorFormat("stateDic.ContainsKey(trans) == false   ", stateDic, trans);
            return StateType.NullState;
        }

        public abstract void DoBeforeEntering(GameObject player);
        public abstract void DoBeforeLeaving();
        public abstract void Reason(GameObject npc, GameObject player);
        public abstract void Act(GameObject npc, GameObject player);

    }
}