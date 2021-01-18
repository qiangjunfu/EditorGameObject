using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;


namespace NetworkSystem.UDP
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    [System.Serializable]
    public struct SendData
    {
        [SerializeField] public float posX;
        [SerializeField] public float posY;
        [SerializeField] public float posZ;
        [SerializeField] public float rotX;
        [SerializeField] public float rotY;
        [SerializeField] public float rotZ;
        [SerializeField] public float velocityX;
        [SerializeField] public float velocityY;
        [SerializeField] public float velocityZ;
        [SerializeField] public float angleVelocityX;
        [SerializeField] public float angleVelocityY;
        [SerializeField] public float angleVelocityZ;
        [SerializeField] public int isGround;
        [SerializeField] public int isGameOver;
        [SerializeField] public int isStartRunning;
        [SerializeField] public float speed;
        [SerializeField] public float totalTime;
        [SerializeField] public float totalDistance;

    }
}