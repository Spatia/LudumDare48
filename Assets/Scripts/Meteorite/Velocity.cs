using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocity : MonoBehaviour
{
    public int vitesse;
    private void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - vitesse);
    }
}
