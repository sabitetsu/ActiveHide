using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Walking : MonoBehaviour
{
    [SerializeField] Text undoPointText;
    Countdown cd;
    public int undoPoint;
    float sindou;
    float mx;
    // Start is called before the first frame update
    void Start()
    {
        cd = GetComponent<Countdown>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cd.hiding == true)
        {
            Vector3 dir = Vector3.zero;
            dir.x = Input.acceleration.x;
            dir.y = Input.acceleration.y;
            dir.z = Input.acceleration.z;

            if (dir.x < 0)
            {
                dir.x *= -1;
            }

            if (dir.y < 0)
            {
                dir.y *= -1;
            }

            if (dir.z < 0)
            {
                dir.z *= -1;
            }

            sindou = dir.x + dir.y + dir.z;

            if (mx < sindou)
            {
                mx = sindou;
            }

            if (sindou < (mx - 0.2))
            {
                mx = 0f;
                undoPoint += 1;
            }

            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                undoPoint += 1;
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                undoPoint -= 1;
            }
        }
        undoPointText.text = undoPoint.ToString()+"UP";
    }
}
