using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreTxt;
    public GameObject GameOverPanel;
    public Text finalScoreTxt;
    public Text itemLeftTxt;
    public GameObject NextLevelPanel;
    public Text levelTxt;
    public GameObject finalWinPanel;
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
