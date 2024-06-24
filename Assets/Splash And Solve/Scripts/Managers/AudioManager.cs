using System;
using UnityEngine;

namespace SplashAndSolve
{
    [RequireComponent(typeof(AudioSource))]

    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;

        [SerializeField] private AudioClip backgroundAudio;
        private Action onMuteChanged;

        private AudioSource _audioSource;
        private bool _mute = false;
        private float _bgVolume = 1f;

        private void Awake()
        {
            Instance = this;
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            onMuteChanged += OnMuteChanged;
        }

        private void OnDisable()
        {
            onMuteChanged -= OnMuteChanged;
        }

        private void OnMuteChanged()
        {
            SetBgVolume(_mute ? 0 : _bgVolume);
        }

        private void Start()
        {
            PlayBackgroundMusic();
        }

        public void ChangeMuteStatus(bool mute)
        {
            _mute = mute;
        }

        public void SetBgVolume(float vol)
        {
            _bgVolume = vol;
            _audioSource.volume = vol;
        }

        private void PlayBackgroundMusic()
        {
            _audioSource.clip = backgroundAudio;
            _audioSource.loop = true;
            _audioSource.Play();
        }
    }
}