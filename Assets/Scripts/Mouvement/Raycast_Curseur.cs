using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast_Curseur : MonoBehaviour
{
    void Update()
    {
        Vector3 cible = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (cible.y > 0)
        {
            transform.position = cible;
        } 
        else
        {
            transform.position = cible;
        }
    }
}
