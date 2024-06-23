using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBalloon : MonoBehaviour
{

    [SerializeField] List<Material> listWaterBalloonColors;
    [SerializeField] private ParticleSystem waterSplash;

    private void Awake()
    {
        gameObject.GetComponent<Renderer>().material = listWaterBalloonColors[Random.Range(0, listWaterBalloonColors.Count - 1)];
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Balloon collided with: {collision.gameObject.name}");
        StartCoroutine(CoroutineDestroyBalloon());
    }

    private IEnumerator CoroutineDestroyBalloon()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
}
