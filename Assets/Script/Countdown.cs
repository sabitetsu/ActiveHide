using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    [SerializeField] Text countdownText;
    [SerializeField] Text hideTimeText;
    [SerializeField] GameObject Result;
    [SerializeField] GameObject TimeNum;
    [SerializeField] GameObject UPNum;
    [SerializeField] GameObject ScoreNum;
    [SerializeField] Text TimeNumText;
    [SerializeField] Text UPNumText;
    Walking wk;


    public float limitTime;
    float countdown;
    int cdm; //countdownMinits
    int cds; //countdownSeconds

    float hideTime = 1;
    public int htm;
    public int hts;
    public bool hiding = true;

    // Start is called before the first frame update
    void Start()
    {
        wk = GetComponent<Walking>();
        limitTime = PlayerPrefs.GetFloat("limitTime");
        countdown = limitTime;
        cdm = (int)countdown / 60;
        cds = (int)countdown % 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (cdm != 0 || cds != 0)
        {
            countdown -= Time.deltaTime;
            cdm = (int)countdown / 60;
            cds = (int)countdown % 60;
            //cds = (int)countdown;

            if (hiding == true)
            {
                hideTime += Time.deltaTime;
                htm = (int)hideTime / 60;
                hts = (int)hideTime % 60;
            }

            if (cdm == 0 && cds == 0)
            {
                //endBoo
                hiding = false;
                Result.SetActive(true);
                StartCoroutine("Ending");
            }
        }
        countdownText.text = "終了まで " + cdm.ToString().PadLeft(2, '0') + ":" + cds.ToString().PadLeft(2, '0');
        hideTimeText.text = htm.ToString().PadLeft(2,'0') + ":" + hts.ToString().PadLeft(2,'0');
    }

    public void StopButton()
    {
        hiding = false;
    }

    IEnumerator Ending()
    {
        yield return new WaitForSeconds(1);
        TimeNumText.text = hideTimeText.text;
        TimeNum.SetActive(true);
        yield return new WaitForSeconds(1);
        UPNumText.text = wk.undoPoint.ToString();
        UPNum.SetActive(true);
        yield return new WaitForSeconds(1);
        ScoreNum.SetActive(true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Start");
    }
}
