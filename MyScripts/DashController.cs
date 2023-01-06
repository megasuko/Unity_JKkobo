using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class DashController : MonoBehaviour
{
    public ContinuousMoveProviderBase DashSpeed;

    public int flag = 0;

    public void GoDash(bool pressed)
    {
        //dashSlider = dashGauge;
        if (pressed == true)
        {
            flag = 1;
            DashSpeed.moveSpeed = 4f;
        }
        else
        {
            flag = 0;
            DashSpeed.moveSpeed = 2f;
        }
    }
}
