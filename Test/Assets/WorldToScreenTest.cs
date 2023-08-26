using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldToScreenTest : MonoBehaviour
{
    public GameObject WorldGameobject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.WorldToScreenPoint(WorldGameobject.transform.position);
    }
}
