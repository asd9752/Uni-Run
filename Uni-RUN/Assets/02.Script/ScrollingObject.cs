using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ���ӿ�����Ʈ�� ��� �����̴� ��ũ��Ʈ

public class ScrollingObject : MonoBehaviour
{
    public float speed = 10f;


    // Update is called once per frame
    void Update()
    {
        //�ʴ� speed�� �̵�   
        if (!GameManager.instance.isGameover)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        
    }



}
