using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;
    public Text timeText;
    public Text scoreText; // �߰��� �κ�
    public Text recordText;

    private float surviveTime;
    private float score; // �߰��� �κ�
    private bool isGameover;



    void Start()
    {
        surviveTime = 0;
        score = 0; // �߰��� �κ�
        isGameover = false;
        
    }


    void Update()
    {
        if(!isGameover){
            surviveTime += Time.deltaTime;
            timeText.text = "Time : " + (int)surviveTime;
            IncreaseScore(Time.deltaTime);
            

        }
        else{
            if(Input.GetKeyDown(KeyCode.R)){
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
    public void EndGame(){
        isGameover = true;
        gameoverText.SetActive(true);
        float bestScore = PlayerPrefs.GetFloat("BestScore");

        if(score > bestScore){
            bestScore = score;
            PlayerPrefs.SetFloat("BestScore", bestScore);
        }

        recordText.text = "Best Score : " + (int)bestScore;//bestTime�� ������ �ڵ忡�� bestScore�� ������ �ڵ�� ����

    }
        
    public void IncreaseScore(float amount)
    {
        score += amount;
        scoreText.text = "Score : " + (int)score;//scorebullet ����� ��� �߰� ����
    }// ������ ������Ű�� �Լ�
    
}
