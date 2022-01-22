using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    public int monsterNum; //for ´XPªº©Çª«
    
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

            //StartCoroutine(Move()); //©µ¿ð¸I¼²
            gameObject.transform.position = new Vector2(gameObject.transform.position.x-1, gameObject.transform.position.y);
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
            Debug.Log("kill " + gameObject.name);
            Destroy(gameObject);

        }
        else if (collision.tag == "Hero")
        {
            Debug.Log("kill " + collision.gameObject.name);
            collision.gameObject.SetActive(false);
            //Destroy(collision.gameObject);
            GameManager.instance.ShowResult();
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
