using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class smartmanager : MonoBehaviour
{
    [SerializeField] float blinkspeed; //깜박임 속도
    [SerializeField] int blinkcount; //깜박임 횟수

    [SerializeField] SpriteRenderer mesh_playerGraphics; //깜박이는 주체

    [SerializeField] int maxHP; //최대체력
    int currentHP; // 현제체력
    [SerializeField] Image[] image_Hparray; //체력 ui 이미지 (하트)

       
    void Start()
    {
        currentHP = maxHP; //시작하면 현제채력을 최대체력으로 설정한다.
        UpdateHPStatus(); //체력상태를 업데이트 한다 (하트이미지를 전부 띄운다)

    }

    public void increaseHP(int _num) //체력감소함수
    {
        if (currentHP <=2) //만악 현재체력이 2이하라면
            currentHP += _num;  //체력을 1만큼 증가시킨다.
            UpdateHPStatus(); //체력 상태를 업데이트 한다.(하트를 1개 추가한다.)

    }

    public void DecreasHP(int _num) //체력감소함수
    {
        currentHP -= _num;  //체력을 1만큼 감소시킨다.
        UpdateHPStatus(); //체력 상태를 업데이트 한다.(하트를 1개 감소시킨다.)
        if (currentHP <= 0) //만악 현재체력이 0 이하라면
            Playerdead(); //Playerdead 명령어를 실행시킨다.
        StartCoroutine(BlinkCoroutine()); //깜박임 함수를 실행한다.
    }

    IEnumerator BlinkCoroutine() //깜박임 함수
    {
        for (int i = 0; i < blinkcount * 2; i++) // i가 두배가 될때까지 1씩 더하며 반복 실행한다.
        {
            mesh_playerGraphics.enabled = !mesh_playerGraphics.enabled; //플레이어이미지를 1번 깜박인다.
            yield return new WaitForSeconds(blinkspeed); //잠시동안 대기한다.

        }
    }

    void UpdateHPStatus() //체력업데이트 함수
    {
        for(int i = 0; i < image_Hparray.Length ; i++) //i를 체력길이가 될때까지(하트3개) 1씩 더하며 반복 수행한다
        {
            if (i < currentHP) //만약 현재체력이 i 보다 크다면
                image_Hparray[i].gameObject.SetActive(true); //하트이미지를 띄우기
            else //아니라면
                image_Hparray[i].gameObject.SetActive(false); //하트이미지를 지우기

        }
    }
    
    void Playerdead() //게임오버 함수
    {
        Debug.Log("플레이어 죽음"); //"플레이어죽음" 이라는 상태를 띄운다.
        SceneManager.LoadScene("BADENDING");
    }

}
