using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    //Countdown cd;
    [SerializeField] Text countdownText;




    // Start is called before the first frame update
    void Start()
    {
        //cd = GetComponent<Countdown>();
    }

    // Update is called once per frame
    void Update()
    {
        if(countdownText.text == "00:00")
        {

        }
    }
}
