using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Playerstate  // 이 코드가 적용되는 사물의 상태가 될 변수를 선언한다
{
    Run,
    Jump,
    D_Jump,
}

public class player_ctrl : MonoBehaviour
{
    Rigidbody mr; // 물리량을 mr 이라고 부르기로 정한다.
    public Playerstate PS; //사물의 상태를 PS라 부르기로 정한다. 
    public float Jump_power = 350f; //점프력을 정하기 위해 Jump_power라는 변수를 선언한다.
    [SerializeField] int Maxjumpcount = 0;
    [SerializeField] int currentjump=0;
    public Animator animator; //애니메이션을 적용시키기 위해 animator라는 변수를 선언한다.
    public AudioClip[] sound;
    
    
     void Start()
    {
        mr= GetComponent<Rigidbody>();  //게임을 실행하면 mr에 물리량을 적용시킨다.
    }

    void Update()
    {

        mr.WakeUp();
        if (Input.GetKeyDown(KeyCode.Space)) //만약에 space키가 눌리고
        {
            if (Maxjumpcount >= 2) //만약에 이 사물의 상태가 Jump라면
            {
                if (Maxjumpcount <= 2)
                {
                    D_Jump(); //D_Jump를 실행한다.
                    Maxjumpcount = 0;
                }
            }
            if (Maxjumpcount >= 1) //만약에 이 사물이 상태가 Run이라면
            {
                if (Maxjumpcount <= 1)
                {
                    Jump(); //Jump를 실행한다.
                    Maxjumpcount++;

                }

            }

        }
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if (Maxjumpcount >= 2) //만약에 이 사물의 상태가 Jump라면
                {
                    if (Maxjumpcount <= 2)
                    {
                        D_Jump(); //D_Jump를 실행한다.
                        Maxjumpcount = 0;
                    }
                }
                if (Maxjumpcount >= 1) //만약에 이 사물이 상태가 Run이라면
                {
                    if (Maxjumpcount <= 1)
                    {
                        Jump(); //Jump를 실행한다.
                        Maxjumpcount++;

                    }

                }
            }
        }

    }
    void Jump() //Jump를 실행한다면
    {
        PS = Playerstate.Jump; //이 사물의 상태를 Jump로 바꾼다.
        soundmanager.instance.PlaySE("jump");
        mr.AddForce(new Vector2(0, Jump_power)); //y축으로 Jump_power만큼 올라간다.
        animator.SetTrigger("jumping"); //jumping 애니메이션을 실행한다.
        animator.SetBool("running",false); //running 애니메이션 상태를 거짓으로 만든다.
    }

    void D_Jump() //D_Jump를 실행하면 
    {
        PS = Playerstate.D_Jump; // 이 사물의 상태를 D_jump로 바꾼다.
        soundmanager.instance.PlaySE("jump");
        mr.AddForce(new Vector2(0, Jump_power)); //y축으로 Jump_power만큼 올라간다. 
        animator.SetTrigger("D_jumping"); //D_jumping 애니메이션을 실행한다. 
        animator.SetBool("running",false); //running 애니메이션 상태를 거짓으로 만든다. 
        Maxjumpcount = 0;
    }

    void Run() // Run을 실행하면
    {
        animator.SetBool("D_jumping", false);
        animator.SetBool("jumping", false);
        animator.SetBool("running",true); //running 애니메이션 상태를 진실로 만든다.(running 애니메이션을 실행한다.)
        PS = Playerstate.Run; //이 사물의 상태를 Run으로 바꾼다.
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("ground"))
        {
            mr.WakeUp();
            if (PS != Playerstate.Run)
            {
                Maxjumpcount = 1;
                Run();
            }
        }

        
    }
    
}
    
