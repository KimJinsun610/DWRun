using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soccerball : MonoBehaviour
{
    [SerializeField] int damage; 
    float speed_OBJ = -0.05f;

    void Update()
    {
        this.transform.position = this.transform.position + new Vector3(speed_OBJ, 0);
        transform.Rotate(new Vector3(0,0,-13));
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")  
        {
            Debug.Log(damage + "피해 받음"); 
            col.transform.GetComponent<smartmanager>().DecreasHP(damage);

        }

    }

}