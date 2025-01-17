using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ressources : MonoBehaviour
{
    public Text Text_Argent;
    public Text Text_Engrenage;
    public Text Text_Employé;

    public int argent;
    public int engrenage;
    public int employé;
    public int salaire;

    public int Employés_Stockés;
    public int Employés_Travaillent;
    public int Engrenage_Stockés;

    public int Limite_Engrenage;
    public int Limite_Employé;

    public int Espace_Employé;
    public int Espace_Engrenage;

    public int score;

    public int nbr_usines;

    public int electricite_par_seconde;

    private RaycastHit2D hit;

    void Start()
    {
        argent = 2000;
        engrenage = 5;
        employé = 2;
        salaire = employé * nbr_usines * 4;

        Limite_Employé = 2;
        Limite_Engrenage = 5;

        Employés_Stockés = 0;
        Employés_Travaillent = 0;
        Engrenage_Stockés = 0;

        score = 0;
        nbr_usines = 0;

        electricite_par_seconde = 0;

        StartCoroutine(GenererArgent());
    }

    IEnumerator GenererArgent()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            argent += salaire;
            score += employé * nbr_usines / 4;
        }
    }

    private void Update()
    {
        Info_Habitations[] habitationList = FindObjectsOfType<Info_Habitations>();

        if (Employés_Stockés < employé)
        {
            foreach (Info_Habitations check in habitationList)
            {
                if (check.GetComponent<Base_no>().Base_Number == true)
                {
                    if (Employés_Stockés < employé)
                    {
                        if (check.GetComponent<Base_no>().Base_Number == true)
                        {
                            if (check.GetComponent<Info_Habitations>().Nb_Personnes_Présentes == 1)
                            {
                                check.GetComponent<Info_Habitations>().Nb_Personnes_Présentes = 2;
                                check.GetComponent<Info_Habitations>().update = true;
                                Employés_Stockés += 1;
                            }
                            else if (check.GetComponent<Info_Habitations>().Nb_Personnes_Présentes == 0)
                            {
                                check.GetComponent<Info_Habitations>().Nb_Personnes_Présentes = 1;
                                check.GetComponent<Info_Habitations>().update = true;
                                Employés_Stockés += 1;
                            }
                        }
                    }
                }
            }
        }

        //Calcule la quantité d'habitations activée

        int No_Habitations_Calcul = 0;

        foreach (Info_Habitations check in habitationList)
        {
            if (check.GetComponent<Base_no>().Base_Number == true && check.transform.CompareTag("Module"))
            {
                No_Habitations_Calcul += 1;
            }
        }

        Limite_Employé = No_Habitations_Calcul * 2;

        //Calcule la quantité de stockage activée

        Info_Stockage[] stockageList = FindObjectsOfType<Info_Stockage>();

        int No_Stockage_Calcul = 0;

        foreach (Info_Stockage check in stockageList)
        {
            if (check.GetComponent<Base_no>().Base_Number == true && check.transform.CompareTag("Module"))
            {
                No_Stockage_Calcul += 1;
            }
        }

        Limite_Engrenage = No_Stockage_Calcul * 5;

        //Calcule la quantité d'usines activée

        Info_Usine[] usineList = FindObjectsOfType<Info_Usine>();

        int No_Usine_Calcul = 0;

        foreach (Info_Usine check in usineList)
        {
            if (check.GetComponent<Base_no>().Base_Number == true && check.transform.CompareTag("Module"))
            {
                No_Stockage_Calcul += 1;
            }
        }

        nbr_usines = No_Usine_Calcul;

        Espace_Employé = Limite_Employé - employé;
        Espace_Engrenage = Limite_Engrenage - engrenage;

        Text_Argent.GetComponent<Text>().text = "" + argent;
        Text_Engrenage.GetComponent<Text>().text = engrenage + "/" + Limite_Engrenage;
        Text_Employé.GetComponent<Text>().text = employé + "/" + Limite_Employé;

        if (engrenage > Limite_Engrenage)
        {
            engrenage = Limite_Engrenage;
        }

        salaire = employé * nbr_usines * 4;
    }
}