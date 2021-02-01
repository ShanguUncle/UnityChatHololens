﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Server ip configuration
/// </summary>
public class Config : MonoBehaviour {

    public static Config Instance;

    //Server ip and port
    public string ServerIP;
    public int TcpPort; 
    public int UdpPort;
     
    public GameObject NetPanl;
    public InputField ServerIPInputField;

    public string IpKey = "IpKey";
    private void Awake()
    {
        Instance=this;
        if (PlayerPrefs.HasKey(IpKey))
        {
            ServerIP = PlayerPrefs.GetString(IpKey);
            print("PlayerPrefs get ip:" + ServerIP);
        }
    }
    void Start ()
    {
        ServerIPInputField.text= ServerIP;
        ChatNetworkManager.Instance.OnConnectResultAction += OnConnect;
        Connect();
    }

    private void OnConnect(bool result)
    {
        if (result) 
        {
            PlayerPrefs.SetString(IpKey, ServerIP);
            PlayerPrefs.Save();
        }
    }

    public void Connect()
    {
        ServerIP = ServerIPInputField.text;
        ChatNetworkManager.Instance.ConnectServer();
    }
}
