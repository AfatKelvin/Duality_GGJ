using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    public static TimeCounter instance;
    public float timeInitail = 30; //初始時間
    public float timeLeft; // 剩餘時間
    public bool timeCountDown; //需要重設時間
    public GameObject timeLeftText;
    public bool growUp = true;
    public float textScale = 1;
    //public GameObject timeBar;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeCountDown ==true)
        {
            timeLeft -= Time.deltaTime;
            timeLeftText.GetComponent<Text>().text = "" + Mathf.Round(timeLeft).ToString();

            if (timeLeft <= 0)
            {
                timeCountDown = false;
                textScale = 1f;
                timeLeftText.transform.localScale = new Vector2(textScale, textScale);
                GameManager.instance.PKResultPanel();
            }
            /*
            else if (timeLeft <= 10)
            {
                if (growUp)
                {
                    textScale += 0.1f;
                    timeLeftText.transform.localScale = new Vector2(textScale, textScale);
                    if (textScale >= 1.2f)
                    {
                        growUp = false;
                    }
                }
                else
                {
                    textScale -= 0.3f;
                    timeLeftText.transform.localScale = new Vector2(textScale, textScale);
                    if (textScale <= 0.8f)
                    {
                        growUp = true;
                    }
                }
            }
            */
        }
    }
    
    public void TimeBoolSet() 
    {
        timeCountDown = true;
        timeLeft = timeInitail;
        
    }

}
