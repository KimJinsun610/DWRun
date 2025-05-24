using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fish_moving : MonoBehaviour
{
    
   
    [SerializeField] int damage; //데미지 함수

    float speed_OBJ = -0.1f;
 
    void Update()
    {
        this.transform.position = this.transform.position + new Vector3(speed_OBJ,0);
       
              
    }

    public void Up()
    {
        soundmanager.instance.PlaySE("TUNA");
        this.transform.position = this.transform.position + new Vector3(0, 6);
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
