using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Transform GetTransform()
    {
        return GetComponent<Transform>();
    }

    public Vector3 GetPosition()
    {
        return GetTransform().position;
    }


    // Update is called once per frame
    void Update()
    {

    }

  
}
