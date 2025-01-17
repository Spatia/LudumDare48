using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Apparition : MonoBehaviour
{
    public bool Ouvrir;
    public GameObject UI;
    public GameObject Boutton;
    public GameObject Size_Habitations;
    void Start()
    {
        Ouvrir = false;
    }
    public void Apparition_UI ()
    {
        if (Ouvrir == false)
        {
            //Fait apparaitre l'UI
            UI.SetActive(true);
            Ouvrir = true;
            //Déplace le bouton d'ouverture
            Boutton.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right, 95.4f, Boutton.GetComponent<RectTransform>().rect.width);
        }
        else if (Ouvrir == true)
        {
            //Fait disparaitre l'UI
            UI.SetActive(false);
            Ouvrir = false;
            //Déplace le bouton d'ouverture
            Boutton.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right, -67.2f, Boutton.GetComponent<RectTransform>().rect.width);
        }
    }
}