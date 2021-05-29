using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatMarkerManager : MonoBehaviour
{
    public MetronomeManager metronome;
    
    void Update()
    {
        transform.position -= new Vector3(0f, (metronome.bpm / 60.0f) * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
