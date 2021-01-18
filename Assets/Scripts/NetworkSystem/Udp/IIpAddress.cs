using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NetworkSystem.UDP
{
    public class IIpAddress
    {
        [SerializeField] protected string sendIp;
        [SerializeField] protected int sendPort;
        [SerializeField] protected string receiveIp;
        [SerializeField] protected int receivePort;


        public string SendIp { get => sendIp; set => sendIp = value; }
        public int SendPort { get => sendPort; set => sendPort = value; }
        public string ReceiveIp { get => receiveIp; set => receiveIp = value; }
        public int ReceivePort { get => receivePort; set => receivePort = value; }


        public IIpAddress() { }
        public IIpAddress(string sendIp, int sendPort, string receiveIp, int receivePort)
        {
            this.sendIp = sendIp;
            this.sendPort = sendPort;
            this.receiveIp = receiveIp;
            this.receivePort = receivePort;
        }
    }
}