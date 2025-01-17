using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    IEnumerator Temps_De_Vie()
    {
        yield return new WaitForSeconds(1);
        Spawn_Habitation.Actif = false;
        Destroy(gameObject);
    }
    private void Start()
    {
        StartCoroutine(Temps_De_Vie());
    }
}
