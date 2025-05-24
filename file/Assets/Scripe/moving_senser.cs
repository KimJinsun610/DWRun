using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving_senser : MonoBehaviour
{
    
    float speed_OBJ = -0.1f;
    private void Update()
    {
        this.transform.position = this.transform.position + new Vector3(speed_OBJ, 0);
    }
    private void OnTriggerEnter(Collider col)
    {
        
        if (col.tag == "Player")
        {
            Debug.Log("플레이어 닿음");
            GameObject.Find("fish").GetComponent<fish_moving>().Up();
        }

      
    }
}
