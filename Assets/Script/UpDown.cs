using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    public float upLimit, downLimit,leftLimit,rightLimit;
    
    // Start is called before the first frame update
    void Start()
    {
        upLimit = gameObject.transform.position.y + 0.1f;
        downLimit = gameObject.transform.position.y - 0.1f;
        rightLimit = gameObject.transform.position.x + 0.1f;
        leftLimit = gameObject.transform.position.y - 0.1f;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.L))
        {
            //VibrationTurnOn();
        }
    }

    public void VibrationTurnOn(int diretion) 
    {
        StartCoroutine(Vibration(diretion));
    }

    IEnumerator Vibration( int diretion) 
    {
        int countUp = 0;
        int countDown = 0;
        bool vibrateUp = true;
        bool vibrateDown = false;

        if (diretion == 1) //¦V¥k§ðÀ»
        {
            while (vibrateUp)
            {
                countUp += 1;
                yield return new WaitForSeconds(0.01f);
                gameObject.transform.position = new Vector2(gameObject.transform.position.x + 0.02f, gameObject.transform.position.y);
                if (countUp >= 5)
                {
                    countUp = 0;
                    vibrateUp = false;
                    vibrateDown = true;
                }
            }

            while (vibrateDown)
            {
                countDown += 1;
                yield return new WaitForSeconds(0.01f);
                gameObject.transform.position = new Vector2(gameObject.transform.position.x - 0.02f, gameObject.transform.position.y);
                if (countDown >= 10)
                {
                    countDown = 0;
                    vibrateDown = false;
                    vibrateUp = true;
                }
            }

            while (vibrateUp)
            {
                countUp += 1;
                yield return new WaitForSeconds(0.05f);
                gameObject.transform.position = new Vector2(gameObject.transform.position.x + 0.02f, gameObject.transform.position.y);
                if (countUp >= 5)
                {
                    countUp = 0;
                    vibrateUp = false;
                    vibrateDown = true;
                }
            }
        }
        else if (diretion == 2) //¦V¥ª§ðÀ»
        {
            while (vibrateUp)
            {
                countUp += 1;
                yield return new WaitForSeconds(0.01f);
                gameObject.transform.position = new Vector2(gameObject.transform.position.x - 0.02f, gameObject.transform.position.y);
                if (countUp >= 5)
                {
                    countUp = 0;
                    vibrateUp = false;
                    vibrateDown = true;
                }
            }

            while (vibrateDown)
            {
                countDown += 1;
                yield return new WaitForSeconds(0.01f);
                gameObject.transform.position = new Vector2(gameObject.transform.position.x + 0.02f, gameObject.transform.position.y);
                if (countDown >= 10)
                {
                    countDown = 0;
                    vibrateDown = false;
                    vibrateUp = true;
                }
            }

            while (vibrateUp)
            {
                countUp += 1;
                yield return new WaitForSeconds(0.05f);
                gameObject.transform.position = new Vector2(gameObject.transform.position.x - 0.02f, gameObject.transform.position.y);
                if (countUp >= 5)
                {
                    countUp = 0;
                    vibrateUp = false;
                    vibrateDown = true;
                }
            }
        }



    }
}
