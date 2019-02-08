using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using WebSocketSharp;
using WebSocketSharp.Server;

public interface IGobofObject {
    int ID { get; }
    UnityEngine.Transform GetTransform() { get; }
}
