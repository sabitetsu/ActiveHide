using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Starting : MonoBehaviour
{
    [SerializeField] GameObject waitingPanel;
    [SerializeField] Text limitTimeText;
    [SerializeField] Text waitingTime;
    bool start = false;
    int limitTime = 1;
    [SerializeField] float startingTimer = 120;
    int stm;
    int sts;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(waitingTime.text == "0:00")
        {
            SceneManager.LoadScene("ActiveHide");
        }
        if(start == true)
        {
            startingTimer -= Time.deltaTime;
            stm = (int)startingTimer / 60;
            sts = (int)startingTimer % 60;
            waitingTime.text = stm.ToString() + ":" + sts.ToString().PadLeft(2, '0');
        }
    }

    public void StartButton()
    {
        if (start == false)
        {
            waitingPanel.SetActive(true);
            start = true;
            limitTime *= 60;
            PlayerPrefs.SetFloat("limitTime", limitTime);
        }
    }

    public void PlusMinusButton(int num)
    {
        limitTime += num;
        limitTimeText.text = limitTime.ToString();
    }
}
