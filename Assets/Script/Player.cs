using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public GameObject attackLeft, attackRight;
    public int heroTeam;
    bool cannotAtttack;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && cannotAtttack ==false)
        {
            if (heroTeam == 1)
            {
                Attack(0);
            }
        }
        if (Input.GetKeyDown(KeyCode.S) && cannotAtttack == false)
        {
            if (heroTeam == 1)
            {
                Attack(1);
            }
        }


        if (Input.GetKeyDown(KeyCode.K) && cannotAtttack == false)
        {
            if (heroTeam == 2)
            {
                Attack(0);
            }
        }
        if (Input.GetKeyDown(KeyCode.L) && cannotAtttack == false)
        {
            if (heroTeam == 2)
            {
                Attack(1);
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

        if (atkNum ==0)
        {
            attackLeft.SetActive(true);
            attackRight.SetActive(false);
        }
        else if (atkNum == 1)
        {
            attackLeft.SetActive(false);
            attackRight.SetActive(true);
        }

        yield return new WaitForSeconds(0.1f);

        attackLeft.SetActive(false);
        attackRight.SetActive(false);


        //�ݭn�P�_ 1P �� 2P �� �ݭn����
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



    }

    public void MonsterTouch() 
    {
        cannotAtttack = true;
        StartCoroutine(MonsterTouchIn2P_IE());
        cannotAtttack = false;
    }

    IEnumerator MonsterTouchIn2P_IE() 
    {
        float goal = gameObject.transform.position.y + 1.5f;
        float initial = gameObject.transform.position.y;
        // ����ʵe

        while (gameObject.transform.position.y < goal)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 0.1f);
            yield return new WaitForSeconds(0.1f);
            if (gameObject.transform.position.y >= goal)
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, goal);
            }
        }
        yield return new WaitForSeconds(0.1f);
        while (gameObject.transform.position.y > initial)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.1f);
            yield return new WaitForSeconds(0.1f);
            if (gameObject.transform.position.y <= initial)
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, initial);
            }
        }


    }


}
