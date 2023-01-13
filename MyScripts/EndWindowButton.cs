using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class EndWindowButton : MonoBehaviour
{

    public StickWatcher Stick;
    public ContinuousMoveProviderBase Speed;
    [SerializeField] private GameObject Window;
    [SerializeField] private Image resetButton;
    [SerializeField] private Image titleButton;
    private int select = 0;
    private int releaseP = 0;
    private int releaseS = 0;
    // Update is called once per frame
    void Update()
    {
        if (Window.activeSelf == true)
        {
            Speed.moveSpeed = 0f;
            /*ボタン*/
            if (Stick.primaryL != true && Stick.primaryR != true)
            {
                releaseP = 1;
            }
            if (releaseP == 1 && (Stick.primaryL == true || Stick.primaryR == true))
            {
                releaseP = 0;
                if (select == 0)
                {
                    SceneManager.LoadScene("Map_v1");
                }
                else
                {
                    SceneManager.LoadScene("TitleForHorrorGame");
                }
            }
            /*スティック入力*/
            if (Stick.valueL.x == 0 && Stick.valueR.x == 0)
            {
                releaseS = 1;
            }
            if (releaseS == 1 && (Stick.valueL.x != 0 || Stick.valueR.x != 0))
            {
                releaseS = 0;
                if (select == 0)
                {
                    select = 1;
                    resetButton.color = new Color(0.3f, 0.3f, 0.3f, 1f);
                    titleButton.color = new Color(1f, 1f, 1f, 1f);
                }
                else
                {
                    select = 0;
                    titleButton.color = new Color(0.3f, 0.3f, 0.3f, 1f);
                    resetButton.color = new Color(1f, 1f, 1f, 1f);
                }
            }
        }
    }
}
