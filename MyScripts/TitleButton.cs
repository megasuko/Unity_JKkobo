using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    public Vive Vive;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Lhand")
        {
            Vive.viveTimeL = 0.4f;
            Vive.viveAmpL = 0.3f;
            SceneManager.LoadScene("TitleForHorrorGame");
        }
        else if (other.gameObject.tag == "Rhand")
        {
            Vive.viveTimeR = 0.4f;
            Vive.viveAmpR = 0.3f;
            SceneManager.LoadScene("TitleForHorrorGame");
        }
    }
}
