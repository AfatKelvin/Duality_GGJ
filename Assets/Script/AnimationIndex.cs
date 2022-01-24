using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;


public class AnimationIndex : MonoBehaviour
{
    public SkeletonAnimation skeletonAnimation;
    public AnimationReferenceAsset start1,idle,redFire,blueFire,blackDie,whiteDie,heroIdle,hit;
    public string currenetState;
    public bool loop;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAnimation (AnimationReferenceAsset animation, bool loop, float timeScale) 
    {
        skeletonAnimation.state.SetAnimation(0, animation, loop).TimeScale = timeScale; //設定動畫的相關狀態
    }

    public void SetCharacterState(string state) //選擇要撥放的動畫
    {
        if (state == "idle")
        {
            SetAnimation(idle, true, 1);
            if (!loop)
            {
                SetAnimation(idle, false, 1);// 如果只要撥放一次
            }
            //SetAnimation(idle, false, 1); 如果只要撥放一次
        }
        else if (state == "start")
        {
            SetAnimation(start1, true, 1);
            if (!loop)
            {
                if (GameManager.instance.memberPanel.activeInHierarchy ==true)
                {
                    StartCoroutine(MemBerFlag_IE());
                }
                else if (GameManager.instance.resultMenu.activeInHierarchy == true)
                {
                    StartCoroutine(Result1P_IE());
                }
                else if (GameManager.instance.result2PMenu.activeInHierarchy == true)
                {
                    StartCoroutine(Result2P_IE());
                }
                SetAnimation(start1, false, 1);// 如果只要撥放一次
            }
            //SetAnimation(idle, false, 1); 如果只要撥放一次
        }
        else if (state == "redFire")
        {
            SetAnimation(redFire, true, 1);
            
            //SetAnimation(idle, false, 1); 如果只要撥放一次
        }
        else if (state == "blueFire")
        {
            SetAnimation(blueFire, true, 1);
            
            //SetAnimation(idle, false, 1); 如果只要撥放一次
        }
        else if (state == "blackDie")
        {
            SetAnimation(blackDie, true, 1f);

            //SetAnimation(blackDie, false, 1f); //如果只要撥放一次
        }
        else if (state == "whiteDie")
        {
            SetAnimation(whiteDie, true, 1f);

            //SetAnimation(whiteDie, false, 1f); //如果只要撥放一次
        }
        else if (state == "heroIdle")
        {
            if (gameObject.transform.parent.gameObject.GetComponent<Player>().heroTeam == 1)
            {
                skeletonAnimation.initialSkinName = "Hero_1P";
            }
            if (gameObject.transform.parent.gameObject.GetComponent<Player>().heroTeam == 2)
            {
                skeletonAnimation.initialSkinName = "Hero_2P";
            }
            SetAnimation(heroIdle, true, 1f);
        }
        else if (state == "hit")
        {
            if (gameObject.transform.parent.gameObject.GetComponent<Player>().heroTeam == 1)
            {
                skeletonAnimation.initialSkinName = "Hero_1P";
            }
            if (gameObject.transform.parent.gameObject.GetComponent<Player>().heroTeam == 2)
            {
                skeletonAnimation.initialSkinName = "Hero_2P";
            }
            SetAnimation(heroIdle, true, 1f);
            SetAnimation(heroIdle, false, 1f);
        }
    }


    IEnumerator MemBerFlag_IE() 
    {
        yield return new WaitForSeconds(1f);
        GameManager.instance.memberUISet.SetActive(true);
    }

    IEnumerator Result1P_IE()
    {
        yield return new WaitForSeconds(1f);
        GameManager.instance.result1PUISet.SetActive(true);
    }

    IEnumerator Result2P_IE()
    {
        yield return new WaitForSeconds(1f);
        GameManager.instance.result2PUISet.SetActive(true);
    }
}
