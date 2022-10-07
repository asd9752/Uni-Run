using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 게임오브젝트를 계속 움직이는 스크립트

public class ScrollingObject : MonoBehaviour
{
    public float speed = 10f;


    // Update is called once per frame
    void Update()
    {
        //초당 speed로 이동   
        if (!GameManager.instance.isGameover)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        
    }



}
