
using UnityEngine;

public class MainGobofObject : MonoBehaviour, IGobofObject {
    
    public int ID { get { return 1;}}

    public GetTransform()
    {
        return transform;
    }

    void Start()
    {
        GobofCore.RegisterObject(this);
    }

}
