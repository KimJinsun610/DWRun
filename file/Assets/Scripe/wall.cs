using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) //부딧힘감지 함수
    {
        if (other.gameObject.name == "car") 
        {
            Destroy(other.gameObject); //그 오브젝트를 파괴한다.
        }

        if (other.gameObject.name == "ravacorn") 
        {
            Destroy(other.gameObject);
        }
    }
 
}
