using UnityEngine;

public class MetronomeManager : MonoBehaviour
{   
    //Metronome Click
    public AudioClip metronomeClick;
    //Beats Per Minute
    public float bpm = 140;

    //Current time of the audio system
    public double time;
    //Time until the next click happens
    public double nextClick;
    //Value to switch audiosources, to prevent playback issues with the same source
    public int flip = 0;

    //Audio sources
    private AudioSource[] sources = new AudioSource[2];

    //Beat event
    public delegate void Beat();
    public event Beat OnBeat;

    void Start()
    {
        //Create the audio sources and set their clips
        for (int i = 0; i < 2; i++)
        {
            GameObject child = new GameObject("AudioSource");
            child.transform.parent = gameObject.transform;
            sources[i] = child.AddComponent<AudioSource>();
            sources[i].clip = metronomeClick;
        }

        //Decide when next click needs to happen
        nextClick = AudioSettings.dspTime + 2.0f;
    }
    
    void Update()
    {
        //Set the time to the current audio system time
        time = AudioSettings.dspTime;
        if (time > nextClick)
        {
            //Play the audio clip once one cycle according to the nextClick variable is complete 
            sources[flip].PlayScheduled(nextClick);

            //Increment the nextClick
            nextClick += 60.0f / bpm;

            //Flip the audio source
            flip = 1 - flip;

            OnBeat?.Invoke();
        }
    }
}
