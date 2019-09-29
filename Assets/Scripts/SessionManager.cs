using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SessionManager : MonoBehaviour
{
    public static float speedMultiplier;
    public static bool isSlowed;

    public float countDownTime;
    public float normalSpeed;
    public float reducedSpeed;

    public Text countDownText;

    // Start is called before the first frame update
    void Start()
    {
        speedMultiplier = normalSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        countDownTime -= Time.deltaTime;
        //countDownText.text = Mathf.Round(countDownTime).ToString();

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
}
