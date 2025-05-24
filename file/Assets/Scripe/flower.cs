using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flower : MonoBehaviour
{

    [SerializeField] int Heal; //체력회복 함수
    float speed_OBJ = -0.2f;
    float fall_speed = -0.05f;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = this.transform.position + new Vector3(speed_OBJ, fall_speed);
        transform.Rotate(new Vector3(1, 0));
        transform.Rotate(new Vector3(0, 1));        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player") 
        {
            Debug.Log(Heal + "체력회복"); 
            col.transform.GetComponent<smartmanager>().increaseHP(Heal);
            Destroy (this.gameObject);

        }

    }
}
