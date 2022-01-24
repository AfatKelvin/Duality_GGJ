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
    public bool needSaleEffect = true;
    public GameObject timeLeftText;
    public bool growUp = true;
    public float textScale = 1;
    //public GameObject timeBar;
    public float localScale = 2;


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
            timeLeftText.GetComponent<Text>().text = "" + Mathf.Ceil(timeLeft).ToString();

            if (timeLeft <= 0)
            {
                timeCountDown = false;
                textScale = 1f;
                timeLeftText.transform.localScale = new Vector2(textScale, textScale);
                GameManager.instance.PKResultPanel();
            }
            else if (timeLeft <= 10f && needSaleEffect)
            {
               // TextScaleDown();
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
        needSaleEffect = true;
    }


    public void TextScaleDown() 
    {
        needSaleEffect = false;
        StartCoroutine(ScaleDown_IE());
    }

    IEnumerator ScaleDown_IE()
    {
        
        for (int i = 0; i < 10; i++)
        {
            float tempScale = localScale;
            while (tempScale >= 1)
            {
                tempScale -= 0.05f;
                timeLeftText.transform.localScale = new Vector2(tempScale, tempScale);
                Debug.Log("scale = " + tempScale + " timeLeft" + timeLeft + " total" + (tempScale+timeLeft));
                yield return new WaitForSeconds(0.05f);

            }
        }
    }

}
