using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump_img : MonoBehaviour
{
    float speed = -0.1f; 
    
    void Update()
    {
        this.transform.position = this.transform.position + new Vector3(speed, 0);
    }
}
