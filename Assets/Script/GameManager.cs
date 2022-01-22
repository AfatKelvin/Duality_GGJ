using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject monsterWhite1,monsterBlack1, monsterWhite2, monsterBlack2;
    public GameObject monsterCollect1, monsterCollect2;
    public GameObject mainMenu,resultMenu, result2PMenu, memberPanel;
    public GameObject onePSet, twoPSet;
    public bool p1only = true;
    public int killMonster1P, killMonster2P;
    public int combo1P, combo2P;
    //game 進行時分數
    public GameObject score1, score2;
    public Text score1TextOneP, score2TextOneP, score2TextTwoP;
    public Text combo1PText, combo2PText;
    //結算時分數
    public Text score1TextOnePEnd, score2TextOnePEnd, score2TextTwoPEnd, winLosJudgeText1P,winLosJudgeText2P;

    

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        //MonsterInitial();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            DestroyOldMonster();
            //Destroy(monsterCollect1.transform.GetChild(0).gameObject);
            //Test();
        }
        /*
        if (Input.GetKeyDown(KeyCode.S))
        {
            MonsterGenerate();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            MonsterGenerate2P();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            MonsterGenerate2P();
        }
        */

    }

    public void MonsterGenerate() //組別1 怪物召喚
    {

        float directionJudge = Random.Range(0f, 1f);
        if (directionJudge > 0.5f)
        {
            GameObject temp = Instantiate(monsterWhite1,monsterCollect1.transform);
            temp.transform.position = new Vector2(9, -4);

        }
        else
        {
            GameObject temp = Instantiate(monsterBlack1,monsterCollect1.transform);
            temp.transform.position = new Vector2(-9, -4);
        }
        /*
        if (p1only == false)
        {
            float directionJudge2P = Random.Range(0f, 1f);
            if (directionJudge2P > 0.5f)
            {
                GameObject temp = Instantiate(monsterWhite1, monsterCollect2.transform);
                temp.transform.position = new Vector2(9, 2);

            }
            else
            {
                GameObject temp = Instantiate(monsterBlack1, monsterCollect2.transform);
                temp.transform.position = new Vector2(-9, 2);
            }
        }
        */
    }

    public void MonsterGenerate2P() //組別2 怪物召喚
    {
        if (p1only == false)
        {
            float directionJudge2P = Random.Range(0f, 1f);
            if (directionJudge2P > 0.5f)
            {
                GameObject temp = Instantiate(monsterWhite1, monsterCollect2.transform);
                temp.transform.position = new Vector2(9, 2);

            }
            else
            {
                GameObject temp = Instantiate(monsterBlack1, monsterCollect2.transform);
                temp.transform.position = new Vector2(-9, 2);
            }
        }
    }


    public void MonsterInitial(bool onePlayer) 
    {

        // --------------------------- 初始化---------
        killMonster1P = 0; //初始化擊殺數
        killMonster2P = 0;

        combo1P = 0;
        combo2P = 0;
        

        p1only = onePlayer; //判斷幾P

        // on / off 分數set
        if (p1only)
        {
            score1.SetActive(true);
            score2.SetActive(false);
        }
        else if (!p1only)
        {
            score1.SetActive(false);
            score2.SetActive(true);
        }

        ScoreRenew(); // 分數計算

        if (p1only)
        {
            onePSet.SetActive(true);
            twoPSet.SetActive(false);
        }
        else
        {
            onePSet.SetActive(false);
            twoPSet.SetActive(true);
        }

        // 清除舊有 1P 怪物

        DestroyOldMonster();
        /*
        if (monsterCollect1.transform.childCount > 0)
        {
            while (monsterCollect1.transform.childCount > 0)
            {
                Destroy(monsterCollect1.transform.GetChild(0).gameObject);
            }
        }

        // 清除舊有 2P 怪物
        if (monsterCollect2.transform.childCount > 0)
        {
            while (monsterCollect2.transform.childCount > 0)
            {
                Destroy(monsterCollect2.transform.GetChild(0).gameObject);
            }
        }
        */

        if (monsterCollect1.transform.childCount>0)
        {
            for (int i = 0; i < 8; i++)
            {
                Debug.Log("Destroy 1P KK" + monsterCollect1.transform.childCount);
                Destroy(monsterCollect1.transform.GetChild(0).gameObject);
                Debug.Log("Destroy 1P KK" + monsterCollect1.transform.childCount);
                Debug.Log("Destroy 1P Test");
            }
        }
        
        
        /*
        if (p1only ==false)
        {
            for (int i = 0; i < monsterCollect2.transform.childCount; i++)
            {
                Destroy(monsterCollect2.transform.GetChild(0).gameObject);

                Debug.Log("Destroy 2P Test");
            }
        }
        */

        // 產生怪物
        for (int i = 0; i < 8; i++)
        {
            float directionJudge = Random.Range(0f, 1f);

            if (directionJudge > 0.5f)
            {
                GameObject temp = Instantiate(monsterWhite1, monsterCollect1.transform);
                temp.transform.position = new Vector2((i+1), -4);
            }

            else
            {
                GameObject temp = Instantiate(monsterBlack1, monsterCollect1.transform);
                temp.transform.position = new Vector2(-(i+1), -4);
            }
        }

        if (p1only == false)
        {
            for (int i = 0; i < 8; i++)
            {
                float directionJudge = Random.Range(0f, 1f);

                if (directionJudge > 0.5f)
                {
                    GameObject temp = Instantiate(monsterWhite1, monsterCollect2.transform);
                    temp.transform.position = new Vector2((i + 1), 2);
                }

                else
                {
                    GameObject temp = Instantiate(monsterBlack1, monsterCollect2.transform);
                    temp.transform.position = new Vector2(-(i + 1), 2);
                }
            }
        }
    }
    


    public void CloseMain() 
    {
        mainMenu.SetActive(false);
    }
    public void ShowMain()
    {
        mainMenu.SetActive(true);
    }
    public void CloseResult()
    {
        resultMenu.SetActive(false);
    }
    public void ShowResult()
    {
        resultMenu.SetActive(true);
    }

    public void ShowMemberPanel()
    {
        memberPanel.SetActive(true);
    }

    public void CloseMemberPanel()
    {
        memberPanel.SetActive(false);
    }



    public void ScoreRenew() 
    {
        if (p1only)
        {
            score1TextOneP.text = " 擊殺數 : " + (killMonster1P * 100).ToString();
        }
        else if (!p1only)
        {
            score2TextOneP.text = " 1P 擊殺數 : " + (killMonster1P * 100).ToString();
            score2TextTwoP.text = " 2P 擊殺數 : " + (killMonster2P * 100).ToString();
            combo1PText.text = "Combo : " + combo1P;
            combo2PText.text = "Combo : " + combo2P;


        }
    }

    public void DestroyOldMonster() 
    {
        if (monsterCollect1.transform.childCount>0)
        {
            for (int i = 0; i < monsterCollect1.transform.childCount; i++)
            {
                Destroy(monsterCollect1.transform.GetChild(monsterCollect1.transform.childCount-1 - i).gameObject);
            }
            
        }
        

        // 清除舊有 2P 怪物
        if (p1only == false)
        {
            if (monsterCollect2.transform.childCount>0)
            {
                for (int i = 0; i < monsterCollect2.transform.childCount; i++)
                {
                    Destroy(monsterCollect2.transform.GetChild(monsterCollect2.transform.childCount-1 - i).gameObject);
                }
            }
            
        }
    }

    public void OnePlayerResultPanel()
    {
        resultMenu.SetActive(true);
        score1TextOnePEnd.text = "分數 : " + (killMonster1P * 100).ToString();
    }


    public void PKResultPanel() 
    {
        result2PMenu.SetActive(true);
        score2TextOnePEnd.text = "1P 分數 : " + (killMonster1P * 100).ToString();
        score2TextTwoPEnd.text = "2P 分數 : " + (killMonster2P * 100).ToString();
    }
}
