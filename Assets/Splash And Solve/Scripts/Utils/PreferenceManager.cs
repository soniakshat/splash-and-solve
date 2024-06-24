using UnityEngine;

namespace SplashAndSolve
{
    public class PreferenceManager
    {
        private static PreferenceManager _instance;

        private const string PREF_AUDIO_MUTE = "PREF_AUDIO_MUTE";
        private const string PREF_AUDIO_VIBRATE = "PREF_AUDIO_VIBRATE";

        public static PreferenceManager GetInstance()
        {
            return _instance ??= new PreferenceManager();
        }

        public void ClearAllPrefs()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }

        public void SetMute(bool mute)
        {
            PlayerPrefs.SetInt(PREF_AUDIO_MUTE, mute ? 1 : 0);
        }

        public bool GetMute()
        {
            return PlayerPrefs.GetInt(PREF_AUDIO_MUTE, 0) == 1;
        }

        public void SetVibrate(bool vibrate)
        {
            PlayerPrefs.SetInt(PREF_AUDIO_VIBRATE, vibrate ? 1 : 0);
        }

        public bool GetVibrate()
        {
            return PlayerPrefs.GetInt(PREF_AUDIO_VIBRATE, 0) == 1;
        }
    }
}