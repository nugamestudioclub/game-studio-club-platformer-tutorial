using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Class for controlling the timer UI display 
 */
public class Timer : MonoBehaviour
{
    private Text text;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        int seconds = (int)time;

        text.text = "Time : " + seconds;
    }
}
