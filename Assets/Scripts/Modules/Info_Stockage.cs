using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info_Stockage : MonoBehaviour
{
    public int Nb_Engrenages_Présent;

    void Start()
    {
        Nb_Engrenages_Présent = 0;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Asteoride"))
        {
            Destroy(gameObject);
        }
    }
}
