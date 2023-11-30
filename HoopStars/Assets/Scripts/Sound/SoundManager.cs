using System;
using UnityEngine;

namespace hoopStars.sound
{
    public class SoundManager : MonoSingletonGeneric<SoundManager>
    {
        public AudioSource SoundEffect;
        public AudioSource SoundMusic;
        [Range(0f, 1f)] public float userMusicVolume;
        [Range(0f, 1f)] public float userFXVolume;
        public float Volume = 1f;
        public SoundType[] Soundtypes;

        [Range(0f, 1f)]public float userVolume;

        private void Start()
        {
            SetVolume(userVolume);
            SetMusicVolume(userMusicVolume);
            SetFXVolume(userFXVolume);
            PlayMusic(Sounds.music);
        }

        public void SetMusic()
        {
            if (SoundMusic.isPlaying)
            {
                SoundMusic.Pause();
            }
            else
            {
                SoundMusic.Play();
            }
        }
        public void SetVolume(float volume)
        {
            Volume = volume;
            SetFXVolume(volume);
            SetMusicVolume(volume);
        }
        private void SetMusicVolume(float value)
        {
            SoundMusic.volume = value;
        }
        private void SetFXVolume(float value)
        {
            SoundEffect.volume = value;
        }
        

        public void PlayMusic(Sounds sound)
        {
            AudioClip clip = getSoundClip(sound);
            if (clip != null)
            {
                SoundMusic.clip = clip;
                SoundMusic.Play();
            }
            else
            {
                Debug.LogError("Sound Clip :" + clip.name + "not found");
            }
        }
        public void Play(Sounds sound)
        {
            AudioClip clip = getSoundClip(sound);
            if (clip != null)
            {
                SoundEffect.loop = false;
                SoundEffect.PlayOneShot(clip);
            }
            else
            {
                Debug.LogError("Sound Clip :" + clip.name + "not found");
            }
        }
        public void PlayAudio(AudioClip sound)
        {
            AudioClip clip = sound;
            SetMusic();
            if (clip != null && !SoundEffect.isPlaying)
            {
                SoundEffect.PlayOneShot(clip);
            }
            else
            {
                Debug.LogError("Sound Clip :" + clip.name + "not found");
            }

        }

        private AudioClip getSoundClip(Sounds sound)
        {
            SoundType returnsound = Array.Find(Soundtypes, item => item.soundType == sound);
            if (returnsound != null)
            {
                return returnsound.soundclip;
            }
            return null;
        }

        public void StopEffect()
        {
            SoundEffect.Stop();
            SetMusic();
        }

    }


    [Serializable]
    public class SoundType
    {
        public Sounds soundType;
        public AudioClip soundclip;
    }
    public enum Sounds
    {
        ButtonClick,
        music
    }

}

