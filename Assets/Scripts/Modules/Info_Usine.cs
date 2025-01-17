using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info_Usine : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Asteoride"))
        {
            Destroy(gameObject);
        }
    }
}
