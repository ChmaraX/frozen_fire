using UnityEngine;

public class MusicLoop : MonoBehaviour
{
    public AudioSource musicSource;

    // Start is called before the first frame update
    void Start()
    {
        musicSource.PlayScheduled(AudioSettings.dspTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
}