
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The audio manager
/// </summary>
public static class AudioManager
{
    static bool initialized = false;
    static AudioSource audioSource;
    static Dictionary<AudioClipName, AudioClip> audioClips =
        new Dictionary<AudioClipName, AudioClip>();




    public static bool Initialized
    {
        get { return initialized; }
    }


    public static void Initialize(AudioSource source)
    {
        initialized = true;
        audioSource = source;

        audioClips.Add(AudioClipName.ButtonClick,
             Resources.Load<AudioClip>("ButtonClick"));
        audioClips.Add(AudioClipName.ExitClick,
             Resources.Load<AudioClip>("ExitClick"));
        audioClips.Add(AudioClipName.PlayClick,
             Resources.Load<AudioClip>("PlayClick"));
        audioClips.Add(AudioClipName.swoosh,
            Resources.Load<AudioClip>("swoosh"));
        audioClips.Add(AudioClipName.Fly,
           Resources.Load<AudioClip>("Fly"));
        audioClips.Add(AudioClipName.point,
           Resources.Load<AudioClip>("point"));
        audioClips.Add(AudioClipName.Die,
          Resources.Load<AudioClip>("Die"));

    }


    public static void Play(AudioClipName name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }
}
