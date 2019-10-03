using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SessionManager : MonoBehaviour
{

    
    public static float speedMultiplier;
    public static bool isSlowed;

    public float gameTime;
    public float normalSpeed;
    public float reducedSpeed;
    public int score;

    public Text scoreText;
    public Text countDownText;

    private float countDownTime;

    
    // Start is called before the first frame update
    void Start()
    {
        countDownTime = gameTime;
        speedMultiplier = normalSpeed;

    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.R)){

            SceneManager.LoadScene(0);
            Time.timeScale = 1f;
            countDownTime = gameTime;
            score = 0;
            
        }
        countDownTime -= Time.deltaTime;
        countDownText.text = "Time: " + Mathf.Round(countDownTime).ToString();
        scoreText.text = "Score: " + score.ToString();

        if(countDownTime < 0){
            Time.timeScale = 0f;
            scoreText.text = "PRESS 'R' TO RESTART";
            countDownText.text = "GAMEOVER";

        }
    }

    public void ChangeSpeed()
    {
        isSlowed = !isSlowed;

        if (isSlowed)
        {
            speedMultiplier = reducedSpeed;
        }
        else
        {
            speedMultiplier = normalSpeed;
        }
    }

    public void IncreaseScore(int points)
    {
        score += points;
    }
}
