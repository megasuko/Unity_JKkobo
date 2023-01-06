using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class Vive : MonoBehaviour
{
    public ActionBasedController RightVive;
    public ActionBasedController LeftVive;
    public float viveTimeR = -1;
    public float viveAmpR = 1;
    public float viveTimeL = -1;
    public float viveAmpL = 1;

    // Update is called once per frame
    void Update()
    {
        if (viveTimeR != -1)
        {
            RightVive.SendHapticImpulse(viveAmpR, viveTimeR);
            viveTimeR = -1;
        }
        if (viveTimeL != -1)
        {
            LeftVive.SendHapticImpulse(viveAmpL, viveTimeL);
            viveTimeL = -1;
        }
    }
}
