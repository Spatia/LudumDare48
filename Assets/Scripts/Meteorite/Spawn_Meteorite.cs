using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn_Meteorite : MonoBehaviour
{
    public GameObject MeteorReference;
    private Vector2 spawnPosition;
    public int Plus_Petit_x;
    public int Plus_Grand_x;
    private int secondsBetweeenMeteors;
    public int Plus_Petite_Valeur;
    public int Plus_Grande_Valeur;
    GameObject temp;
    public Text affichage;
    public GameObject MessageErreur;
    private float Taille_Météorite;
    private float Taille_Explosion;

    IEnumerator AfficherMessageErreur()
    {
        MessageErreur.SetActive(true);
        affichage.GetComponent<Text>().text = "WARNING : ASTEORID INCOMING";
        yield return new WaitForSeconds(1);
        affichage.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(1);
        affichage.GetComponent<Text>().text = "WARNING : ASTEORID INCOMING";
        yield return new WaitForSeconds(1);
        affichage.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(1);
        affichage.GetComponent<Text>().text = "WARNING : ASTEORID INCOMING";
        yield return new WaitForSeconds(1);
        MessageErreur.SetActive(false);
    }

    void Start()
    {
        StartCoroutine(LoopMeteorSpawn());
        Taille_Météorite = 150;
        Taille_Explosion = 1110;
    }

    IEnumerator LoopMeteorSpawn()
    {
        while (true)
        {
            secondsBetweeenMeteors = Random.Range(Plus_Petite_Valeur, Plus_Grande_Valeur);
            yield return new WaitForSeconds(secondsBetweeenMeteors);
            StartCoroutine(AfficherMessageErreur());
            secondsBetweeenMeteors = 5;
            yield return new WaitForSeconds(secondsBetweeenMeteors);
            SpawnMeteor();
        }
    }

    public void SpawnMeteor()
    {
        spawnPosition = new Vector2 (Random.Range(Plus_Petit_x, Plus_Grand_x), 1500);
        temp = Instantiate(MeteorReference, spawnPosition, Quaternion.identity);
        temp.GetComponent<Explosion>().Taille_Explosion = Taille_Explosion;
        temp.transform.localScale = new Vector3(Taille_Météorite, Taille_Météorite, 1);
        Taille_Explosion += 740;
        Taille_Météorite += 100;
    }
}
