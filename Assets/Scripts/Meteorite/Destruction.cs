using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    private GameObject Porteur;
    private void Start()
    {
        Porteur = GameObject.FindGameObjectWithTag("Porteur");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Module"))
        {
            Spawn_Habitation.Actif = true;
            if (collision.GetComponent<Info_Habitations>() != null)
            {
                Porteur.GetComponent<Ressources>().Limite_Employé -= 2;
                Porteur.GetComponent<Ressources>().employé -= collision.GetComponent<Info_Habitations>().Nb_Personnes_Présentes;
                Porteur.GetComponent<Ressources>().Employés_Stockés -= collision.GetComponent<Info_Habitations>().Nb_Personnes_Présentes;
                Destroy(collision.gameObject);
            }
            if (collision.GetComponent<Info_Stockage>() != null)
            {
                Porteur.GetComponent<Ressources>().Limite_Engrenage -= 5;
                Destroy(collision.gameObject);
            }
            if (collision.GetComponent<Info_Usine>() != null)
            {
                Porteur.GetComponent<Ressources>().nbr_usines --;
                Destroy(collision.gameObject);
            }
        }
    }
}