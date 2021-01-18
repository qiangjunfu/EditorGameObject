using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using UnityEngine;


namespace NetworkSystem.UDP
{
    public class ReceiveSocket : ISocket
    {

        public ReceiveSocket() : base()
        {

        }

        public override void StartThread()
        {
            Debug.Log("开启接收数据线程---------------------");
            receiveThread = new Thread(ReceiveThread);
            receiveThread.IsBackground = true;
            receiveThread.Start();
        }

        private void ReceiveThread(object obj)
        {
            while (true)
            {
                if (socket != null && socket.Available <= 0)
                {
                    Thread.Sleep(SleepTime_10);
                }

                endPoint = (EndPoint)receivePoint;
                int realLenght = socket.ReceiveFrom(receiveBuffer, ref endPoint);
                string str = endPoint.ToString() + "  接收长度----- " + realLenght;
                //Debug.Log(str);
                UdpManager.Instance.GetReceiveData = (ReceiveData)BytesToStruct(receiveBuffer, typeof(ReceiveData));

                byte[] sendBts = StructToBytes(UdpManager.Instance.sendData );
                SendBytes(sendBts, UdpManager.Instance.GetIpConfig.SendIp, UdpManager.Instance.GetIpConfig.SendPort);
                UdpManager.Instance.IsConnect = true;
            }
        }
    }
}