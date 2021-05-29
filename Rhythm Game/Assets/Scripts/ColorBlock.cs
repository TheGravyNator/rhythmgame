using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorBlock : MonoBehaviour
{
    public MetronomeManager metronome;

    public Image image;

    public bool flip;

    // Start is called before the first frame update
    void Start()
    {
        metronome.OnBeat += Beat;
        image = gameObject.GetComponent<Image>();
    }

    void Beat()
    {
        if (flip)
        {
            flip = false;
            image.color = Color.green;
        }
        else if (!flip)
        {
            flip = true;
            image.color = Color.magenta;
        }
        
    }
}
