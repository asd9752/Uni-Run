using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//���ӿ��� ���¸� ǥ���ϰ�, ���� ������ UI�����ϴ� ���ӸŴ���
//������ �� �ϳ��� ���� �Ŵ����� ������ �� ����
public class GameManager : MonoBehaviour
{
    public static GameManager instance;// �̱����� �Ҵ��� ��������
    public bool isGameover = false; //���ӿ�������
    public static Text scoreText;//������ ����� UI �ؽ�Ʈ
    public GameObject gameoverUI;// ���ӿ����� Ȱ��ȭ�� UI ���� ������Ʈ

    private int score = 0;//���� ����
 

    // Start is called before the first frame update
    //���� ���۰� ���ÿ� �̱����� ����
    void Awake()
    {
        //�̱��� ���� instance�� ��� �ִ°�?
        if (instance == null)
        {
            //instance�� ��� �ִٸ� �װ��� �ڱ� �ڽ��� �Ҵ�
            instance = this;
        }
        else
        {
            //instance�� �̹� �ٸ� GameManager ������Ʈ�� �Ҵ�Ǿ� �ִ� ���
            //���� �� �� �̻��� GameManager ������Ʈ�� �����Ѵٴ� �ǹ�
            //�̱��� ������Ʈ�� �ϳ��� �����ؾ� �ϹǷ� �ڽ��� ���� ������Ʈ�� �ı�
            Debug.LogWarning("���� �ΰ� �̻��� ���� �Ŵ����� �����մϴ�.");
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        //���� �������¿��� ������ ������� �� �ְ� �ϴ� ó��
        if(isGameover && Input.GetMouseButtonDown(0))
        {
            //���ӿ��� ���¿��� ���콺 ���� ��ư�� Ŭ���ϸ� ���� �� �����
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
       
      
    }
    //������ ������Ű�� �޼���
    public void AddScore(int newScore)
    {
        if(!isGameover)
        {
            //������ ����
            score += newScore;
            scoreText.text = "Score :" + score;
        }
    }
    //�÷��̾� ĳ���� ����� ���ӿ����� �����ϴ� �ż���
    public void OnPlayerDead()
    {
        isGameover = true;
        gameoverUI.SetActive(true);
    }


    public void Menuactive(int num)
    {
        Time.timeScale = num;
        
    }
    public void EXIT()
    {
        Application.Quit();
    }
}
