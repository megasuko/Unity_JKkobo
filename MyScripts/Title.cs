using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public StickWatcher Stick;
    public ManualController Manual;
    [SerializeField] private GameObject tWindow;
    [SerializeField] private Image startBack;
    [SerializeField] private Image manualBack;
    [SerializeField] private Image quitBack;
    [SerializeField] private Image controller2;
    private int flag = 0;
    private int primaryflag = 0;
    private int select = 0;
    private int release = 0;
    private int firstflag = 0;
    private float breaktime=0;
    private int startflag = 0;
    // Start is called before the first frame update
    void Start()
    {
        manualBack.color = new Color(0.3f, 0.3f, 0.3f, 1f);
        quitBack.color = new Color(0.3f, 0.3f, 0.3f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        breaktime+= Time.deltaTime;
        if (breaktime > 0.5f){
            if (Manual.manualflag == 3)
            {
                if (startflag == 0)
                {
                    
                    Manual.manualflag = 0;
                    tWindow.SetActive(true);
                    Debug.Log(tWindow.activeSelf);
                }
                else
                {
                    SceneManager.LoadScene("Map_v1");
                }
            }
            if (firstflag == 0 && breaktime>3f && breaktime<5f)
            {
                controller2.color = new Color(1f, 1f, 1f, breaktime-3f);
            }

            if (tWindow.activeSelf == true)
            {
                if (Stick.primaryL == true || Stick.primaryR == true)
                {
                    primaryflag = 1;
                }
                else if (Stick.primaryL != true && Stick.primaryR != true)
                {
                    primaryflag = 0;
                    release = 1;
                }
                if (Stick.valueL.y != 0 && flag == 0)
                {
                    flag = 1;
                    firstflag = 1;
                    SelectColor(Stick.valueL.y);
                }
                else if (Stick.valueR.y != 0 && flag == 0)
                {
                    flag = 1;
                    firstflag = 1;
                    SelectColor(Stick.valueR.y);
                }
                else if (Stick.valueL.y == 0 && Stick.valueR.y == 0)
                {
                    flag = 0;
                }

                if (release == 1 && primaryflag == 1)
                {
                    release = 0;
                    primaryflag = 0;
                    ButtonDo();
                }
            }
        }
    }

    void SelectColor(float value)
    {
        Debug.Log(value);
        if (value > 0)
        {
            if (select == 0)
            {
                startBack.color = new Color(0.3f, 0.3f, 0.3f, 1f);
                quitBack.color = new Color(1f, 1f, 1f, 1f);
                select = 2;
            }
            else if (select == 1)
            {
                manualBack.color = new Color(0.3f, 0.3f, 0.3f, 1f);
                startBack.color = new Color(1f, 1f, 1f, 1f);
                select = 0;
            }
            else
            {
                quitBack.color = new Color(0.3f, 0.3f, 0.3f, 1f);
                manualBack.color = new Color(1f, 1f, 1f, 1f);
                select = 1;
            }
        }
        else
        {
            if (select == 0)
            {
                startBack.color = new Color(0.3f, 0.3f, 0.3f, 1f);
                manualBack.color = new Color(1f, 1f, 1f, 1f);
                select = 1;
            }
            else if (select == 1)
            {
                manualBack.color = new Color(0.3f, 0.3f, 0.3f, 1f);
                quitBack.color = new Color(1f, 1f, 1f, 1f);
                select = 2;
            }
            else
            {
                quitBack.color = new Color(0.3f, 0.3f, 0.3f, 1f);
                startBack.color = new Color(1f, 1f, 1f, 1f);
                select = 0;
            }
        }
    }

    void ButtonDo()
    {
        if (select == 0)
        {
            startflag = 1;
            tWindow.SetActive(false);
            Manual.manualflag = 1;
        }
        else if (select == 1)
        {
            tWindow.SetActive(false);
            Manual.manualflag = 1;
        }
        else
        {
        #if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
        #else
                    Application.Quit();
        #endif
        }
    }
}
