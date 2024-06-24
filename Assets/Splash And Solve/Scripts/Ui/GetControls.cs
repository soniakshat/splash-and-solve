using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SplashAndSolve
{
    public class GetControls : MonoBehaviour
    {
        [SerializeField] private Toggle runningToggle;
        [SerializeField] private Button shootButton;
        public static Action OnShootClick;
        
        public Button GetShootButton()
        {
            return shootButton;
        }
        public Toggle GetRunningToggle()
        {
            return runningToggle;
        }

        public void OnShootButtonClick()
        {
            OnShootClick?.Invoke();
        }
    }
}