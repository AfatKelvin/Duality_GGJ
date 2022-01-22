using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextShining : MonoBehaviour
{
    public float timeTotal = 10f;
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


    IEnumerator  GrowUp() 
    {
        while (textScale<2)
        {
            textScale += 0.1f;
            gameObject.transform.localScale = new Vector2(textScale, textScale);
            yield return new WaitForSeconds(0.1f);
        }
        
    }
}
