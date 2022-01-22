using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    public int monsterNum; //for �XP���Ǫ�
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

            //StartCoroutine(Move()); //����I��
            gameObject.transform.position = new Vector2(gameObject.transform.position.x-1, gameObject.transform.position.y);
        }
        else if (gameObject.transform.position.x < 0)
        {
            //StartCoroutine(Move()); //����I��
            gameObject.transform.position = new Vector2(gameObject.transform.position.x + 1, gameObject.transform.position.y);
        }
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Attack")
        {
            Debug.Log("kill " + gameObject.name);
            
            if (collision.gameObject.transform.parent.gameObject.GetComponent<Player>().heroTeam == 1)
            {
                GameManager.instance.killMonster1P += 1;
            }
            else if (collision.gameObject.transform.parent.gameObject.GetComponent<Player>().heroTeam == 2)
            {
                GameManager.instance.killMonster2P += 1;
            }

            
            Destroy(gameObject);

        }
        else if (collision.tag == "Hero")
        {
            if (GameManager.instance.p1only)
            {
                Debug.Log("kill " + collision.gameObject.name);
                collision.gameObject.SetActive(false);
                //Destroy(collision.gameObject);
                GameManager.instance.ShowResult();
            }
            else if(GameManager.instance.p1only == false)
            {
                collision.gameObject.GetComponent<Player>().MonsterTouch();
            }
           
        }
        
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
