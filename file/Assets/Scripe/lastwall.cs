using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lastwall : MonoBehaviour
{
    float speed = -0.1f;

    void Update()
    {
        this.transform.position = this.transform.position + new Vector3(speed, 0);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")  //만약 부딧친 사물이 "플레이어" 라면
        {
            col.transform.GetComponent<Guimanager>().goodending();
          
        }

    }
}
