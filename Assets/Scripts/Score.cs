using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour
{
    public Text scoreText;

    private int score;
    public int totalNum;
    playerController pc;

    void Start()
    {
        pc = GameObject.Find("Player").GetComponent<playerController>();
        score = 0;
        SetScoreText();
    }

    public void inScore()
    {
        score++;
        SetScoreText();
        if (score == totalNum)
            pc.Win();
    }

    public void resetScore()
    {
        score = 0;
        SetScoreText();
    }

    void SetScoreText()
    {
        scoreText.text = score.ToString() + "/" + totalNum.ToString();
    }
}