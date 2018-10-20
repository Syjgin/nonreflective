using System.Collections.Generic;
using UnityEngine;

public class AudioManager
{
    public static void PlaySound(AudioSource source, List<AudioClip> ac)
    {
        source.pitch = Random.Range(1f, 1.2f);
        int clip = Random.Range(0, ac.Count);

        source.PlayOneShot(ac[clip]);
    }
}