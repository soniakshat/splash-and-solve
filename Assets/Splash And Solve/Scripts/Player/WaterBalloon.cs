using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SplashAndSolve
{
    public class WaterBalloon : MonoBehaviour
    {
        [SerializeField] List<Material> listWaterBalloonColors;
        [SerializeField] private GameObject prefWaterSplash;
        [SerializeField] private ParticleSystem particleWaterSplash;
        [SerializeField] private AudioClip balloonPop;
        private AudioSource audioSource;
        private GameObject _splash;

        private void Awake()
        {
            audioSource = gameObject.GetComponent<AudioSource>();
            gameObject.GetComponent<Renderer>().material = listWaterBalloonColors.SelectRandom();
        }

        private void SpawnSplash()
        {
            // use the particle system here
        }

        private void OnCollisionEnter(Collision collision)
        {
            //// Get the contact point and normal from the collision
            //ContactPoint contact = collision.contacts[0];
            //Vector3 spawnPosition = contact.point + new Vector3(0, 0.01f, -0.01f);
            //Quaternion spawnRotation = Quaternion.LookRotation(contact.normal);

            //// Instantiate the waterSplash at the contact point with the proper rotation
            //_splash = Instantiate(prefWaterSplash, spawnPosition, spawnRotation);
            var destroyTime = 2.0f;

            foreach (ContactPoint contact in collision.contacts)
            {    
                // Get the contact point and normal from the collision
                Vector3 contactPoint = contact.point;
                Vector3 normal = contact.normal;

                _splash = Instantiate(prefWaterSplash, contactPoint, Quaternion.identity);

                // Rotate the plane to be normal to the hit point
                _splash.transform.rotation = Quaternion.LookRotation(normal) * Quaternion.Euler(90, 0, 0);

                // Optional: Adjust position slightly to avoid z-fighting
                _splash.transform.position += normal * 0.01f;

                // Destroy splash after certain time
                Destroy(_splash, destroyTime);

                //// Create a new GameObject to hold the LineRenderer
                //GameObject lineObject = new GameObject("CollisionNormalLine");
                //LineRenderer lineRenderer = lineObject.AddComponent<LineRenderer>();

                //// Configure the LineRenderer
                //lineRenderer.startWidth = 0.05f;
                //lineRenderer.endWidth = 0.05f;
                //lineRenderer.material = new Material(Shader.Find("Sprites/Default")); // Default material
                //lineRenderer.startColor = Color.red;
                //lineRenderer.endColor = Color.blue;
                //lineRenderer.positionCount = 2;

                //// Set the positions of the LineRenderer to draw the normal
                //lineRenderer.SetPosition(0, contactPoint); // Start point of the line
                //lineRenderer.SetPosition(1, contactPoint + normal); // End point of the line (normal direction)

                //// Optional: Destroy the line after some time to clean up
                //Destroy(lineObject, destroyTime); // Line will be destroyed after 2 seconds
            }

            if (collision.gameObject.CompareTag("Target"))
            {
                Target target = collision.gameObject.GetComponent<Target>();
                string answer = target.GetHitAnswer();
                CustomLog.Log("Target Hit", $"Answer: {answer}");
                if (target.answered)
                {
                    return;
                }
                if (QuestionManager.Instance.VerifyAnswer(answer))
                {
                    ScoreManager.Instance.AddScore();
                    target.answered = true;
                    QuestionManager.Instance.SetNextQuestion();
                }
                else
                {
                    target.answered = true;
                    ScoreManager.Instance.RemoveScore();
                    target.SetRed();
                }
            }
            StartCoroutine(CoroutineDestroyBalloon());
        }

        private IEnumerator CoroutineDestroyBalloon()
        {
            SpawnSplash();
            audioSource.PlayOneShot(balloonPop);
            yield return new WaitForSeconds(0.1f);
            Destroy(this.gameObject);
        }
    }
}