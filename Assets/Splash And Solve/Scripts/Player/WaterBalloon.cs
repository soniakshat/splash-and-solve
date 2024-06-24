using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SplashAndSolve
{
    public class WaterBalloon : MonoBehaviour
    {

        [SerializeField] List<Material> listWaterBalloonColors;
        [SerializeField] private ParticleSystem waterSplash;
        [SerializeField] private AudioClip balloonPop;
        private AudioSource audioSource;

        private void Awake()
        {
            audioSource = gameObject.GetComponent<AudioSource>();
            gameObject.GetComponent<Renderer>().material = listWaterBalloonColors.SelectRandom();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Target"))
            {
                Target target = collision.gameObject.GetComponent<Target>();
                string answer = target.GetHitAnswer();
                CustomLog.Log("Target Hit", $"Answer: {answer}");
                if (QuestionManager.Instance.VerifyAnswer(answer))
                {
                    ScoreManager.Instance.AddScore();
                    QuestionManager.Instance.SetNextQuestion();
                }
                else 
                {
                    ScoreManager.Instance.RemoveScore();
                    target.SetRed();
                }
            }
            StartCoroutine(CoroutineDestroyBalloon());
        }

        private IEnumerator CoroutineDestroyBalloon()
        {
            // hide balloon here and then
            // Start water splash particle here
            // destroy balloon once the particle effect gets over
            audioSource.PlayOneShot(balloonPop);
            yield return new WaitForSeconds(0.1f);
            Destroy(this.gameObject);
        }
    }
}