using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points_de_vie : MonoBehaviour
{
    public int pv;

    // Update is called once per frame
    void Update()
    {
        if (pv <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
