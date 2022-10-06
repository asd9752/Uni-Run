using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgroundloop : MonoBehaviour
{
    private float width; //��� ������ ����
    private void Awake()
    {
        //�ڽ� �ݶ��̴�2D ������Ʈ�� ������ �ʤ��� x����  ���� ���̷� ���
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        width = backgroundCollider.size.x;
    }
 
    // Update is called once per frame
    void Update()
    {
        //������ġ�� �������� �������� width �̻� �̵����� �� ��ġ�� ���ġ
        if(transform.position.x<= -width)
        {
            Reposition();
        }
    }
    //��ġ�� ���ġ �ϴ� �޼���
    private void Reposition()
    {  //���� ��ġ���� ���������� ���α��� *2��ŭ �̵�
        Vector2 offset = new Vector2(width * 2f, 0);
        transform.position = (Vector2)transform.position + offset;
    }

}

