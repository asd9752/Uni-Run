using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab; //������ ���� ������
    public int count = 3;

    public float timeBetSpawnMin = 1.25f; //���� ��ġ������ �ð� ���� �ּڰ�
    public float timeBetSpawnMax = 2.25f; //���� ��ġ������ �ð� ���� �ִ밪
    private float timeBetSpawn; // ������ġ������ �ð�����

    public float yMin = -3.5f; //��ġ�� ��ġ�� �ּ� y��
    public float yMax = 1.5f; //��ġ�� ��ġ�� �ִ� y��
    private float xPos = 20f; //��ġ�� ��ġ�� x��

    private GameObject[] platforms; //�̸� ������ ���ǵ�
    private int currentIndex = 0;//����� ���� ������ ����

    //�ʹݿ� ������ ������ ȭ�� �ۿ� ���ܵ� ��ġ

    private Vector2 poolPosition = new Vector2(0, -25);
    private float lastSpawnTime;// ������ ��ġ ����



    // Start is called before the first frame update
    void Start()
    {   //count��ŭ�� ������ ������ ���ο� ���� �迭 ����
        platforms = new GameObject[count];
        
        //count��ŭ �����ϸ鼭 ���� ����
        for(int i =0; i< count; i++)
        {
            //platformPrefab�� �������� �� ������ poolposition ��ġ�� ���� ����
            //������ ������ platform �迭�� �Ҵ�
            platforms[i] = Instantiate(platformPrefab, poolPosition, Quaternion.identity);
        }
        //������ ��ġ ���� �ʱ�ȭ
        lastSpawnTime = 0f;
        //������ ��ġ������ �ð� ������ 0���� �ʱ�ȭ
        timeBetSpawn = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //���ӿ������¿����� �������� ����
     if(GameManager.instance.isGameover)
        {
            return;
        }
     //������ ��ġ �������� timeBetSpawn �̻� �ð��� �귶�ٸ�
     if(Time.time >= lastSpawnTime +timeBetSpawn)
        {
            lastSpawnTime = Time.time;
            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);
            float yPos = Random.Range(yMin, yMax);
            platforms[currentIndex].SetActive(false);
            platforms[currentIndex].SetActive(true);
            platforms[currentIndex].transform.position = new Vector2(xPos, yPos);
            currentIndex++;
            if(currentIndex >= count)
            {
                currentIndex = 0;
            }
        }
    }
}
