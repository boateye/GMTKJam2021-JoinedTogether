using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDestructionSound : MonoBehaviour
{
    public AudioClip destructionSFX;
    public AudioSource audioSource;

    // Play destruction SFX when model is spawned in
    void Awake()
    {
        audioSource.PlayOneShot(destructionSFX);
    }

}
