using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MutantQTEController : MonoBehaviour
{
    [SerializeField] private GameObject mutantBite;
    [SerializeField] private GameObject leftHand;
    [SerializeField] private GameObject QTEWindow;
    [SerializeField] private GameObject dWindow;
    [SerializeField] private GameObject cWindow;
    [SerializeField] private GameObject ghools;
    [SerializeField] private GameObject mutants;
    [SerializeField] private Image QTETimer;
    [SerializeField] private Text QTEText;
    [SerializeField] private SpriteRenderer blood;
    public Slider QTESlider;
    public VRControllerData Data;
    public Vive Vive;
    public float shakePoint=0f;
    public Vector3 v;
    public Vector3 zero=new Vector3(0,0,0);
    int debudflag = 0;
    public int QTEflag = 0;
    float bloodAlpha = 0;

    void Update()
    {
        if (dWindow.activeSelf==true || cWindow.activeSelf == true)
        {
            QTEflag = 0;
            mutantBite.SetActive(false);
            leftHand.SetActive(true);
            QTEWindow.SetActive(false);
            mutants.SetActive(false);
            bloodAlpha = 0;
            blood.color = new Color(0.4f, 0.4f, 0.4f, bloodAlpha);
        }
        if (QTEflag == 1)
        {
            QTESlider.value -= Time.deltaTime / 3;
            bloodAlpha += Time.deltaTime / 3;
            blood.color = new Color(0.4f, 0.4f, 0.4f, bloodAlpha);
            v = Data.velocity;
            shakePoint += Vector3.Distance(v, zero);
            if (0.25 < QTESlider.value && QTESlider.value <= 0.5)
            {
                Vive.viveTimeL = 1f;
                Vive.viveAmpL = 0.5f;
            }
            if (QTESlider.value <= 0.25)
            {
                Vive.viveTimeL = 1f;
                Vive.viveAmpL = 0.8f;
                QTETimer.color = new Color(0.6f, 0f, 0f, 1f);
                QTEText.color = new Color(0.6f, 0f, 0f, 1f);
            }

            if (shakePoint >= 150f)
            {
                bloodAlpha =0;
                blood.color = new Color(0.4f, 0.4f, 0.4f, bloodAlpha);
                Vive.viveTimeL = 0f;
                Vive.viveAmpL = 0f;
                shakePoint = 0f;
                mutantBite.SetActive(false);
                leftHand.SetActive(true);
                QTEWindow.SetActive(false);
                QTEflag = 0;
            }

            else if (QTESlider.value == 0)
            {
                mutantBite.SetActive(false);
                leftHand.SetActive(true);
                QTEWindow.SetActive(false);
                dWindow.SetActive(true);
                ghools.SetActive(false);
                mutants.SetActive(false);
                bloodAlpha = 0;
                blood.color = new Color(0.4f, 0.4f, 0.4f, bloodAlpha);
                QTEflag = 0;
                if (debudflag == 0)
                {
                    Debug.Log("shakePoint=" + shakePoint);
                    debudflag = 1;
                }
            }
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Mutant")
        {
            Debug.Log("hit");
            if (QTEflag == 1)
            {
                mutantBite.SetActive(false);
                leftHand.SetActive(true);
                QTEWindow.SetActive(false);
                dWindow.SetActive(true);
                ghools.SetActive(false);
                mutants.SetActive(false);
                bloodAlpha = 0;
                blood.color = new Color(0.4f, 0.4f, 0.4f, bloodAlpha);
                QTEflag = 0;
            }
            else
            {
                Destroy(other.gameObject);
                mutantBite.SetActive(true);
                leftHand.SetActive(false);
                QTEWindow.SetActive(true);
                QTESlider.value = 1;
                QTEflag = 1;
                Vive.viveTimeL = 1.5f;
                Vive.viveAmpL = 0.3f;
                bloodAlpha = 0;
                blood.color = new Color(0.4f, 0.4f, 0.4f, bloodAlpha);
                QTETimer.color = new Color(0f, 0.7f, 0f, 1f);
                QTEText.color = new Color(1f, 1f, 1f, 1f);
            }
        }
    }


}
