using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    Rigidbody2D myrigid; // 물리량을 적용시킬 "myrigid"라는 변수 선언한다.

    void Start()
    {
        myrigid = GetComponent<Rigidbody2D>(); //게임을 시작하면 "myrigid"에 물리량 적용한다.

    }

    void Update()
    {
        myrigid.velocity = new Vector2(-2, 0); //배경의 x좌표를 -1씩 계속 이동한다.
    }
}
