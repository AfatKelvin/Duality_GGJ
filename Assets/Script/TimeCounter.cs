using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    public float timeInitail = 30; //��l�ɶ�
    public float timeLeft; // �Ѿl�ɶ�
    public bool timeCountDown; //�ݭn���]�ɶ�
    public GameObject timeBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeCountDown ==true)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft<=0)
            {
                timeCountDown = false;
                GameManager.instance.PKResultPanel();
            }
        }
    }
    
    public void TimeBoolSet() 
    {
        timeCountDown = true;
        timeLeft = timeInitail;
        
    }

}
