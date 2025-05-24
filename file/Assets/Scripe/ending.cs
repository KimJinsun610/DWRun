using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ending : MonoBehaviour
{
    float speed_OBJ = -0.1f;
    private void Update()
    {
        this.transform.position = this.transform.position + new Vector3(speed_OBJ, 0);
    }

    private void OnTriggerEnter(Collider col) //다른 사물과 부딧혔는지 감지하는 함수
    {
        if (col.tag == "Player")
        {
            Debug.Log("굿엔딩"); 
            SceneManager.LoadScene("GOODENDING");
        }

    }
}
