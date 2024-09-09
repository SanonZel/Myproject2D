using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int CurrentScore;
    [SerializeField] private TMPro.TextMeshProUGUI ScoreText;

    void Start()
    {
        CurrentScore = 0;
        
    }

    void Update()
    {
        ScoreText.text = "Score:" + CurrentScore; 
    }
    public void OnAddScore()
    {
        CurrentScore++;

    }
}
