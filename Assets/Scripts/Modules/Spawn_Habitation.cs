using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Spawn_Habitation : MonoBehaviour
{
    public GameObject Spawn_HabitationRéférence;
    public GameObject Spawn_StockageRéférence;
    public GameObject Spawn_UsineRéférence;
    public GameObject Spawn_TunnelRéférence;

    public GameObject Faux_Curseur;
    public GameObject Raycast_Curseur;
    public GameObject MessageErreur;
    public GameObject Grille;
    public GameObject UI_Construire;

    private GameObject temp;
    private GameObject empty;

    public AudioSource audio;
    public bool Create;

    public int prix;
    private int Engrenage;

    public Text Argent;
    public Text affichage;

    public GameObject Premiere_Habitation;
    public LayerMask layermask;
    private RaycastHit2D Vide;
    private int Truc_Construit;
    public static bool Actif;
    public bool Permis_Construire;
    IEnumerator AfficherMessageErreur()
    {
        MessageErreur.SetActive(true);
        yield return new WaitForSeconds(2);
        MessageErreur.SetActive(false);
    }
    private void Start()
    {
        Create = false;
        Permis_Construire = false;
    }

    public void Construire()
    {
        Permis_Construire = true;
    }
    public void Annuler()
    {
        Actif = false;
        Grille.SetActive(false);
        UI_Construire.SetActive(false);
        Destroy(temp);
        Create = false;
        Permis_Construire = false;
    }
    public void Habitation()
    {
        if (Create == false)
        {
            temp = Instantiate(Spawn_HabitationRéférence, new Vector3(Faux_Curseur.transform.position.x, Faux_Curseur.transform.position.y, Faux_Curseur.transform.position.z + 137.1f), Quaternion.identity);
            UI_Construire.SetActive(true);
            Grille.SetActive(true);
            Actif = true;
            Create = true;
            Engrenage = 1;
            Truc_Construit = 0;
        }
        else if (Create == true)
        {
            if (temp != null)
            {
                Actif = false;
                Grille.SetActive(false);
                UI_Construire.SetActive(false);
                Destroy(temp);
                Create = false;
                Permis_Construire = false;
            }
            else
            {
                Create = false;
            }
        }
    }

    public void Stockage()
    {
        if (Create == false)
        {
            temp = Instantiate(Spawn_StockageRéférence, new Vector3(Faux_Curseur.transform.position.x, Faux_Curseur.transform.position.y, Faux_Curseur.transform.position.z + 137.1f), Quaternion.identity);
            UI_Construire.SetActive(true);
            Grille.SetActive(true);
            Actif = true;
            Create = true;
            Engrenage = 1;
            Truc_Construit = 0;
        }
        else if (Create == true)
        {
            if (temp != null)
            {
                Actif = false;
                Grille.SetActive(false);
                UI_Construire.SetActive(false);
                Destroy(temp);
                Create = false;
                Permis_Construire = false;
            }
            else
            {
                Create = false;
            }
        }
    }

    public void Usine()
    {
        if (Create == false)
        {
            temp = Instantiate(Spawn_UsineRéférence, new Vector3(Faux_Curseur.transform.position.x, Faux_Curseur.transform.position.y, Faux_Curseur.transform.position.z + 137.1f), Quaternion.identity);
            UI_Construire.SetActive(true);
            Grille.SetActive(true);
            Actif = true;
            Create = true;
            Engrenage = 2;
            Truc_Construit = 0;
        }
        else if (Create == true)
        {
            if (temp != null)
            {
                Actif = false;
                Grille.SetActive(false);
                UI_Construire.SetActive(false);
                Destroy(temp);
                Create = false;
                Permis_Construire = false;
            }
            else
            {
                Create = false;
            }
        }
    }

    public void Tunnel()
    {
        if (Create == false)
        {
            temp = Instantiate(Spawn_TunnelRéférence, new Vector3(Faux_Curseur.transform.position.x, Faux_Curseur.transform.position.y, Faux_Curseur.transform.position.z + 137.1f), Quaternion.identity);
            UI_Construire.SetActive(true);
            Grille.SetActive(true);
            Actif = true;
            Create = true;
            Engrenage = 0;
            Truc_Construit = 1;
        }
        else if (Create == true)
        {
            if (temp != null)
            {
                Actif = false;
                Grille.SetActive(false);
                UI_Construire.SetActive(false);
                Destroy(temp);
                Create = false;
                Permis_Construire = false;
            }
            else
            {
                Create = false;
            }
        }
    }

    void Update()
    {
        if (temp != null)
        {
            prix = (int)(temp.GetComponent<Transform>().position.y * -1 + 262) / 4;
            if (prix >=0)
            {
                Argent.GetComponent<Text>().text = "" + prix;
            }
            else
            {
                Argent.GetComponent<Text>().text = "0";
            }

            if (Input.GetButtonDown("Fire1"))
            {
                if (temp != null)
                {
                    RaycastHit2D UIhit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 200, layermask);
                    if (UIhit == Vide)
                    {
                        temp.transform.parent = Faux_Curseur.transform;
                        temp.transform.position = Faux_Curseur.transform.position;
                    }
                }
            }
            else
            {
                temp.transform.parent = null;
            }
        }

        if (Permis_Construire == true)
        {
            if (temp != null)
            {
                if (GetComponent<Ressources>().argent >= prix && GetComponent<Ressources>().engrenage >= Engrenage)
                {
                    RaycastHit2D hit = Physics2D.Raycast(new Vector3(temp.transform.position.x, temp.transform.position.y, temp.transform.position.z), Vector2.zero);
                    if (temp.GetComponent<ToucheTruc>().touché == false && hit.transform.CompareTag("Sol"))
                    {
                        Permis_Construire = false;
                        audio.Play();
                        temp.GetComponent<SpriteRenderer>().sortingOrder = -1;
                        temp.GetComponent<Transform>().position = new Vector3(temp.transform.position.x, temp.transform.position.y, 0);
                        temp.transform.parent = null;
                        temp.transform.tag = "Module";
                        Argent.GetComponent<Text>().text = "1";
                        Actif = false;
                        temp = empty;
                        Create = false;
                        UI_Construire.SetActive(false);
                        Grille.SetActive(false);

                        if (Truc_Construit == 0)
                        {
                            GetComponent<Ressources>().engrenage -= Engrenage;
                            GetComponent<Ressources>().argent -= prix;
                            GetComponent<Ressources>().score += 50;
                        }
                        else if (Truc_Construit == 1)
                        {
                            GetComponent<Ressources>().argent -= prix;
                        }
                    }
                    else
                    {
                        Permis_Construire = false;
                        affichage.GetComponent<Text>().text = "You can't place this here";
                        StartCoroutine(AfficherMessageErreur());
                    }
                }
                else if (GetComponent<Ressources>().argent >= prix)
                {
                    Permis_Construire = false;
                    affichage.GetComponent<Text>().text = "You do not have enough gears to do this";
                    StartCoroutine(AfficherMessageErreur());
                }
                else
                {
                    Permis_Construire = false;
                    affichage.GetComponent<Text>().text = "You do not have enough money to do this";
                    StartCoroutine(AfficherMessageErreur());
                }
            }
        }
    }
}