using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip deathClip;// 사망 시 재생할 오디오 클립
    public float jumpForce = 700f;// 점프 힘

    private int jumpCount = 0; // 누적 점프 횟수
    private bool isGrounded = false; // 바닥에 닿았는지 나타냄
    private bool isDead = false;// 사망 상태

    private Rigidbody2D playerRigdibody;// 사용할 리지드바디 컴포넌트
    private Animator animator; // 사용할 애니메이터 컴포넌트
    private AudioSource playerAudio; // 사용할 오디오 소스 컴포넌트
    // Start is called before the first frame update
    void Start()
    {
        playerRigdibody = this.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       if(isDead)
        { //사망 시 처리를  더이상 진행하고 하지 않고 종료
            return;
        }
       //마우스 왼쪽버튼을 눌렀으며 최대점프 횟수(2)에 도달하지 않았다면
       if(Input.GetMouseButtonDown(0) && jumpCount<2)
        {
            //점프 횟수 증가
            jumpCount++;
            //점프 직전에 속도를 순간적으로 제로(0,0)으로 변경
            playerRigdibody.velocity = Vector2.zero;
            //리지드바디에 위쪽으로 힘주기
            playerRigdibody.AddForce(new Vector2(0, jumpForce));
            //오디오 소스 재생
            playerAudio.Play();
           
        }
       else if(Input.GetMouseButtonUp(0) && playerRigdibody.velocity.y > 0)
        {
            //마우스 왼쪽 버튼에서 손을 떼는 순간 && 속도의 y값이 양수라면 (위로 상승 중)
            //현재 속도를 절반으로 변경
            playerRigdibody.velocity = playerRigdibody.velocity * 0.5f;
        }
        // 애니메이터의 Grounded 파라미터를 isGrounded 값으로 변경
        animator.SetBool("Grounded", isGrounded);
    }


    private void Die()
    {   //애니메이터의 Die 트리거 파라미터를 셋
        animator.SetTrigger("Die");
        //오디오 소스에 할당된 오디오 클립을 deathClip으로 변경
        playerAudio.clip = deathClip;
        //사망 효과음 재생
        playerAudio.Play();

        //속도를 제로(0,0)로 변경
        playerRigdibody.velocity = Vector2.zero;
        //사망 상태를 true로 변경
        isDead = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.7f)
        {
            jumpCount = 0;
            isGrounded = true;
        }

     }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Dead" && !isDead)
        {
            Die();
        }    
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
