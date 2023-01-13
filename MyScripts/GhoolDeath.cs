using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhoolDeath : MonoBehaviour
{
    [SerializeField] private GameObject dWindow;
    [SerializeField] private GameObject ghouls;
    [SerializeField] private GameObject mutants;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ghoul")
        {
            dWindow.SetActive(true);
            ghouls.SetActive(false);
            mutants.SetActive(false);
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ghoul")
        {
            dWindow.SetActive(true);
            ghouls.SetActive(false);
            mutants.SetActive(false);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ghoul")
        {
            dWindow.SetActive(true);
            ghouls.SetActive(false);
            mutants.SetActive(false);
        }
    }
    public void OnControllerColliderHit(Collider other)
    {
        if (other.gameObject.tag == "Ghoul")
        {
            dWindow.SetActive(true);
            ghouls.SetActive(false);
            mutants.SetActive(false);
        }
    }
}
