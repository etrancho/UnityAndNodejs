using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    public VideoPlayer screen;
    public VideoClip video1;
    public VideoClip video2;
    public VideoClip video3;
    public AudioSource pt;
    public AudioSource pc;
    public void pause()
    {
        if (screen.isPlaying)
        {
            screen.Pause();
        }
        else
        {
            screen.Play();
        }
    }
    public void playVideo1()
    {
        pt.Stop();
        screen.clip = video1;
    }
    public void playVideo2()
    {
        pt.Stop();
        screen.clip = video2;
    }
    public void playVideo3()
    {
        pt.Stop();
        screen.clip = video3;
    }
    public void exit()
    {
        if (screen.isPlaying || screen.isPaused)
        {
            screen.Stop();
            pc.Play();
            pt.Play();
        }
    }
}