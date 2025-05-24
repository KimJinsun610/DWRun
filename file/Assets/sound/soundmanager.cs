using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Sound
{
    public string SoundName;
    public AudioClip clip;
}

public class soundmanager : MonoBehaviour
{
    public static soundmanager instance;

    [Header("사운드등록")]
    [SerializeField] Sound[] bgmSounds;
    [SerializeField] Sound[] sxfSounds;

    [Header("브금플레이어")]
    [SerializeField] AudioSource bgmPlayer;

    [Header("효과음플레이어")]
    [SerializeField] AudioSource[] sxfPlayer;

    void Start()
    {
        instance = this;
        PlayBGM(); 
    }

    public void PlaySE(string _soundName)
    {
        for(int i = 0; i< sxfSounds.Length; i++)
        {
            if(_soundName == sxfSounds[i].SoundName)
            {
                for(int x = 0; x<sxfPlayer.Length; x++)
                {
                    if (!sxfPlayer[x].isPlaying)
                    {
                        sxfPlayer[x].clip = sxfSounds[i].clip;
                        sxfPlayer[x].Play();
                        return;
                     }
                }
                Debug.Log("모든 효과음 플레이어가 사용중");
                return;
            }
        }
        Debug.Log("등록된 효과음이 없음");
    }

    public void PlayBGM()
    {
        bgmPlayer.clip = bgmSounds[0].clip;
        bgmPlayer.Play();

    }
   
}
