using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NPCFSMSystem
{
    public class FSMController
    {
        private List<IState> states;
        private IState currentState;
        public IState CurrentState { get { return currentState; } }


        public FSMController()
        {
            states = new List<IState>();
        }


        public void FixedUpdate() { }
        public void Update(GameObject npc, GameObject player)
        {
            currentState.Reason(npc, player);
            currentState.Act(npc, player);
        }


        /// <summary>
        /// 修改当前状态
        /// </summary>
        public void SetCurrentState(Transition trans, GameObject _targetPlayer)
        {
            if (trans == Transition.NullTransition)
            {
                Debug.LogError("trans == Transition.NullTransition");
                return;
            }

            StateType nextStateType = currentState.GetStateByTransition(trans);
            if (nextStateType == StateType.NullState)
            {
                Debug.LogErrorFormat("nextStateType  == StateType.NullState");
                return;
            }

            for (int i = 0; i < states.Count; i++)
            {
                if (states[i].GetStateType == nextStateType)
                {
                    //先调用旧状态离开函数
                    currentState.DoBeforeLeaving();
                    //将当前状态改为新状态
                    currentState = states[i];
                    //调用新状态进入函数
                    currentState.DoBeforeEntering(_targetPlayer);
                    break;
                }
            }
        }

        public void AddState(IState state)
        {
            if (state == null)
            {
                Debug.LogError("FSM ERROR: Null reference is not allowed");
            }

            if (states.Count == 0)
            {
                states.Add(state);
                currentState = state;
                currentState.DoBeforeEntering(null);
                return;
            }

            for (int i = 0; i < states.Count; i++)
            {
                if (states[i].GetStateType == state.GetStateType)
                {
                    Debug.LogErrorFormat("states[i].GetStateType == state.GetStateType", states[i].GetStateType, state.GetStateType);
                    return;
                }
            }
            states.Add(state);
        }
        public void DeleteState(IState state)
        {
            if (!states.Contains(state))
            {
                Debug.LogErrorFormat(" states.Contains(state) == false");
                return;
            }
            states.Remove(state);
        }
        public void DeleteState(StateType stateType)
        {
            if (stateType == StateType.NullState)
            {
                Debug.LogErrorFormat(" stateType == StateType.NullState");
                return;
            }
            for (int i = 0; i < states.Count; i++)
            {
                if (states[i].GetStateType == stateType)
                {
                    DeleteState(states[i]);
                }
            }
            Debug.LogErrorFormat("列表中不包含要删除的状态类型: {0} ", stateType);
        }

        public void OnDestroy() { }
        public void OnApplicationQuit() { }

    }
}