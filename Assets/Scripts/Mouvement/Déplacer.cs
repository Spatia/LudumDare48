using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Déplacer : MonoBehaviour
{
    [SerializeField]
    KeyCode Up;
    [SerializeField]
    KeyCode Down;
    [SerializeField]
    KeyCode Right;
    [SerializeField]
    KeyCode Left;

    public int Limite_Haut_x;
    public int Limite_Haut_y;

    public int Limite_Bas_x;
    public int Limite_Bas_y;

    public int Vitesse;

    private float zoom;
    public float zoom_max;
    public float zoom_min;

    private void Start()
    {
        zoom = 260;
    }
    void FixedUpdate()
    {
        if (Input.GetKey(Up) && GetComponent<Transform>().position.y < Limite_Haut_y)
        {
            GetComponent<Transform>().position = new Vector2(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y + Vitesse);
        }
        if (Input.GetKey(Down) && GetComponent<Transform>().position.y > Limite_Bas_y)
        {
            GetComponent<Transform>().position = new Vector2(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y - Vitesse);
        }
        if (Input.GetKey(Right) && GetComponent<Transform>().position.x < Limite_Haut_x)
        {
            GetComponent<Transform>().position = new Vector2(GetComponent<Transform>().position.x + Vitesse, GetComponent<Transform>().position.y);
        }
        if (Input.GetKey(Left) && GetComponent<Transform>().position.x > Limite_Bas_x)
        {
            GetComponent<Transform>().position = new Vector2(GetComponent<Transform>().position.x - Vitesse, GetComponent<Transform>().position.y);
        }
    }
}