using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Modules : MonoBehaviour
{
    private RaycastHit2D hit;
    public GameObject UI_Habitation;
    public Text No_Workers;

    public void Close_UI_Habitation ()
    {
        UI_Habitation.SetActive(false);
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.transform.CompareTag("Module"))
            {
                if (hit.transform.GetComponent<Info_Habitations>() != null)
                {
                    UI_Habitation.SetActive(true);
                    No_Workers.GetComponent<Text>().text = "" + hit.transform.GetComponent<Info_Habitations>().Nb_Personnes_Présentes;
                }
                else
                {
                    UI_Habitation.SetActive(false);
                }
            }
        }
    }
}
