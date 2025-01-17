using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vaisseau_spatial : MonoBehaviour
{
    public GameObject Vaisseau_SpatialRéférence;
    public GameObject MessageErreur;
    public GameObject Notif_Engrenages;
    public GameObject Notif_Ouvriers;
    public GameObject Text_Ouvriers;
    public GameObject Text_Engrenages;
    public GameObject nbengreDeliver;
    public GameObject nbpeopleDeliver;
    public Vector3 spawnPosition;
    public Vector2 speedVector;
    public int coutFaireVenirVaisseau;
    bool vaisseauAvance;
    bool vaisseauClickable;
    GameObject temp;
    public Text affichage;
    private int plusemployes;
    private int plusengrenages;
    private int engre = 3;
    private int people = 2;
    private int Price;
    public Text Prix;
    // Start is called before the first frame update
    void Start()
    {
        nbpeopleDeliver.GetComponent<Text>().text = people.ToString();
        nbengreDeliver.GetComponent<Text>().text = engre.ToString();
        vaisseauClickable = false;
        Notif_Engrenages.SetActive(false);
        Notif_Ouvriers.SetActive(false);
        Text_Engrenages.SetActive(false);
        Text_Ouvriers.SetActive(false);
        Price = 500;
    }

    IEnumerator AfficherMessageErreur()
    {
        MessageErreur.SetActive(true);
        yield return new WaitForSeconds(2);
        MessageErreur.SetActive(false);
    }

    IEnumerator AfficherNotif(int employesnb,int engrenagesnb)
    {
        Text_Engrenages.GetComponent<TextMesh>().text = engrenagesnb.ToString();
        Text_Ouvriers.GetComponent<TextMesh>().text = employesnb.ToString();
        Notif_Engrenages.SetActive(true);
        Notif_Ouvriers.SetActive(true);
        Text_Engrenages.SetActive(true);
        Text_Ouvriers.SetActive(true);
        yield return new WaitForSeconds(1);
        Notif_Engrenages.SetActive(false);
        Notif_Ouvriers.SetActive(false);
        Text_Engrenages.SetActive(false);
        Text_Ouvriers.SetActive(false);
    }


    public void plusEngre()
    {
        if (temp==null)
        {
            if (people+engre<5)
            {
                engre += 1;
                nbengreDeliver.GetComponent<Text>().text = engre.ToString();
                Price += 50;
                Prix.GetComponent<Text>().text = Price.ToString();
            }
            else if (people + engre == 5 && engre < 5)
            {
                engre += 1;
                nbengreDeliver.GetComponent<Text>().text = engre.ToString();
                people -= 1;
                nbpeopleDeliver.GetComponent<Text>().text = people.ToString();
            }
        }
    }

    public void moinsEngre()
    {
        if (temp == null)
        {
            if (engre > 0)
            {
                engre -= 1;
                nbengreDeliver.GetComponent<Text>().text = engre.ToString();
                Price -= 50;
                Prix.GetComponent<Text>().text = Price.ToString();
            }
        }
    }

    public void plusPeople()
    {
        if (temp == null)
        {
            if (people + engre < 5)
            {
                people += 1;
                nbpeopleDeliver.GetComponent<Text>().text = people.ToString();
                Price += 50;
                Prix.GetComponent<Text>().text = Price.ToString();
            }
            else if (people + engre == 5 && people < 5)
            {
                people += 1;
                nbpeopleDeliver.GetComponent<Text>().text = people.ToString();
                engre -= 1;
                nbengreDeliver.GetComponent<Text>().text = engre.ToString();
            }
        }
    }

    public void moinsPeople()
    {
        if (temp == null)
        {
            if (people > 0)
            {
                people -= 1;
                nbpeopleDeliver.GetComponent<Text>().text = people.ToString();
                Price -= 50;
                Prix.GetComponent<Text>().text = Price.ToString();
            }
        }
    }

    public void VaisseauArrive()
    {
        if (temp == null)
        {
            if (GetComponent<Ressources>().argent >= Price)
            {
                GetComponent<Ressources>().argent -= Price;
                vaisseauAvance = true;
                vaisseauClickable = false;
                temp = Instantiate(Vaisseau_SpatialRéférence, spawnPosition, Quaternion.identity);
                temp.transform.rotation = new Quaternion(temp.transform.rotation.x, temp.transform.rotation.y, temp.transform.rotation.z + 1, temp.transform.rotation.w);
            }
            else
            {
                // ERREUR : Pas assez d'argent !
                affichage.GetComponent<Text>().text = "You do not have enough money to do this";
                StartCoroutine(AfficherMessageErreur());
            }
        }
    }

    public void VaisseauPart()
    {
        vaisseauAvance = false;
        vaisseauClickable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (temp != null)
        {
            if (vaisseauAvance == true)
            {
                if (temp.transform.position.y > 360)
                {
                    temp.GetComponent<Rigidbody2D>().velocity = speedVector;
                }
                else
                {
                    temp.GetComponent<Rigidbody2D>().velocity = new Vector2();
                    vaisseauClickable = true;
                }
            }
            else
            {
                if (temp.transform.position.y < 810)
                {
                    temp.GetComponent<Rigidbody2D>().velocity = -speedVector;
                }
                else
                {
                    Destroy(temp);
                }
            }
        }
        if (vaisseauClickable)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.collider != null)
                {
                    if (hit.collider.transform != null)
                    {
                        if (hit.collider.transform.CompareTag("Vaisseau_Spatial"))
                        {
                            if (GetComponent<Ressources>().Espace_Employé >=people)
                            {
                                GetComponent<Ressources>().employé += people;
                                plusemployes = people;
                            }
                            else if (GetComponent<Ressources>().Espace_Employé < people && GetComponent<Ressources>().Espace_Employé > 0)
                            {
                                GetComponent<Ressources>().employé += GetComponent<Ressources>().Espace_Employé;
                                plusemployes= GetComponent<Ressources>().Espace_Employé;
                            }
                            else
                            {
                                //Message d'erreur
                            }

                            if (GetComponent<Ressources>().Espace_Engrenage >= engre)
                            {
                                GetComponent<Ressources>().engrenage += engre;
                                plusengrenages = engre;
                            }
                            else if (GetComponent<Ressources>().Espace_Engrenage < engre && GetComponent<Ressources>().Espace_Engrenage > 0)
                            {
                                GetComponent<Ressources>().engrenage += GetComponent<Ressources>().Espace_Engrenage;
                                plusengrenages= GetComponent<Ressources>().Espace_Engrenage;
                            }
                            else
                            {
                                //Message d'erreur
                            }
                            StartCoroutine(AfficherNotif(plusemployes, plusengrenages));
                            VaisseauPart();
                        }
                    }
                }
            }
        }
    }
}