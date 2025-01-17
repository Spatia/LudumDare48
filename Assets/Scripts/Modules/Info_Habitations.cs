using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info_Habitations : MonoBehaviour
{
    public int Nb_Personnes_Présentes;
    public bool update;
    public GameObject Character;
    private GameObject temp;
    public int position;

    void Start()
    {
        Nb_Personnes_Présentes = 0;
        update = false;
    }
    private void Update()
    {
        if (update == true)
        {
            if (Nb_Personnes_Présentes == 1)
            {
                temp = Instantiate(Character, new Vector3(transform.position.x - 20, transform.position.y - 10, 0), Quaternion.identity);
                temp.transform.parent = transform;
                update = false;
            }
            else if (Nb_Personnes_Présentes == 2)
            {
                temp = Instantiate(Character, new Vector3(transform.position.x + 20, transform.position.y - 10, 0), Quaternion.identity);
                temp.transform.parent = transform;
                update = false;
            }
        }
    }
}