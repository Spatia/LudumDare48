using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_no : MonoBehaviour
{
    public bool Base_Number;

    public Sprite On;
    public Sprite Off;

    public int Truc_on = 0;

    public LayerMask layermask;

    private RaycastHit2D Vide;

    RaycastHit2D hit_up;
    RaycastHit2D hit_down;
    RaycastHit2D hit_right;
    RaycastHit2D hit_left;

    private void FixedUpdate()
    {
        if (Truc_on > 0)
        {
            if (Truc_on == 1)
            {
                hit_up = Physics2D.Raycast(new Vector3(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y + 70, 0), Vector2.zero, 1, layermask);
                hit_down = Physics2D.Raycast(new Vector3(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y - 70, 0), Vector2.zero, 10, layermask);
                hit_right = Physics2D.Raycast(new Vector3(GetComponent<Transform>().position.x + 70, GetComponent<Transform>().position.y, 0), Vector2.zero, 10, layermask);
                hit_left = Physics2D.Raycast(new Vector3(GetComponent<Transform>().position.x - 70, GetComponent<Transform>().position.y, 0), Vector2.zero, 10, layermask);
            }
            else if (Truc_on == 2)
            {
                hit_up = Physics2D.Raycast(new Vector3(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y + 140, 0), Vector2.zero, 1, layermask);
                hit_down = Physics2D.Raycast(new Vector3(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y - 140, 0), Vector2.zero, 10, layermask);
                hit_right = Physics2D.Raycast(new Vector3(GetComponent<Transform>().position.x + 140, GetComponent<Transform>().position.y, 0), Vector2.zero, 10, layermask);
                hit_left = Physics2D.Raycast(new Vector3(GetComponent<Transform>().position.x - 140, GetComponent<Transform>().position.y, 0), Vector2.zero, 10, layermask);
            }

            if (hit_up != Vide)
            {
                if (hit_up.transform.GetComponent<Tunnel_Détection>() != null)
                {
                    if (Base_Number == false)
                    {
                        GetComponent<Base_no>().Base_Number = hit_up.transform.GetComponent<Base_no>().Base_Number;
                    }
                }
                else
                {
                    hit_up = Vide;
                }
            }

            if (hit_down != Vide)
            {
                if (hit_down.transform.GetComponent<Tunnel_Détection>() != null)
                {
                    if (Base_Number == false)
                    {
                        GetComponent<Base_no>().Base_Number = hit_down.transform.GetComponent<Base_no>().Base_Number;
                    }
                }
                else
                {
                    hit_down = Vide;
                }
            }

            if (hit_right != Vide)
            {
                if (hit_right.transform.GetComponent<Tunnel_Détection>() != null)
                {
                    if (Base_Number == false)
                    {
                        GetComponent<Base_no>().Base_Number = hit_right.transform.GetComponent<Base_no>().Base_Number;
                    }
                }
                else
                {
                    hit_right = Vide;
                }
            }

            if (hit_left != Vide)
            {
                if (hit_left.transform.GetComponent<Tunnel_Détection>() != null)
                {
                    if (Base_Number == false)
                    {
                        GetComponent<Base_no>().Base_Number = hit_left.transform.GetComponent<Base_no>().Base_Number;
                    }
                }
                else
                {
                    hit_left = Vide;
                }
            }

            if (hit_up == Vide && hit_down == Vide && hit_right == Vide && hit_left == Vide)
            {
                Base_Number = false;
            }

            if (Base_Number == true)
            {
                GetComponent<SpriteRenderer>().sprite = On;
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = Off;
            }
        }
    }
}
