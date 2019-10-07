using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudioChooser : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClips;

    private void Start()
    {
        if (audioClips.Length > 0)
        {
            int index = Random.Range(0, audioClips.Length);
            var audioSource = GetComponent<AudioSource>();
            audioSource.clip = audioClips[index];
            audioSource.Play();
        }
    }
}
