using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenToWorldTest : MonoBehaviour
{
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                Instantiate(prefab, hit.point, Quaternion.identity);
            }
        }
    }
}
