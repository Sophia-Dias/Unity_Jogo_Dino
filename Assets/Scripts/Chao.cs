using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chao : MonoBehaviour
{
    public float DiferencaX;

    public float MinX;

    private void Update() 
    {
        if(transform.position.x <= MinX) 
        {
            transform.position =  new Vector3(
                transform.position.x + DiferencaX * 2,
                transform.position.y,
                transform.position.z
            );
        }
    }
}
