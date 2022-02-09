using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;

    [SerializeField]
    private Button instructionButton;

    [SerializeField]
    public Text scoreText, endScoreText;

    [SerializeField]
    public GameObject gameOverPanel;

    void Awake()
    {
        Time.timeScale = 0;
        MakeInstance();
    }

    void MakeInstance(){
        if(instance == null){
            instance = this;
        }
    }

    public void _onInstructionButton(){
        Time.timeScale = 1;
        instructionButton.gameObject.SetActive(false);
    }

    public void _setScore(int score){
        scoreText.text = score.ToString();
        endScoreText.text = score.ToString();
    }

    public void _onPlayerDied(){
        gameOverPanel.SetActive(true);
    }

    public void _onPlayAgain(){
        SceneManager.LoadScene("GamePlay");
    }
}
