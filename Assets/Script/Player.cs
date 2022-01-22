using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public GameObject attackLeft, attackRight;
    public int heroTeam;
    bool atttack;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (heroTeam == 1)
            {
                Attack(0);
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (heroTeam == 1)
            {
                Attack(1);
            }
        }


        if (Input.GetKeyDown(KeyCode.K))
        {
            if (heroTeam == 2)
            {
                Attack(0);
            }
        }
        if (Input.GetKeyDown(KeyCode.L))
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

        // monster move
        for (int i = 0; i < GameManager.instance.monsterCollect1.transform.childCount; i++)
        {
            GameManager.instance.monsterCollect1.transform.GetChild(i).gameObject.GetComponent<MonsterMove>().MoveToGoal();
        }

    }




}
