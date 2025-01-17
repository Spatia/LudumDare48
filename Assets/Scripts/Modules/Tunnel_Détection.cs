using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tunnel_Détection : MonoBehaviour
{
    public Sprite Sprite_1;
    public Sprite Sprite_2;
    public Sprite Sprite_3;
    public Sprite Sprite_4;
    public Sprite Sprite_5;
    public Sprite Sprite_6;
    public Sprite Sprite_7;
    public Sprite Sprite_8;
    public Sprite Sprite_9;
    public Sprite Sprite_10;
    public Sprite Sprite_11;
    public Sprite Sprite_12;
    public Sprite Sprite_13;
    public Sprite Sprite_14;
    public Sprite Sprite_15;
    public Sprite Sprite_16;

    public bool Up;
    public bool Down;
    public bool Right;
    public bool Left;

    public LayerMask layermask;

    private RaycastHit2D Vide;

    void FixedUpdate()
    {
        if (Spawn_Habitation.Actif == true)
        {
            RaycastHit2D hit_up;
            RaycastHit2D hit_down;
            RaycastHit2D hit_right;
            RaycastHit2D hit_left;

            Up = false;
            Down = false;
            Right = false;
            Left = false;

            hit_up = Physics2D.Raycast(new Vector3(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y + 70, 0), Vector2.zero, 1, layermask);
            hit_down = Physics2D.Raycast(new Vector3(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y - 70, 0), Vector2.zero, 10, layermask);
            hit_right = Physics2D.Raycast(new Vector3(GetComponent<Transform>().position.x + 70, GetComponent<Transform>().position.y, 0), Vector2.zero, 10, layermask);
            hit_left = Physics2D.Raycast(new Vector3(GetComponent<Transform>().position.x - 70, GetComponent<Transform>().position.y, 0), Vector2.zero, 10, layermask);

            if (hit_up != Vide)
            {
                if (GetComponent<Base_no>().Base_Number == false)
                {
                    GetComponent<Base_no>().Base_Number = hit_up.transform.GetComponent<Base_no>().Base_Number;
                }
                Up = true;
            }
            else
            {
                hit_up = Vide;
            }

            if (hit_down != Vide)
            {
                if (GetComponent<Base_no>().Base_Number == false)
                {
                    GetComponent<Base_no>().Base_Number = hit_down.transform.GetComponent<Base_no>().Base_Number;
                }
                Down = true;
            }
            else
            {
                hit_down = Vide;
            }

            if (hit_right != Vide)
            {
                if (GetComponent<Base_no>().Base_Number == false)
                {
                    GetComponent<Base_no>().Base_Number = hit_right.transform.GetComponent<Base_no>().Base_Number;
                }
                Right = true;
            }
            else
            {
                hit_right = Vide;
            }

            if (hit_left != Vide)
            {
                if (GetComponent<Base_no>().Base_Number == false)
                {
                    GetComponent<Base_no>().Base_Number = hit_left.transform.GetComponent<Base_no>().Base_Number;
                }
                Left = true;
            }
            else
            {
                hit_left = Vide;
            }

            if (hit_up == Vide && hit_down == Vide && hit_right == Vide && hit_left == Vide)
            {
                GetComponent<Base_no>().Base_Number = false;
            }

            //4 et 0 cotés
            if (Up == false && Down == false && Right == false && Left == false)
            {
                GetComponent<SpriteRenderer>().sprite = Sprite_1;
            }
            if (Up == true && Down == true && Right == true && Left == true)
            {
                GetComponent<SpriteRenderer>().sprite = Sprite_2;
            }

            //3 cotés
            if (Up == true && Down == true && Right == false && Left == true)
            {
                GetComponent<SpriteRenderer>().sprite = Sprite_3;
            }
            if (Up == true && Down == false && Right == true && Left == true)
            {
                GetComponent<SpriteRenderer>().sprite = Sprite_4;
            }
            if (Up == true && Down == true && Right == true && Left == false)
            {
                GetComponent<SpriteRenderer>().sprite = Sprite_5;
            }
            if (Up == false && Down == true && Right == true && Left == true)
            {
                GetComponent<SpriteRenderer>().sprite = Sprite_6;
            }

            //2 cotés
            if (Up == true && Down == true && Right == false && Left == false)
            {
                GetComponent<SpriteRenderer>().sprite = Sprite_7;
            }
            if (Up == false && Down == false && Right == true && Left == true)
            {
                GetComponent<SpriteRenderer>().sprite = Sprite_8; 
            }
            if (Up == false && Down == true && Right == true && Left == false)
            {
                GetComponent<SpriteRenderer>().sprite = Sprite_9;
            }
            if (Up == false && Down == true && Right == false && Left == true)
            {
                GetComponent<SpriteRenderer>().sprite = Sprite_10;
            }
            if (Up == true && Down == false && Right == true && Left == false)
            {
                GetComponent<SpriteRenderer>().sprite = Sprite_11;
            }
            if (Up == true && Down == false && Right == false && Left == true)
            {
                GetComponent<SpriteRenderer>().sprite = Sprite_12;
            }

            //1 coté
            if (Up == true && Down == false && Right == false && Left == false)
            {
                GetComponent<SpriteRenderer>().sprite = Sprite_13;
            }
            if (Up == false && Down == false && Right == true && Left == false)
            {
                GetComponent<SpriteRenderer>().sprite = Sprite_14;
            }
            if (Up == false && Down == false && Right == false && Left == true)
            {
                GetComponent<SpriteRenderer>().sprite = Sprite_15;
            }
            if (Up == false && Down == true && Right == false && Left == false)
            {
                GetComponent<SpriteRenderer>().sprite = Sprite_16;
            }
        }
    }
}