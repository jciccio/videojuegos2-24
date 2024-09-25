using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

[System.Serializable]
public class Sound{

    [Header("General")]
    // Id
    public string Name;
    public AudioClip Clip;
    // Clip
    // Audio Source
    public AudioSource Source;

    [Header("Properties")]
    // Volumen
    [Range(0f, 1f)] public float Volume = 1f;
    [Range(0f, 2f)] public float Pitch = 1f;
    // Loop
    public bool Loop = false;

    public void SetSource(AudioSource _source){
        Source = _source;
        Source.clip = Clip;
    }

    // Play
    public void Play(){
        Source.volume = Volume * Volume;
        Source.pitch = Pitch;
        Source.loop = Loop;
        Source.Play();
    }

    public void UpdateAudioSettings(Dictionary<string, float> props){
        if(Source != null){
            Source.pitch = props.ContainsKey("Pitch") ? props["Pitch"] : Source.pitch;
            Source.volume = props.ContainsKey("Volume") ? props["Volume"] : Source.volume;
        }
    }

}



public class AudioManager : MonoBehaviour
{
   
    public static AudioManager instance;

    [SerializeField] private Sound [] Sfx;
    [SerializeField] private Sound [] Music;

    void Awake(){
        if(instance == null){
            instance = this;
            GameObject.DontDestroyOnLoad(this);
        }
        else if(instance != this){
            Destroy(this);
        }

        InitAudioArrays(Sfx, "SFX");
        InitAudioArrays(Music, "Music");
    }


    void InitAudioArrays(Sound [] array, string prefix){
        for(int  i = 0 ; i < array.Length ; i++){
            GameObject _audio = new GameObject($"{prefix}_{i}_{array[i].Name}");
            _audio.transform.parent = transform;
            array[i].SetSource(_audio.AddComponent<AudioSource>());
        }
    }


    public void PlaySfx(string name){
        Sound audio = SearchSound(name, Sfx);
        if(audio != null){
            audio.Play();
        }
    }

    public void PlayMusic(string name){
        Sound audio = SearchSound(name, Music);
        if(audio != null){
            audio.Play();
        }
    }

    private Sound SearchSound(string name, Sound [] audios){
        foreach(Sound audio in audios){
            if(audio.Name == name){
                return audio;
            }
        }
        Debug.LogError($"AudioManage: audio {name} was not found");
        return null;
    }


}
