using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextShining : MonoBehaviour
{
    public float localScale = 2;
    public bool growUp = true;
    public float textScale = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator  ScaleDown() 
    {
        float tempScale = localScale;
        while (tempScale >=1)
        {
            gameObject.transform.localScale = new Vector2(tempScale, tempScale);
            tempScale -= 0.05f;
            yield return new WaitForSeconds(0.05f);
        }
        
    }
}
