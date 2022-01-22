using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    public int monsterNum;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveToGoal();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            MoveToGoal();
        }
    }

    public void MoveToGoal() 
    {
        if (gameObject.transform.position.x > 0)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x-1, gameObject.transform.position.y);
        }
        else if (gameObject.transform.position.x < 0)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x + 1, gameObject.transform.position.y);
        }
    }

}
