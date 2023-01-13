using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public StickWatcher Stick;
    public ManualController Manual;
    [SerializeField] private GameObject pWindow;
    [SerializeField] private GameObject dWindow;
    [SerializeField] private GameObject cWindow;
    [SerializeField] private GameObject QTEWindow;
    private int flag = 0;
    private int select = 0;
    private int hold = 0;
    private int release = 0;
    public AudioSource[] source;
    public Image[] buttonBack;

    void Update()
    {
        Debug.Log(hold);
        if ((Stick.primaryL == true || Stick.primaryR == true )&& pWindow.activeSelf==false && dWindow.activeSelf == false && cWindow.activeSelf == false && QTEWindow.activeSelf == false && release == 1)
        {
            hold++;
            if (hold > 50)
            {
                Time.timeScale = 0;
                foreach (AudioSource audio in source)
                {
                    audio.Pause();
                }
                pWindow.SetActive(true);
                release = 0;
                hold = 0;
            }
        }
        else if(pWindow.activeSelf == false)
        {
            hold = 0;
            if (Stick.primaryL != true && Stick.primaryR != true)
            {
                release = 1;
            }
        }
        if (Manual.manualflag == 3)
        {
            pWindow.SetActive(true);
            Manual.manualflag = 0;
        }
        if(pWindow.activeSelf == true)
        {
            if(Stick.valueL.y!=0 && flag==0)
            {
                flag = 1;
                SelectColor(Stick.valueL.y);

            }else if (Stick.valueR.y != 0 && flag==0)
            {
                flag = 1;
                SelectColor(Stick.valueR.y);
            }
            else if(Stick.valueL.y==0 && Stick.valueR.y==0)
            {
                flag = 0;
            }
            
            if(Stick.primaryL==true || Stick.primaryR ==true && release==2)
            {
                release = 0;
                ButtonDo();
            }
            else if (Stick.primaryL != true && Stick.primaryR != true)
            {
                release = 2;
            }
        }
    }

    void SelectColor(float value)
    {
        if (value > 0)
        {
            buttonBack[select].color = new Color(0.3f, 0.3f, 0.3f, 1f);
            select--;
            if (select < 0)
            {
                select = 3;
            }
            buttonBack[select].color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            buttonBack[select].color = new Color(0.3f, 0.3f, 0.3f, 1f);
            select++;
            if (select > 3)
            {
                select = 0;
            }
            buttonBack[select].color = new Color(1f, 1f, 1f, 1f);
        }
    }

    void ButtonDo()
    {
        if (select == 0)
        {
            Time.timeScale = 1f;
            foreach (AudioSource audio in source)
            {
                audio.UnPause();
            }
            pWindow.SetActive(false);
        }
        else if (select == 1)
        {
            Time.timeScale = 1f;
            foreach (AudioSource audio in source)
            {
                audio.UnPause();
            }
            SceneManager.LoadScene("Map_v1");
        }
        else if (select == 2)
        {
            Time.timeScale = 1f;
            foreach (AudioSource audio in source)
            {
                audio.UnPause();
            }
            SceneManager.LoadScene("TitleForHorrorGame");
        }
        else
        {
            pWindow.SetActive(false);
            Manual.manualflag = 1;
        }
    }
}
