using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    public string monsterName;
    public int monsterNum; //for �XP���Ǫ�
    public SpriteRenderer showSpriteRender;
    public Sprite beAttackedSprite;
    public bool postAttack =false; //�w�Q�~�L
    public Sprite[] monsterDie;

    public Player playerSet;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.instance.p1only ==false)
        {
            if (monsterNum==1)
            {
                playerSet = GameObject.Find("Hero1In2P").GetComponent<Player>();
            }
            else if (monsterNum == 2)
            {
                playerSet = GameObject.Find("Hero2In2P").GetComponent<Player>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(gameObject.transform.position.x) <= 1.1f)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }


        /*
        if (GameManager.instance.p1only == false && playerSet.comboBuff)
        {
            if (gameObject.transform.position.x > 0 && gameObject.transform.position.x % 1 != 0)
            {
                if (monsterNum == 1)
                {
                    gameObject.transform.position = new Vector2(1, -4);
                }
                else
                {
                    gameObject.transform.position = new Vector2(1, 2);
                }

            }
            else if (gameObject.transform.position.x < 0 && gameObject.transform.position.x % 1 != 0)
            {
                if (monsterNum == 1)
                {
                    gameObject.transform.position = new Vector2(-1, -4);
                }
                else
                {
                    gameObject.transform.position = new Vector2(-1, 2);
                }
            }
        }
        
       */
    }

    public void MoveToGoal()
    {
        if (gameObject.transform.position.x > 0 && postAttack ==false)
        {

            //StartCoroutine(Move()); //����I��
            gameObject.transform.position = new Vector2(gameObject.transform.position.x - 1, gameObject.transform.position.y);
        }
        else if (gameObject.transform.position.x < 0 && postAttack == false)
        {
            //StartCoroutine(Move()); //����I��
            gameObject.transform.position = new Vector2(gameObject.transform.position.x + 1, gameObject.transform.position.y);
        }
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Attack")
        {
            //Debug.Log("kill " + gameObject.name);

            if (collision.gameObject.transform.parent.gameObject.GetComponent<Player>().heroTeam == 1 )
            {
                GameManager.instance.killMonster1P += 1;
                GameManager.instance.combo1P += 1;
                //�Ǫ��Q�~����
                if (monsterName == "White")
                {
                    AudioManager.instance.PlayWhiteInP1();
                }
                else if (monsterName == "Black")
                {
                    AudioManager.instance.PlayBlackInP1();
                }
                //�p��g��combo�O�_�F��
                if (GameManager.instance.combo1P>=30 && GameManager.instance.p1only ==false)
                {
                    collision.gameObject.transform.parent.gameObject.GetComponent<Player>().ComboBuffOn();
                }
            }
            else if (collision.gameObject.transform.parent.gameObject.GetComponent<Player>().heroTeam == 2 )
            {
                GameManager.instance.killMonster2P += 1;
                GameManager.instance.combo2P += 1;
                //�Ǫ��Q�~����
                if (monsterName == "White")
                {
                    AudioManager.instance.PlayWhiteInP2();
                }
                else if (monsterName == "Black")
                {
                    AudioManager.instance.PlayBlackInP2();
                }
                //�p��g��combo�O�_�F��
                if (GameManager.instance.combo2P >= 30 && GameManager.instance.p1only == false)
                {
                    collision.gameObject.transform.parent.gameObject.GetComponent<Player>().ComboBuffOn();
                }
            }

            //feve Mode�P�w


            GameManager.instance.ScoreRenew();
            postAttack = true; // �аO �Ǥw�Q�~�L
            MonterBackMove();
            //Destroy(gameObject);

        }
        else if (collision.tag == "Hero")
        {
            if (GameManager.instance.p1only)
            {
                Debug.Log("kill " + collision.gameObject.name);
                //collision.gameObject.SetActive(false);
                //Destroy(collision.gameObject);
                GameManager.instance.ShowResult();
            }
            else if (GameManager.instance.p1only == false)
            {
                Debug.Log("Need MonsterTouch");
                if (playerSet.comboBuff)
                {
                    Destroy(gameObject);
                }
                else
                {
                    collision.gameObject.GetComponent<Player>().MonsterTouch();
                    Destroy(gameObject);
                }
                
            }

        }

    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Hero")
        {
            if (GameManager.instance.p1only)
            {
                Debug.Log("kill " + collision.gameObject.name);
                //collision.gameObject.SetActive(false);
                //Destroy(collision.gameObject);
                GameManager.instance.ShowResult();
            }
            else if (GameManager.instance.p1only == false)
            {
                Debug.Log("Need MonsterTouch");
                if (playerSet.comboBuff)
                {
                    Destroy(gameObject);
                }
                else
                {
                    collision.gameObject.GetComponent<Player>().MonsterTouch();
                    Destroy(gameObject);
                }

            }
        }
    }


    public void MonterBackMove()  //�Ǯ��~�ʵe
    {
        StartCoroutine(BeAttack());
    }

    IEnumerator BeAttack() 
    {
        showSpriteRender.sprite = beAttackedSprite;

        float backPointion = 0f; //�P�_��m
        if (monsterName == "White") //�P�_������h
        {
            backPointion = gameObject.transform.position.x + 1.5f;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.transform.position = new Vector2(2, gameObject.transform.position.y);
        }
        else if (monsterName == "Black")
        {
            backPointion = gameObject.transform.position.x -1.5f;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.transform.position = new Vector2(-2, gameObject.transform.position.y);
        }

        if (monsterName == "White") //�첾
        {
            bool animStart = false;
            while (gameObject.transform.position.x < backPointion)
            {
                gameObject.transform.position =new Vector2(gameObject.transform.position.x + 0.075f, gameObject.transform.position.y);
                showSpriteRender.color = new Color(showSpriteRender.color.r, showSpriteRender.color.g, showSpriteRender.color.b, (backPointion - gameObject.transform.position.x +0.5f) / 1.5f);
                if (animStart ==false)
                {
                    gameObject.transform.GetChild(1).gameObject.SetActive(true);
                    gameObject.transform.GetChild(1).gameObject.GetComponent<AnimationIndex>().SetCharacterState("whiteDie");
                    animStart = true;
                }
                /*showSpriteRender.sprite = monsterDie[dieSpriteNum];
                dieSpriteNum += 1;
                if (dieSpriteNum>= monsterDie.Length)
                {
                    dieSpriteNum = monsterDie.Length - 1;
                }
                */
                yield return new WaitForSeconds(0.1f);
            }
        }
        else if (monsterName == "Black")
        {
            bool animStart =false;
            while (gameObject.transform.position.x > backPointion)
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x - 0.075f, gameObject.transform.position.y);
                showSpriteRender.color = new Color(showSpriteRender.color.r, showSpriteRender.color.g, showSpriteRender.color.b, (gameObject.transform.position.x-backPointion+0.5f) / 1.5f);

                if (animStart == false)
                {
                    gameObject.transform.GetChild(1).gameObject.SetActive(true);
                    gameObject.transform.GetChild(1).gameObject.GetComponent<AnimationIndex>().SetCharacterState("blackDie");
                    animStart = true;
                }
                
                /*
                 * //showSpriteRender.sprite = monsterDie[dieSpriteNum];
                dieSpriteNum += 1;
                if (dieSpriteNum >= monsterDie.Length)
                {
                    dieSpriteNum = monsterDie.Length - 1;
                }
                */
                yield return new WaitForSeconds(0.1f);
            }
        }

        Destroy(gameObject);
    }

    /*
    IEnumerator Move() 
    {
        if (gameObject.transform.position.x > 0) 
        {
            float initial = gameObject.transform.position.x;
            float goal = gameObject.transform.position.x - 1;
        }
        if (gameObject.transform.position.x < 0)
        {
            float initial = gameObject.transform.position.x;
            float goal = gameObject.transform.position.x + 1;
        }
    }
    */

}
