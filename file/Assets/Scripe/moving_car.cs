using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving_car : MonoBehaviour
{
    public float speed = -0.2f; //자동차의 속도를 정하기위해 speed라는 실수형 변수를 선언한다.
    [SerializeField] int damage;

 
    void Update()
    {
        this.transform.position = this.transform.position + new Vector3(speed, 0);
        //자동차의 x좌표를 speed만큼 계속해서 움직인다.
    }

    private void OnTriggerEnter(Collider col) //다른 사물과 부딧혔는지 감지하는 함수
    {
        if (col.tag == "Player")
        {
            Debug.Log(damage + "피해 받음"); //"피해받음"이라는 상태를 띄운다
            col.transform.GetComponent<smartmanager>().DecreasHP(damage);//smartmanager스크립트의 체력감소 함수를 실행한다.
        }

    }


}
