using UnityEngine;

namespace SplashAndSolve
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance;
        private int _score;

        private void Awake()
        {
            Instance = this;
        }

        public void AddScore()
        { 
            _score += 4;
            UiManager.Instance.ShowScore(_score);
        }

        public void RemoveScore()
        {
            _score -= 1;
            if (_score <= 0)
                _score = 0;
            UiManager.Instance.ShowScore(_score);
        }
    }
}