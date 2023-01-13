using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualController : MonoBehaviour
{
    public int manualflag=0;
    private int page = 0;
    private int releaseP = 0;
    private int releaseS = 0;
    public GameObject[] manual;
    public StickWatcher Stick;

    // Update is called once per frame
    void Update()
    {
        if (manualflag == 1)
        {
            manual[page].SetActive(true);
            manualflag = 2;
        }

        if (manualflag == 2)
        {
            /*閉じるボタン*/
            if (Stick.primaryL != true && Stick.primaryR != true)
            {
                releaseP = 1;
            }
            if (releaseP==1 && (Stick.primaryL == true || Stick.primaryR == true))
            {
                manual[page].SetActive(false);
                manualflag = 3;
                releaseP = 0;
                page = 0;
            }
            /*スティック入力*/
            if (Stick.valueL.x == 0 && Stick.valueR.x == 0)
            {
                releaseS = 1;
            }
            if (releaseS == 1)
            {
                if (Stick.valueL.x != 0)
                {
                    TurnPage(Stick.valueL.x);
                    releaseS = 0;
                }
                else if (Stick.valueR.x != 0)
                {
                    TurnPage(Stick.valueR.x);
                    releaseS = 0;
                }
            }
        }
    }
    void TurnPage(float valueX)
    {
        if (valueX > 0)
        {
            manual[page].SetActive(false);
            page++;
            if (page > 5)
            {
                page = 0;
            }
            manual[page].SetActive(true);
        }
        else
        {
            manual[page].SetActive(false);
            page--;
            if (page < 0)
            {
                page = 5;
            }
            manual[page].SetActive(true);
        }
    }
}
