using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform beeTransform;
    public float xValue;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        beeTransform.position = new Vector3(beeTransform.position.x, 0, -10);
    }
}
