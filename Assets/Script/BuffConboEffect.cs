using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffConboEffect : MonoBehaviour
{
    public Sprite[] blueSet, redSet;
    public SpriteRenderer spriteRenderer1;
    public bool combo;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerFireEffect(int hero) 
    {
        combo = true;
        StartCoroutine(PlayFire(hero));
    }


    IEnumerator PlayFire( int hero) 
    {
        int temp = 0;
        int count = 0;
        while (combo)
        {
            count += 1;
            if (hero == 1)
            {
                spriteRenderer1.sprite = redSet[temp];
                temp += 1;
                if (temp >= 4)
                {
                    temp = 0;
                }
                yield return new WaitForSeconds(0.066f);
            }
            else if (hero == 2)
            {
                spriteRenderer1.sprite = blueSet[temp];
                temp += 1;
                if (temp >= 4)
                {
                    temp = 0;
                }
                yield return new WaitForSeconds(0.066f);
            }
            if (count>=45)
            {
                combo = false;
            }

        }
        //yield return new WaitForSeconds(0.066f);
    }
}
