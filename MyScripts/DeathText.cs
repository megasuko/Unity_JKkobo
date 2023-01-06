using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathText : MonoBehaviour
{
    public TimeCounter deathcount;
    public Text deathtext;
    // Update is called once per frame
    void Start()
    {
        
        deathtext.text = "survived " + deathcount.countup.ToString("f1") + " seconds";
    }
}
