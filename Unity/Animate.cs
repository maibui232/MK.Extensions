namespace MK.Extensions
{
    using System;
    using Cysharp.Threading.Tasks;
    using UnityEngine;

    public abstract class Animate : MonoBehaviour
    {
        public abstract void Play();
        public abstract void Pause();
        public abstract void Stop();

        public abstract UniTask PlayAsync();

        public event Action Played;
        public event Action Paused;
        public event Action Stopped;

        protected virtual void OnPlayed()
        {
            this.Played?.Invoke();
        }

        protected virtual void OnPaused()
        {
            this.Paused?.Invoke();
        }

        protected virtual void OnStopped()
        {
            this.Stopped?.Invoke();
        }
    }
}