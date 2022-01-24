using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioClip[] sfx;
    public AudioSource audioSource1,audioSourceMonster1, audioSourceMonster2, hero1audioSource, hero2audioSource;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayrButtonEffect() 
    {
        audioSource1.clip = sfx[0];
        audioSource1.Play();
    }

    public void PlayNormalAttackP1() 
    {
        hero1audioSource.clip = sfx[1];
        hero1audioSource.Play();
    }
    public void PlayNormalAttackP2()
    {
        hero2audioSource.clip = sfx[1];
        hero2audioSource.Play();
    }

    public void PlayerBeAttackP1()
    {
        hero1audioSource.clip = sfx[4];
        hero1audioSource.Play();
    }
    public void PlayerBeAttackP2()
    {
        hero2audioSource.clip = sfx[4];
        hero2audioSource.Play();
    }


    public void PlayBlackInP1()
    {
        audioSourceMonster1.clip = sfx[2];
        audioSourceMonster1.Play();
    }

    public void PlayWhiteInP1()
    {
        audioSourceMonster1.clip = sfx[3];
        audioSourceMonster1.Play();
    }

    public void PlayBlackInP2()
    {
        audioSourceMonster2.clip = sfx[2];
        audioSourceMonster2.Play();
    }

    public void PlayWhiteInP2()
    {
        audioSourceMonster2.clip = sfx[3];
        audioSourceMonster2.Play();
    }
}
