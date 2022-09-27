using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public class WS_Client : MonoBehaviour
{
    WebSocket ws;
    // Start is called before the first frame update
    void Start()
    {
        ws = new WebSocket("ws://localhost:3000");
        ws.OnMessage += (sender, e) =>
        {
            Debug.Log(e.Data);
            Debug.Log("Message received from " + ((WebSocket)sender).Url + " , Data : " + e.Data);
            JSONObject data = new JSONObject(e.Data);
            Debug.Log(data);
            Debug.Log(string.Format("Message : {0}",data["message"].str));
        };
        ws.Connect();
    }

    // Update is called once per frame
    void Update()
    {
        if (ws == null)
            return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ws.Send("Hello");
        }
    }
}
