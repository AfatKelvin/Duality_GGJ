using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    public string monsterName;
    public int monsterNum; //for ´XPªº©Çª«
    public SpriteRenderer showSpriteRender;
    public Sprite beAttackedSprite;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (gameObject.transform.position.x <=0.1f && gameObject.transform.position.x >= -0.1f)
        {
            gameObject.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        */
        /*
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveToGoal();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            MoveToGoal();
        }
        */
    }

    public void MoveToGoal()
    {
        if (gameObject.transform.position.x > 0)
        {

            //StartCoroutine(Move()); //©µ¿ð¸I¼²
            gameObject.transform.position = new Vector2(gameObject.transform.position.x - 1, gameObject.transform.position.y);
        }
        else if (gameObject.transform.position.x < 0)
        {
            //StartCoroutine(Move()); //©µ¿ð¸I¼²
            gameObject.transform.position = new Vector2(gameObject.transform.position.x + 1, gameObject.transform.position.y);
        }
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Attack")
        {
            //Debug.Log("kill " + gameObject.name);

            if (collision.gameObject.transform.parent.gameObject.GetComponent<Player>().heroTeam == 1)
            {
                GameManager.instance.killMonster1P += 1;
                GameManager.instance.combo1P += 1;
            }
            else if (collision.gameObject.transform.parent.gameObject.GetComponent<Player>().heroTeam == 2)
            {
                GameManager.instance.killMonster2P += 1;
                GameManager.instance.combo2P += 1;
            }

            GameManager.instance.ScoreRenew();

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
                collision.gameObject.GetComponent<Player>().MonsterTouch();
                Destroy(gameObject);
            }

        }

    }

    public void MonterBackMove()  //©Ç®Á´~°Êµe
    {
        StartCoroutine(BeAttack());
    }

    IEnumerator BeAttack() 
    {
        showSpriteRender.sprite = beAttackedSprite;

        float backPointion = 0f; //§PÂ_¦ì¸m
        if (monsterName == "White") //§PÂ_©¹­þÃä°h
        {
            backPointion = gameObject.transform.position.x + 0.5f;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else if (monsterName == "Black")
        {
            backPointion = gameObject.transform.position.x -0.5f;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }

        if (monsterName == "White") //¦ì²¾
        {
            while (gameObject.transform.position.x < backPointion)
            {
                gameObject.transform.position =new Vector2(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y);

                yield return new WaitForSeconds(0.1f);
            }
        }
        else if (monsterName == "Black")
        {
            while (gameObject.transform.position.x > backPointion)
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y);
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
