using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToucheTruc : MonoBehaviour
{
    public bool touché;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Module")
        {
            touché = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (touché == true)
        {
            touché = false;
        }
    }
}
