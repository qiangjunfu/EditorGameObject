using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace PlayerFSMSystem
{
    /// <summary>
    /// 玩家状态转换条件
    /// </summary>
    public enum PlayerTransition 
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


    public class IPlayerState
    {
        
        
    }
}