
using UnityEngine;

public class SecondGobofObject : MonoBehaviour, IGobofObject {
    
    public int ID { get { return 2;}}

    public GetTransform()
    {
        return transform;
    }

    void Start()
    {
        GobofCore.RegisterObject(this);
    }

}
