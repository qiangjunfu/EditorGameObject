using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;


namespace NetworkSystem.UDP
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    [System.Serializable]
    public struct ReceiveData
    {
        /// <summary>
        /// 场景类型  0:当前场景  1:Bobsleigh单独雪车  2:Skeleton钢架雪车  3:Luge雪橇
        /// </summary>
        public int sceneType;
        /// <summary>
        /// 科目类型
        /// </summary>
        public int subjectType;
        /// <summary>
        /// 初始位置点  (0:原点  1:第二出发点)
        /// </summary>
        public int initPosition;
        /// <summary>
        /// 运行模式  (1:正常运行  2:固定路径运行)
        /// </summary>
        public int runState;
        /// <summary>
        /// 推动力X
        /// </summary>
        public float forceX;
        /// <summary>
        /// 推动力Y
        /// </summary>
        public float forceY;
        /// <summary>
        /// 推动力Z
        /// </summary>
        public float forceZ;
        /// <summary>
        /// 扭矩力X
        /// </summary>
        public float torqueX;
        /// <summary>
        /// 扭矩力Y
        /// </summary>
        public float torqueY;
        /// <summary>
        /// 扭矩力Z
        /// </summary>
        public float torqueZ;
        /// <summary>
        /// 雪车质量
        /// </summary>
        public int mass;
        /// <summary>
        /// 前进空气阻力 
        /// </summary>
        public float drag;
        /// <summary>
        /// 旋转空气阻力
        /// </summary>
        public float angularDrag;
        /// <summary>
        /// 动摩擦力   0-1
        /// </summary>
        public float dynamicFriction;
        /// <summary>
        /// 左冰刀Z轴旋转
        /// </summary>
        public float binDaoRotZ_Left;
        /// <summary>
        /// 右冰刀Z轴旋转
        /// </summary>
        public float binDaoRotZ_Right;
        /// <summary>
        /// 刚体施加力的模式
        /// </summary>
        public int forceMode;
        /// <summary>
        /// 运动平台位置X
        /// </summary>
        public float motionPosX;
        /// <summary>
        /// 运动平台位置Y
        /// </summary>
        public float motionPosY;
        /// <summary>
        /// 运动平台位置Z
        /// </summary>
        public float motionPosZ;
        /// <summary>
        /// 运动平台旋转X
        /// </summary>
        public float motionRotX;
        /// <summary>
        /// 运动平台旋转Y
        /// </summary>
        public float motionRotY;
        /// <summary>
        /// 运动平台旋转Z
        /// </summary>
        public float motionRotZ;
        /// <summary>
        /// 是否冻结  0:解冻 1:冻结
        /// </summary>
        public int isFreeze;
        /// <summary>
        /// 是否重置  0:不重置 1:重置
        /// </summary>
        public int isReset;
        /// <summary>
        /// 眼睛高度
        /// </summary>
        public float eyePosY;

    }
}