using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneManager : MonoBehaviour
{
    public MetronomeManager metronome;
    public GameObject spawner;
    public float spawnerTransformX;
    public float speed;

    public GameObject beatMarker;
    
    public int currentFlip;

    private void Start()
    {
        currentFlip = metronome.flip;
    }

    private void Update()
    {
        if (currentFlip != metronome.flip)
        {
            int chance = Random.Range(0,2);
            if (chance == 1)
            {
                GameObject currentMarker = Instantiate(beatMarker, new Vector3(spawner.transform.position.x, spawner.transform.position.y + 8f), Quaternion.identity);
                currentMarker.transform.parent = spawner.transform;
                currentMarker.GetComponent<BeatMarkerManager>().metronome = metronome;
            }
            currentFlip = metronome.flip;
        }
    }
}
