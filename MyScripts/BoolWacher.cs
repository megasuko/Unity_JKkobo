using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolWacher : MonoBehaviour
{

    public GameObject light;
        public void LightOnOff(bool pressed) {
            if (pressed == true)
            {
            light.SetActive(light.activeSelf ^ true);
            }
        }

}
