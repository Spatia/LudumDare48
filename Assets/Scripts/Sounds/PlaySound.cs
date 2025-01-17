using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource click;
    public AudioSource tick;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playclick()
    {
        click.Play();
    }

    public void PlayTick()
    {
        tick.Play();
    }
}
