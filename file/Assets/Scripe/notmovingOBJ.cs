using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notmovingOBJ : MonoBehaviour
{
    float speed_OBJ = -0.1f; //사물의 움직임을 -0.1f로 정한다
    [SerializeField] int damage; //데미지 함수

    void Update() 
    {
        this.transform.position = this.transform.position + new Vector3(speed_OBJ,0); //매초마다 이것의 위치를 speed_OBJ 만큼 이동시킨다.
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")  //만약 부딧친 사물이 "플레이어" 라면
        {
            Debug.Log(damage + "피해 받음"); //"피해받음"이라는 상태를 띄운다
            col.transform.GetComponent<smartmanager>().DecreasHP(damage);//smartmanager스크립트의 체력감소 함수를 실행한다.

        }

    }
}
