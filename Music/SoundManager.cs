using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] musicClips;
    private int currentTrack;
    private AudioSource source;

    public Text clipTitleText;
    public Text clipTimeText;

    private int fullLength;
    private int playTime;
    private int second;
    private int minutes;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        //player music
        //PlayMusic();
    }

    public void SetPlayList(XRBaseInteractable lpPan)
    {
        Debug.Log("before : " + musicClips.Length);
        
        musicClips = lpPan.GetComponent<LProte>().musicClips;

        Debug.Log("after : " + musicClips.Length);
    }
    public void PlayMusic()
    {
        if (source.isPlaying)
        {
            return;
        }
        currentTrack--;
        if (currentTrack < 0)
        {
            currentTrack = musicClips.Length - 1;
        }
        StartCoroutine("WaitForMusicEnd");
    }
    IEnumerator WaitForMusicEnd()
    {
        while (source.isPlaying)
        {
            playTime = (int)source.time;
            ShowPlayTime();
            yield return null;
        }
        NextTitle();
    }
    public void NextTitle()
    {
        source.Stop();
        currentTrack++;
        if (currentTrack > musicClips.Length - 1)
        {
            currentTrack = 0;
        }
        source.clip = musicClips[currentTrack];
        source.Play();

        //show title
        ShowCurrentTitle();

        StartCoroutine("WaitForMusicEnd");
    }
    // Update is called once per frame

    public void PreviousTitle()
    {
        source.Stop();
        currentTrack--;
        if (currentTrack > 0)
        {
            currentTrack = musicClips.Length - 1;
        }
        source.clip = musicClips[currentTrack];
        source.Play();

        //show title
        ShowCurrentTitle();

        StartCoroutine("WaitForMusicEnd");
    }

    public void StopMusic()
    {
        source.Stop();
        StopCoroutine("WaitForMusicEnd");
        //StopAllCoroutines();
    }

    public void MuteMusic()
    {
        source.mute = !source.mute;
    }

    void ShowCurrentTitle()
    {
        clipTitleText.text = source.clip.name;
        fullLength = (int)source.clip.length;
    }

    void ShowPlayTime()
    {
        second = playTime % 60;
        minutes = (playTime / 60) % 60;
        clipTimeText.text = minutes + ":" + second.ToString("D2") + "/" + ((fullLength / 60) % 60) + ":" + (fullLength % 60).ToString("D2");
    }
}
