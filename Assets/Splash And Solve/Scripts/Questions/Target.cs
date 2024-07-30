using UnityEngine;
using TMPro;
using System;

namespace SplashAndSolve
{
    public class Target : MonoBehaviour
    {
        [SerializeField] private TMP_Text txtValue;
        private string answer;
        private GameObject player;
        public bool answered = false;

        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        private void Update()
        {
            FacePlayer();
        }

        private void FacePlayer()
        {
            if(player==null)
            { 
                return;
            }
            // Calculate the direction from the object to the player
            Vector3 direction = (player.transform.position - transform.position).normalized;

            // Calculate the rotation needed to face the player
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);

            // Apply the rotation to the object
            transform.rotation = rotation;
        }

        public void SetAnswer(string answer)
        {
            txtValue.color = Color.white;
            this.answer = answer;
            txtValue.text = answer;
            answered = false;
        }

        public string GetHitAnswer()
        {
            return answer;
        }

        public void SetRed()
        {
            txtValue.color = Color.red;
        }
    }
}