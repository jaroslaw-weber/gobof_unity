using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fleck;

public class TrackerWebsocketService
  {
    public static Dictionary<int, Vector3> Positions = new Dictionary<int, Vector3>();

    public void OnMessage (string data)
    {
      var arr = data.Split(',');
      var id = int.Parse(arr[0]);
      var x = float.Parse(arr[1]);
      var y = float.Parse(arr[2]);
      var z = float.Parse(arr[3]);
      var v = new Vector3(x,y,z);
      //Debug.Log("position: "+v);
      Positions[id] = v;
    }
  }
