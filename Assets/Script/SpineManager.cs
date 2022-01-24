using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpineManager : MonoBehaviour
{
    public static SpineManager instance;

    public GameObject homeStart; // homeStartSpine;
    public float homeStartToIdleTime = 2f; // homeStartSpine translate time;

    public GameObject end1PFlagStart; // 分數結算 1P
    public float end1PFlagStartToIdleTime = 1f; // homeStartSpine translate time;

    public GameObject end2PFlagStart; // 分數結算 1P
    public float end2PFlagStartToIdleTime = 1f; // homeStartSpine translate time;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        CloseHomeStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseHomeStart() 
    {
        StartCoroutine(CloseHomeStart_IE());
    }

    IEnumerator CloseHomeStart_IE() 
    {
        yield return new WaitForSeconds(2f);
        homeStart.SetActive(false);
    }

    // retrigger

    public void RetriggerResult1P() 
    {
        
    }

    IEnumerator RetriggerResult1P_IE()
    {
        yield return new WaitForSeconds(1f);
        end1PFlagStart.SetActive(false);
    }


    public void RetriggerResult2P()
    {

    }



    public void Close1PFlagStart()
    {
        StartCoroutine(Close1PFlagStart_IE());
    }

    IEnumerator Close1PFlagStart_IE()
    {
        yield return new WaitForSeconds(1f);
        end1PFlagStart.SetActive(false);
    }

    public void Close2PFlagStart()
    {
        StartCoroutine(Close2PFlagStart_IE());
    }

    IEnumerator Close2PFlagStart_IE()
    {
        yield return new WaitForSeconds(1f);
        end2PFlagStart.SetActive(false);
    }
}
