using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class Player : MonoBehaviour
{

    public GameObject attackLeft, attackRight, comboAttackLeft, comboAttackRight;
    public int heroTeam;
    public bool cannotAtttack;
    public bool comboBuff = false;
    public float comboBuffTime = 3f;
    public float comboBuffLeft = 3f;
    int comboBuffNeedKill = 30;
    public Vector2 iniPos;

    //comboBuff 特效
    public GameObject comboEffect;
    // 震動特效
    public UpDown vibrationControl;
    //
    public SkeletonAnimation heroIdle, heroLeftHit, heroRightHit;
    public GameObject heroIdleObj, heroLeftHitObj, heroRightHitObj;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.GetComponent<Player>().heroTeam == 1)
        {
            heroIdle.initialSkinName = "Hero_1P";
            heroLeftHit.initialSkinName = "Hero_1P";
            heroRightHit.initialSkinName = "Hero_1P";
        }
        if (gameObject.GetComponent<Player>().heroTeam == 2)
        {
            heroIdle.initialSkinName = "Hero_2P";
            heroLeftHit.initialSkinName = "Hero_2P";
            heroRightHit.initialSkinName = "Hero_2P";
        }
        heroLeftHitObj.SetActive(false);
        heroRightHitObj.SetActive(false);


        if (iniPos.x == 0 && iniPos.y == 0)
        {
            iniPos = gameObject.transform.position;
        }

    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.A) && Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("AS done");
        }
        */

        if (comboBuff)
        {
            comboBuffLeft -= Time.deltaTime;
            Debug.Log("ComboBuff");
            if (comboBuffLeft <= 0)
            {
                comboBuff = false;
                comboEffect.SetActive(false);
                gameObject.tag = "Hero";
                // ComboBuffOffPlayer();
            }
        }

        if (comboBuff)
        {
            if (Input.GetKeyDown(KeyCode.D) /*Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S)*/)
            {
                if (heroTeam == 1)
                {
                    Attack(2);
                    GameManager.instance.MonsterGenerate();
                    AudioManager.instance.PlayNormalAttackP1();
                    vibrationControl.VibrationTurnOn(1);
                    Debug.Log("AASS done");
                }

            }
        }
        else if (Input.GetKeyDown(KeyCode.A) && cannotAtttack == false)
        {
            if (heroTeam == 1 && comboBuff == false)
            {
                Attack(0);


                GameManager.instance.MonsterGenerate();
                AudioManager.instance.PlayNormalAttackP1();
                vibrationControl.VibrationTurnOn(2);
                Debug.Log("A done");
            }
        }
        else if (Input.GetKeyDown(KeyCode.S) && cannotAtttack == false)
        {
            if (heroTeam == 1 && comboBuff == false)
            {
                Attack(1);
                GameManager.instance.MonsterGenerate();
                AudioManager.instance.PlayNormalAttackP1();
                vibrationControl.VibrationTurnOn(1);
                Debug.Log("S done");
            }
        }

        if (comboBuff)
        {
            if (Input.GetKeyDown(KeyCode.L)/*Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L)*/)
            {
                if (heroTeam == 2)
                {
                    Attack(2);
                    GameManager.instance.MonsterGenerate2P();
                    AudioManager.instance.PlayNormalAttackP2();
                    vibrationControl.VibrationTurnOn(1);
                    Debug.Log("AASS done");
                }

            }
        }
        else if (Input.GetKeyDown(KeyCode.J) && cannotAtttack == false)
        {
            if (heroTeam == 2 && comboBuff == false)
            {
                Attack(0);
                GameManager.instance.MonsterGenerate2P();
                AudioManager.instance.PlayNormalAttackP2();
                vibrationControl.VibrationTurnOn(1);
            }
        }
        else if (Input.GetKeyDown(KeyCode.K) && cannotAtttack == false)
        {
            if (heroTeam == 2 && comboBuff == false)
            {
                Attack(1);
                GameManager.instance.MonsterGenerate2P();
                AudioManager.instance.PlayNormalAttackP2();
                vibrationControl.VibrationTurnOn(1);
            }
        }
    }

    public void Attack(int num)
    {
        //attackLeft.SetActive(false);
        // attackRight.SetActive(false);

        StartCoroutine(ShowAtk(num));
    }

    IEnumerator ShowAtk(int atkNum)
    {
        //attackLeft.SetActive(false);
        //attackRight.SetActive(false);

        if (atkNum == 0)
        {
            attackLeft.SetActive(true);
            attackRight.SetActive(false);
        }
        else if (atkNum == 1)
        {
            attackLeft.SetActive(false);
            attackRight.SetActive(true);
        }
        else if (atkNum == 2)
        {
            //ComboBuffOnPlayer();

            comboAttackLeft.SetActive(true);
            comboAttackRight.SetActive(true);
        }

        yield return new WaitForSeconds(0.1f);

        attackLeft.SetActive(false);
        attackRight.SetActive(false);
        comboAttackLeft.SetActive(false);
        comboAttackRight.SetActive(false);

        //需要判斷 1P 或 2P 怪 需要移動
        // monster move
        if (heroTeam == 1)
        {
            for (int i = 0; i < GameManager.instance.monsterCollect1.transform.childCount; i++)
            {
                GameManager.instance.monsterCollect1.transform.GetChild(i).gameObject.GetComponent<MonsterMove>().MoveToGoal();
            }
        }
        else if (heroTeam == 2)
        {
            for (int i = 0; i < GameManager.instance.monsterCollect2.transform.childCount; i++)
            {
                GameManager.instance.monsterCollect2.transform.GetChild(i).gameObject.GetComponent<MonsterMove>().MoveToGoal();
            }
        }

        if (atkNum == 0)
        {
            StopAllCoroutines();
            StartCoroutine(HeroLeftAttack());
        }
        else if (atkNum == 1)
        {
            StopAllCoroutines();
            StartCoroutine(HeroRightAttack());
        }


    }

    public void MonsterTouch()
    {
        cannotAtttack = true;
        if (heroTeam == 1)
        {
            GameManager.instance.combo1P = 0;
            AudioManager.instance.PlayerBeAttackP1();
        }
        else if (heroTeam == 2)
        {
            GameManager.instance.combo2P = 0;
            AudioManager.instance.PlayerBeAttackP2();
        }
        StartCoroutine(MonsterTouchIn2P_IE());

    }

    IEnumerator MonsterTouchIn2P_IE()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        Debug.Log("MonsterTouch");
        float goal = gameObject.transform.position.y + 1.5f;
        float initial = gameObject.transform.position.y;

        // 撥放動畫

        while (gameObject.transform.position.y < goal)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 0.1f);
            yield return new WaitForSeconds(0.0166f);
            if (gameObject.transform.position.y >= goal)
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, goal);
            }
        }

        yield return new WaitForSeconds(0.1f);
        while (gameObject.transform.position.y > initial)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.1f);
            yield return new WaitForSeconds(0.0166f);
            if (gameObject.transform.position.y <= initial)
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, initial);
            }
        }

        cannotAtttack = false; // 恢復可攻擊
        gameObject.GetComponent<BoxCollider2D>().enabled = true; //恢復可被碰撞
    }

    public void ComboBuffOn()
    {
        if (GameManager.instance.combo1P >= comboBuffNeedKill && heroTeam == 1)
        {
            comboEffect.SetActive(true);
            comboEffect.transform.GetChild(0).gameObject.GetComponent<AnimationIndex>().SetCharacterState("redFire");
            //comboEffect.GetComponent<BuffConboEffect>().PlayerFireEffect(heroTeam);
            gameObject.tag = "Attack";
            GameManager.instance.combo1P = 0;// combo歸零
            comboBuff = true;
            comboBuffLeft = comboBuffTime;
        }
        else if (GameManager.instance.combo2P >= comboBuffNeedKill && heroTeam == 2)
        {
            comboEffect.SetActive(true);
            comboEffect.transform.GetChild(0).gameObject.GetComponent<AnimationIndex>().SetCharacterState("blueFire");
            //comboEffect.GetComponent<BuffConboEffect>().PlayerFireEffect(heroTeam);
            gameObject.tag = "Attack";
            GameManager.instance.combo2P = 0;// combo歸零
            comboBuff = true;
            comboBuffLeft = comboBuffTime;
        }
    }

    public void PlayerInitial()
    {
        gameObject.transform.position = iniPos;
        cannotAtttack = false;
        comboBuff = false;
        comboEffect.SetActive(false);
        comboBuffLeft = 3f;
        //動作初始化
        heroIdleObj.SetActive(true);
        heroLeftHitObj.SetActive(false);
        heroRightHitObj.SetActive(false);
    }

  
    

    public void ComboBuffOnPlayer() 
    {
        if (heroTeam == 1)
        {
            for (int i = 0; i < GameManager.instance.monsterCollect1.transform.childCount; i++)
            {
                GameManager.instance.monsterCollect1.transform.GetChild(i).gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        else if (heroTeam == 2)
        {
            for (int i = 0; i < GameManager.instance.monsterCollect2.transform.childCount; i++)
            {
                GameManager.instance.monsterCollect2.transform.GetChild(i).gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }

    public void ComboBuffOffPlayer()
    {
        if (heroTeam == 1)
        {
            for (int i = 0; i < GameManager.instance.monsterCollect1.transform.childCount; i++)
            {
                GameManager.instance.monsterCollect1.transform.GetChild(i).gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
        else if (heroTeam == 2)
        {
            for (int i = 0; i < GameManager.instance.monsterCollect2.transform.childCount; i++)
            {
                GameManager.instance.monsterCollect2.transform.GetChild(i).gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }


    public void AftetBuffReset() 
    {
        //暫時關閉所有碰撞體
        for (int i = 0; i < GameManager.instance.monsterCollect1.transform.childCount; i++)
        {
            GameManager.instance.monsterCollect1.transform.GetChild(i).gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }

        //reset 位置
        for (int i = 0; i < GameManager.instance.monsterCollect1.transform.childCount; i++)
        {
            

            if (GameManager.instance.monsterCollect1.transform.GetChild(GameManager.instance.monsterCollect1.transform.childCount-1-i).gameObject.transform.position.x % 1 !=0) 
            {
                float xReSet;

                xReSet = Mathf.Round(GameManager.instance.monsterCollect1.transform.GetChild(i).position.x);
                Debug.Log("i = " + i + "posX  = " + xReSet);
                GameManager.instance.monsterCollect1.transform.GetChild(i).position = new Vector2(xReSet, GameManager.instance.monsterCollect1.transform.GetChild(i).position.y);
                
            }
            else
            {
                Debug.Log("NoNO " + i);
            }
        }
    }

    IEnumerator HeroLeftAttack() 
    {
        
        heroIdleObj.SetActive(false);
        heroLeftHitObj.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        heroIdleObj.SetActive(true);
        heroLeftHitObj.SetActive(false);

    }

    IEnumerator HeroRightAttack()
    {
        heroIdleObj.SetActive(false);
        heroRightHitObj.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        heroIdleObj.SetActive(true);
        heroRightHitObj.SetActive(false);

    }
}
