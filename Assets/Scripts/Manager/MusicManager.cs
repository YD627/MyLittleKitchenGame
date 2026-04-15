using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }
    private AudioSource musicSource;
    private float originalVolume;
    private int volume = 5; // 用户可以设置的声音大小
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        musicSource = GetComponent<AudioSource>();
        originalVolume = musicSource.volume;
        UpdateVolume();
    }
    public void ChangeVolume()
    {
        volume++;
        if (volume > 10) volume = 0;

        musicSource.volume = originalVolume * (volume / 10.0f);
    }
    public int GetVolume()
    {
        return volume;
    }
    private void UpdateVolume()
    {
        if(volume == 0)
        {
            musicSource.enabled = false;
        }
        else
        {
            musicSource.enabled = true;
            musicSource.volume = originalVolume * (volume / 10.0f);
        }
            
    }
}
