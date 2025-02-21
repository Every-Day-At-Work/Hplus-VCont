namespace GameFoundation.GameFoundationUtilities.Audio
{
    using UnityEngine;

    public interface IAudioService
    {
        void  PlaySound(string name, AudioSource sender);
        void  PlaySound(string name, bool isLoop = false, float volumeScale = 1f, float fadeSeconds = 1f, bool isAverage = false);
        void  StopAllSound();
        void  StopAll();
        void  PlayPlayList(string musicName, bool random = false, float volumeScale = 1f, float fadeSeconds = 1f, bool persist = false);
        void  PlayPlayList(AudioClip audioClip, bool random = false, float volumeScale = 1f, float fadeSeconds = 1f, bool persist = false);
        void  StopPlayList();
        void  SetPlayListTime(float time);
        float GetPlayListTime();
        void  SetPlayListPitch(float pitch);
        void  SetPlayListLoop(bool isLoop);
        void  PausePlayList();
        void  ResumePlayList();
        bool  IsPlayingPlayList();
        void  StopAllPlayList();
        void  PauseEverything();
        void  ResumeEverything();
    }
}