using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Text scoreText;
    Countdown cd;
    Walking wk;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        cd = GetComponent<Countdown>();
        wk = GetComponent<Walking>();
    }

    // Update is called once per frame
    void Update()
    {
        score = (cd.htm * 60 + cd.hts) * wk.undoPoint;
        scoreText.text = score.ToString();
    }
}
