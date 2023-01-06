using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashTime : MonoBehaviour
{
    public DashController Dash;
    public MutantQTEController QTE;
    public Slider dashSlider;
    private float dashGauge = 1f;
    // Start is called before the first frame update
    void Start()
    {
        dashSlider.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (QTE.QTEflag == 0)
        {
            if (Dash.flag == 1 && dashGauge > 0f)
            {
                dashGauge -= Time.deltaTime / 10;
            }
            else
            {
                Dash.DashSpeed.moveSpeed = 2f;
                if (dashGauge <= 1f)
                {
                    dashGauge += Time.deltaTime / 10;
                }
            }
        }
        else
        {
            Dash.DashSpeed.moveSpeed = 1f;
        }
        dashSlider.value = dashGauge;
    }
}
