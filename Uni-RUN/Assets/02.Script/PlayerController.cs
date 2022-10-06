using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip deathClip;// ��� �� ����� ����� Ŭ��
    public float jumpForce = 700f;// ���� ��

    private int jumpCount = 0; // ���� ���� Ƚ��
    private bool isGrounded = false; // �ٴڿ� ��Ҵ��� ��Ÿ��
    private bool isDead = false;// ��� ����

    private Rigidbody2D playerRigdibody;// ����� ������ٵ� ������Ʈ
    private Animator animator; // ����� �ִϸ����� ������Ʈ
    private AudioSource playerAudio; // ����� ����� �ҽ� ������Ʈ
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
        { //��� �� ó����  ���̻� �����ϰ� ���� �ʰ� ����
            return;
        }
       //���콺 ���ʹ�ư�� �������� �ִ����� Ƚ��(2)�� �������� �ʾҴٸ�
       if(Input.GetMouseButtonDown(0) && jumpCount<2)
        {
            //���� Ƚ�� ����
            jumpCount++;
            //���� ������ �ӵ��� ���������� ����(0,0)���� ����
            playerRigdibody.velocity = Vector2.zero;
            //������ٵ� �������� ���ֱ�
            playerRigdibody.AddForce(new Vector2(0, jumpForce));
            //����� �ҽ� ���
            playerAudio.Play();
           
        }
       else if(Input.GetMouseButtonUp(0) && playerRigdibody.velocity.y > 0)
        {
            //���콺 ���� ��ư���� ���� ���� ���� && �ӵ��� y���� ������ (���� ��� ��)
            //���� �ӵ��� �������� ����
            playerRigdibody.velocity = playerRigdibody.velocity * 0.5f;
        }
        // �ִϸ������� Grounded �Ķ���͸� isGrounded ������ ����
        animator.SetBool("Grounded", isGrounded);
    }


    private void Die()
    {   //�ִϸ������� Die Ʈ���� �Ķ���͸� ��
        animator.SetTrigger("Die");
        //����� �ҽ��� �Ҵ�� ����� Ŭ���� deathClip���� ����
        playerAudio.clip = deathClip;
        //��� ȿ���� ���
        playerAudio.Play();

        //�ӵ��� ����(0,0)�� ����
        playerRigdibody.velocity = Vector2.zero;
        //��� ���¸� true�� ����
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
