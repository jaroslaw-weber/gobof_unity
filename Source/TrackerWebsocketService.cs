using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using WebSocketSharp.Server;

public class TrackerWebsocketService : WebSocketBehavior
  {
    public static Dictionary<int, Vector3> Positions = new Dictionary<int, Vector3>();

    protected override void OnMessage (MessageEventArgs e)
    {
      var arr = e.Data.Split(',');
      var id = int.Parse(arr[0]);
      var x = float.Parse(arr[1]);
      var y = float.Parse(arr[2]);
      var z = float.Parse(arr[3]);
      var v = new Vector3(x,y,z);
      Positions[id] = v;
    }
  }
