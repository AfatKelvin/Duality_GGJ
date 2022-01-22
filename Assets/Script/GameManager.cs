using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject monsterWhite1,monsterBlack1, monsterWhite2, monsterBlack2;
    public GameObject monsterCollect1, monsterCollect2;
    public GameObject mainMenu,resiltMenu;
    public GameObject onePSet, twoPSet;
    public bool p1only = true;
    public int killMonster1P, killMonster2P;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        //MonsterInitial();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            MonsterGenerate();
        }

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

        p1only = onePlayer; //判斷幾P
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
        for (int i = 0; i < monsterCollect1.transform.childCount; i++)
        {
            Destroy(monsterCollect1.transform.GetChild(0));
        }
        // 清除舊有 2P 怪物
        if (p1only ==false)
        {
            for (int i = 0; i < monsterCollect2.transform.childCount; i++)
            {
                Destroy(monsterCollect2.transform.GetChild(0));
            }
        }
        

        //
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
        resiltMenu.SetActive(false);
    }
    public void ShowResult()
    {
        resiltMenu.SetActive(true);
    }
}
