using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using System;

public class WS_Client : MonoBehaviour
{
    WebSocket ws;
    // Start is called before the first frame update
    void Start()
    {
        ws = new WebSocket("ws://localhost:3000");
        ws.OnMessage += OnMessage;
        ws.Connect();
    }

    void OnMessage(object sender, MessageEventArgs e)
    {
        try
        {
            Debug.Log("Message received from " + ((WebSocket)sender).Url + " , Data : " + e.Data);
            JSONObject data = new JSONObject(e.Data);
            Debug.Log(data);
            Debug.Log(string.Format("Message Counter : {0}", data["data"]));

            GameManager.Instance.OnNewData(data["data"]);
        }
        catch (Exception exception)
        {
            Debug.LogWarning("Exception : " + exception.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ws == null)
            return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int rd = (int) GameManager.Instance.GetRandomNumberInRange(1, 6);
            Debug.LogError("Random number: " + rd);
        }
    }
    private void OnDestroy()
    {
        ws.OnMessage -= OnMessage;
    }
}
