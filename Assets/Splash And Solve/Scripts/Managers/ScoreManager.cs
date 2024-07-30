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

        public int GetScore()
        {
            return _score;
        }

        public void AddScore()
        { 
            _score += AppConstants.MARK;
            UiManager.Instance.ShowScore(_score);
        }

        public void RemoveScore()
        {
            _score += AppConstants.PENALTY;
            if (_score <= 0)
                _score = 0;
            UiManager.Instance.ShowScore(_score);
        }
    }
}