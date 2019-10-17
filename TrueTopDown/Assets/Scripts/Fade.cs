using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Fade : MonoBehaviour
{
    public Color color;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        color.a = color.a - Time.deltaTime / 5;
        GetComponent<Text>().color = color;
    }
}
