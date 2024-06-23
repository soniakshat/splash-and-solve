using UnityEngine;
using TMPro;


public class PlayerHud : MonoBehaviour
{
    [SerializeField] TMP_Text txtAmmo;

    private void OnEnable()
    {
        ProjectileThrower.OnBallonThrow += OnAmmoChange;
    }

    private void OnDisable()
    {
        ProjectileThrower.OnBallonThrow -= OnAmmoChange;
    }

    private void OnAmmoChange(int count)
    {
        txtAmmo.text = count.ToString();
    }
}
