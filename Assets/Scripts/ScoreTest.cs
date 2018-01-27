using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreTest : MonoBehaviour
{
    public Text countText;
    
    private int score;

    void Start() {
        score = 0;
        SetScoreText();
    }

    private void Update() {
        if (Input.GetKeyDown("space")) {
            score = score + 1;
            SetScoreText();
        }  
    }

    void SetScoreText() {
        countText.text = "Score: " + score.ToString();
    }
}