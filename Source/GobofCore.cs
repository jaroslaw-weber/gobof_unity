using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Fleck;

public class GobofCore : MonoBehaviour {

    private static GobofCore Instance;

    WebSocketServer wssv;
    TrackerWebsocketService tws;

    Dictionary<int,IGobofObject> _registeredObjects = new Dictionary<int, IGobofObject>();

    void Awake() {
      Instance = this;
      wssv = new WebSocketServer ("ws://0.0.0.0:8765");
      tws = new TrackerWebsocketService();
      
      wssv.Start (socket =>{


        socket.OnMessage=tws.OnMessage;
        Debug.Log("server started!");
      });
    }

    public static void RegisterObject(IGobofObject o)
    {
      Instance._registeredObjects[o.ID] = o;
    }

    void FixedUpdate() {
      UpdateAllPositions();
    }

    void UpdateAllPositions()
    {
      
      foreach (var o in _registeredObjects)
      {
        var key = o.Key;
        if(TrackerWebsocketService.Positions.ContainsKey(key))
        {
          var p = TrackerWebsocketService.Positions[key];
          var tr = o.Value.GetTransform();
          tr.localPosition = Vector3.Lerp(tr.localPosition, p, (2.5f * Time.fixedDeltaTime));
        }
          
      }
    }

    void OnDestroy() {
        //wssv.Stop();
    }
}
