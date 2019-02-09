using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using WebSocketSharp;
using WebSocketSharp.Server;

public class GobofCore : MonoBehaviour {

    private static GobofCore Instance;

    WebSocketServer wssv;

    Dictionary<int,IGobofObject> _registeredObjects = new Dictionary<int, IGobofObject>();

    void Awake() {
      Instance = this;
      wssv = new WebSocketServer ("ws://0.0.0.0:8765");
      wssv.AddWebSocketService<TrackerWebsocketsService> ("/");
      wssv.Start ();
        
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
        if(wssv.Positions.ContainsKey(key))
        {
          var p = wssv.Positions[key];
          var tr = o.Value.GetTransform();
          tr.localPosition = Vector3.Lerp(tr.localPosition, p, (2.5f * Time.fixedDeltaTime));
        }
          
      }
    }

    void OnDestroy() {
        wssv.Stop();
    }
}
