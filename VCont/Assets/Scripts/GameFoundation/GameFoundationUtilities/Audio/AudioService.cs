namespace GameFoundation.GameFoundationUtilities.Audio
{
    using UnityEngine;

    public class AudioService : IAudioService
    {
        public void PlaySound(string name, AudioSource sender)
        {
            throw new System.NotImplementedException();
        }

        public void PlaySound(string name, bool isLoop = false, float volumeScale = 1, float fadeSeconds = 1, bool isAverage = false)
        {
            throw new System.NotImplementedException();
        }

        public void StopAllSound()
        {
            throw new System.NotImplementedException();
        }

        public void StopAll()
        {
            throw new System.NotImplementedException();
        }

        public void PlayPlayList(string musicName, bool random = false, float volumeScale = 1, float fadeSeconds = 1, bool persist = false)
        {
            throw new System.NotImplementedException();
        }

        public void PlayPlayList(AudioClip audioClip, bool random = false, float volumeScale = 1, float fadeSeconds = 1, bool persist = false)
        {
            throw new System.NotImplementedException();
        }

        public void StopPlayList()
        {
            throw new System.NotImplementedException();
        }

        public void SetPlayListTime(float time)
        {
            throw new System.NotImplementedException();
        }

        public float GetPlayListTime()
        {
            throw new System.NotImplementedException();
        }

        public void SetPlayListPitch(float pitch)
        {
            throw new System.NotImplementedException();
        }

        public void SetPlayListLoop(bool isLoop)
        {
            throw new System.NotImplementedException();
        }

        public void PausePlayList()
        {
            throw new System.NotImplementedException();
        }

        public void ResumePlayList()
        {
            throw new System.NotImplementedException();
        }

        public bool IsPlayingPlayList()
        {
            throw new System.NotImplementedException();
        }

        public void StopAllPlayList()
        {
            throw new System.NotImplementedException();
        }

        public void PauseEverything()
        {
            throw new System.NotImplementedException();
        }

        public void ResumeEverything()
        {
            throw new System.NotImplementedException();
        }
    }
}