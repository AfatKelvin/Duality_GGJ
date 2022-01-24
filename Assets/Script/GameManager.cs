using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine.Unity;

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
    //game �i��ɤ���
    public GameObject score1, score2;
    public Text score1TextOneP, score2TextOneP, score2TextTwoP;
    public Text combo1PText, combo2PText;
    //����ɤ���
    public Text score1TextOnePEnd, score2TextOnePEnd, score2TextTwoPEnd, winLosJudgeText1P,winLosJudgeText2P;
    public Player playerOne, playerTwo, playerOneIn1P;
    public GameObject result1PUISet, result2PUISet, mainUISet,memberUISet;
    public AnimationIndex end1PAnim, end2PAnim, memberAnim;



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
            //DestroyOldMonster();
            //Destroy(monsterCollect1.transform.GetChild(0).gameObject);
            //Test();
        }
        

    }

    public void MonsterGenerate() //�էO1 �Ǫ��l��
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

    public void MonsterGenerate2P() //�էO2 �Ǫ��l��
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

        // --------------------------- ��l��---------
        

        killMonster1P = 0; //��l��������
        killMonster2P = 0;

        combo1P = 0;
        combo2P = 0;
        

        p1only = onePlayer; //�P�_�XP

        // on / off ����set
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

        ScoreRenew(); // ���ƭp��

        //���ͫi�̪�l�ƾ�
        if (p1only)
        {
            onePSet.SetActive(true);
            twoPSet.SetActive(false);
            playerOneIn1P.PlayerInitial();

        }
        else
        {
            onePSet.SetActive(false);
            twoPSet.SetActive(true);

            playerOne.PlayerInitial();
            playerTwo.PlayerInitial();
            TimeCounter.instance.timeLeft = TimeCounter.instance.timeInitail;
        }

        // �M���¦� 1P �Ǫ�

        DestroyOldMonster();
        
        /*
        if (monsterCollect1.transform.childCount>0)
        {
            for (int i = 0; i < 8; i++)
            {
                Destroy(monsterCollect1.transform.GetChild(0).gameObject);
            }
        }
        */
        

        // ���ͩǪ�
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
        DestroyOldMonster();
        mainMenu.SetActive(true);
    }
    public void CloseResult()
    {
        resultMenu.SetActive(false);
    }

    public void CloseResult2P()
    {
        result2PMenu.SetActive(false);
    }
    public void ShowResult()
    {
        result1PUISet.SetActive(false);
        score1.SetActive(false);
        resultMenu.SetActive(true);
        onePSet.SetActive(false);
        end1PAnim.SetCharacterState("start");
        //result1PUISet.SetActive(true);
        //SpineManager.instance.Close1PFlagStart();
        score1TextOnePEnd.text = ""+killMonster1P.ToString();
    }

    public void ShowMemberPanel()
    {
        memberPanel.SetActive(true);
        mainUISet.SetActive(false);
        memberAnim.SetCharacterState("start");
    }

    public void CloseMemberPanel()
    {

        mainUISet.SetActive(true);
        memberPanel.SetActive(false);
    }



    public void ScoreRenew() 
    {
        if (p1only)
        {
            score1TextOneP.text = " ���M�h�����F" + (killMonster1P).ToString() + " ��";
        }
        else if (!p1only)
        {
            score2TextOneP.text = " ���M�h�����F" + (killMonster1P).ToString() + " ��";
            score2TextTwoP.text = " ���M�h�����F" + (killMonster2P).ToString() + " ��";

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
        

        // �M���¦� 2P �Ǫ�
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
        score1TextOnePEnd.text = "" + (killMonster1P * 100).ToString();
    }


    public void PKResultPanel()
    {
        result2PUISet.SetActive(false);
        score2.SetActive(false);
        result2PMenu.SetActive(true);
        twoPSet.SetActive(false);
        end2PAnim.SetCharacterState("start");
        //result2PUISet.SetActive(true);
        //SpineManager.instance.Close2PFlagStart();
        score2TextOnePEnd.text = "" + (killMonster1P).ToString();
        score2TextTwoPEnd.text = "" + (killMonster2P).ToString();

        if (killMonster1P > killMonster2P)
        {
            winLosJudgeText2P.text = "�� �� �� �h�����F " + (killMonster1P - killMonster2P).ToString() + " �� ";
        }
        else if (killMonster1P < killMonster2P)
        {
            winLosJudgeText2P.text = "�� �� �� �h�����F " + (killMonster2P - killMonster1P).ToString() + " �� ";
        }
        else
        {
            winLosJudgeText2P.text = "�� �M �� ����";
        }
        //�i�̰ʧ@��l��
        
    }

    public void LeaveGame()
    {
        Application.Quit();
    }
}
