using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NetworkSystem.UDP
{
    [System.Serializable]
    public class IpConfig : IIpAddress
    {
        public IpConfig() { }

        public IpConfig(string sendIp, int sendPort, string receiveIp, int receivePort)
            : base(sendIp, sendPort, receiveIp, receivePort)
        {

        }
    }
}