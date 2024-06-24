using System;
using UnityEngine;

namespace SplashAndSolve {
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        private Enums.QuestionType selectedGameMode;
        private bool canVibrate;

        private void Awake()
        {
            Instance = this;
            canVibrate = PreferenceManager.GetInstance().GetVibrate();
        }

        public void SetGameMode(Enums.QuestionType questionType)
        {
            selectedGameMode = questionType;
        }

        public Enums.QuestionType GetGameMode()
        {
            return selectedGameMode;
        }

        public void SetVibrate(bool vibrate)
        {
            canVibrate = vibrate;
            PreferenceManager.GetInstance().SetVibrate(vibrate);
        }

        public void Vibrate()
        {
            if (canVibrate)
            {
                Handheld.Vibrate();
            }
        }
    }
}