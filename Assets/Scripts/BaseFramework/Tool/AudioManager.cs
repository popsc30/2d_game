using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioManager : BaseManager<AudioManager>
{
    private GameObject bkMusicObj;
    private AudioSource bkMusic;
    private string musicName;
    private float bkValue = 5f;
    private bool isStopBKMusic = false;
    private GameObject soundMusicObj;
    private List<AudioSource> listSoundMusic = new List<AudioSource>();
    private float soundValue = 0.5f;
    private bool isStopSound = false;
    private GameObject audioManager;

    public AudioManager()
    {
        if (audioManager == null)
        {
            audioManager = new GameObject();
            audioManager.name = "AudioManager";
            MonoManager.Instance.AddUpdateListener(Update);
            GameObject.DontDestroyOnLoad(audioManager);
        }
    }

    private void Update()
    {
        if (listSoundMusic.Count > 0)
            for (int i = listSoundMusic.Count - 1; i >= 0; i--)
            {

                if (listSoundMusic[i].isPlaying == false)
                {
                    listSoundMusic[i].Stop();
                    GameObject.Destroy(listSoundMusic[i]);
                    listSoundMusic.RemoveAt(i);
                }

            }
    }
    public void PlaySoundMusic(string soundName, bool isLoop = false, UnityAction<AudioSource> callBack = null)
    {
        if (soundMusicObj == null)
        {
            soundMusicObj = new GameObject();
            soundMusicObj.transform.SetParent(audioManager.transform);
            soundMusicObj.name = "SoundMusic";
        }
        AudioSource sound = soundMusicObj.AddComponent<AudioSource>();
        ResourcesManager.Instance.LoadAsync<AudioClip>("Sounds/" + soundName, (clip) =>
        {

            sound.clip = clip;
            sound.loop = isLoop;
            sound.Play();
            sound.volume = soundValue;
            sound.mute = isStopSound;
            if (callBack != null) callBack.Invoke(sound);
            listSoundMusic.Add(sound);
        });

    }
    public void SetSoundValue(float value)
    {
        soundValue = value;
        for (int i = 0; i < listSoundMusic.Count; i++)
        {
            listSoundMusic[i].volume = soundValue;
        }
    }
    public void SetSoundMute(bool isMute)
    {
        isStopSound = !isMute;
        for (int i = 0; i < listSoundMusic.Count; i++)
        {
            listSoundMusic[i].mute = !isMute;
        }
    }
    public void StopSoundMusic(AudioSource source)
    {
        if (listSoundMusic.Contains(source))
        {
            listSoundMusic.Remove(source);
            source.Stop();
            GameObject.Destroy(source);
        }
    }

}
