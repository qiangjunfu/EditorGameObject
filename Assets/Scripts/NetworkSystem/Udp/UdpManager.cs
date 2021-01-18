using NetworkSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;


namespace NetworkSystem.UDP
{
    [System.Serializable]
    public class UdpManager : MonoBehaviour
    {
        #region  
        private static bool isInit;
        private static UdpManager instance;
        public static UdpManager Instance
        {
            get
            {
                if (instance == null)
                {
                    GameObject go = new GameObject(typeof(UdpManager).ToString());
                    go.AddComponent<UdpManager>();
                }
                return instance;
            }
        }
        private void Awake()
        {
            if (instance == null && !isInit)
            {
                isInit = true;
                instance = GetComponent<UdpManager>();
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        private void OnDestroy()
        {
            if (instance != null) instance = null;
            if (receiveSocket != null) receiveSocket.Dispose();
        }
        private void OnApplicationQuit()
        {
            if (instance != null) instance = null;
            if (receiveSocket != null) receiveSocket.Dispose();
        }
        #endregion

        [Header("是否连接上Udp")] [SerializeField] private bool isConnect;
        [Header("心跳检测间隔时间")] [SerializeField] private float intervalTime;
        [Header("ip配置路径")] [SerializeField] private string mPath;
        [SerializeField] private IpConfig mIpConfig;
        [SerializeField] private ReceiveData receiveData;
        [SerializeField] public SendData sendData;
        private ReceiveSocket receiveSocket;

        public bool IsConnect { get => isConnect; set => isConnect = value; }
        public IpConfig GetIpConfig { get => mIpConfig; }
        public ReceiveData GetReceiveData { get => receiveData; set => receiveData = value; }


        public void Start()
        {
            InitIpPortInfo();
            InitSocketThread();
        }

        public void Update()
        {
            if (isConnect)
            {
                intervalTime += Time.deltaTime;
                if (intervalTime >= 10)
                {
                    isConnect = false;
                    intervalTime = 0;
                }
            }
        }


        private void InitIpPortInfo()
        {
            mPath = Path.Combine(Application.streamingAssetsPath, "JsonFile", "IpJson.json");
            mIpConfig = UnityUtility.ReadJson.ReadJsonData<IpConfig>(mPath);
        }

        private void InitSocketThread()
        {
            if (receiveSocket == null) receiveSocket = new ReceiveSocket();

            receiveSocket.InitBindIPPort(mIpConfig.ReceivePort);
            receiveSocket.StartThread();
        }

    }
}