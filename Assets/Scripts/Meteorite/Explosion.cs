using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject contact;
    private GameObject temp;
    public float Taille_Explosion;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Sol")
        {
            temp = Instantiate(contact, new Vector3(transform.position.x, transform.position.y, transform.position.z + 137.1f), Quaternion.identity);
            temp.transform.localScale = new Vector3(Taille_Explosion, Taille_Explosion, 1);
            Destroy(gameObject);
        }
    }
}
