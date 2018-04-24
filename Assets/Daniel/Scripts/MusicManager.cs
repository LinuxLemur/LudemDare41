using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] _clips;

    private AudioSource _sourcee;
    private AudioClip clipToPlay;

    private void Awake()
    {
        _sourcee = gameObject.GetComponent<AudioSource>();
               
        StartCoroutine(PlayAudio());
    }

    IEnumerator PlayAudio()
    {
        clipToPlay = _clips[Random.Range(0, _clips.Length)];
        
        _sourcee.clip = clipToPlay;
        
        _sourcee.Play();
        
        yield return new WaitForSeconds(clipToPlay.length);

        StartCoroutine(PlayAudio());
    }
}