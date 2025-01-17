using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FauxCurseurSuivre : MonoBehaviour
{
    void Update()
    {
        Vector3 cible = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //transform.position = cible - new Vector3(cible.x %18, cible.y % 18, cible.z % 23);
        if (cible.y > 0)
        {
            transform.position = cible - new Vector3(cible.x % 72.96f, cible.y % 72.96f, cible.z % 72.96f) + new Vector3(36.48f, 36.48f, 36.48f);
        } else
        {
            transform.position = cible - new Vector3(cible.x % 72.96f, cible.y % 72.96f, cible.z % 72.96f) + new Vector3(36.48f, -36.48f, 36.48f);
        }
    }
}
