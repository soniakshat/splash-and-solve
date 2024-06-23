using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Target : MonoBehaviour
{
    [SerializeField] private TMP_Text txtValue;
    [SerializeField] private bool isResult;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("WaterBalloon")) {
            Debug.Log("Correct Answer hit!");
        }
    }
}
