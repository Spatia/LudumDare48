using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show : MonoBehaviour
{
    public GameObject Object_To_Show;
    private bool Ouvrir;
    void Start()
    {
        Ouvrir = false;
    }
    public void Show_Object()
    {
        if (Ouvrir == false)
        {
            Object_To_Show.SetActive(true);
            Ouvrir = true;
        }
        else if (Ouvrir == true)
        {
            Object_To_Show.SetActive(false);
            Ouvrir = false;
        }
    }
}
