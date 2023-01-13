using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class TimeCounter : MonoBehaviour
{
    //�J�E���g�A�b�v
    public float countup = 0.0f;

    //�^�C�����~�b�g
    public float timeLimit = 5.0f;

    //���Ԃ�\������Text�^�̕ϐ�
    public Text timeText;

    [SerializeField] private GameObject cWindow;
    [SerializeField] private GameObject dWindow;
    [SerializeField] private GameObject ghools;
    [SerializeField] private GameObject mutants;
    [SerializeField] private AudioSource source;
    public Vive Vive;
    public Material sky;
    int endflag = 0;
    int viveflag = 0;

    // Update is called once per frame
    void Update()
    {
        //���Ԃ��J�E���g����
        if (endflag == 0)
        {
            countup += Time.deltaTime;
        }

        //���Ԃ�\������
        timeText.text = countup.ToString("f1") + "s";
        if (dWindow.activeSelf==true)
        {
            timeText.text = "";
            //countup = 0.0f;
            endflag = 1;
            if (viveflag == 0)
            {
                Vive.viveTimeR = 1f;
                Vive.viveAmpR = 1f;
                Vive.viveTimeL = 1f;
                Vive.viveAmpL = 1f;
                viveflag = 1;
            }
        }
        if (countup >= timeLimit)
        {
            timeText.text = "";
            dWindow.SetActive(false);
            cWindow.SetActive(true);
            ghools.SetActive(false);
            mutants.SetActive(false);
            source.Pause();
            RenderSettings.skybox = sky;
        }
    }
}