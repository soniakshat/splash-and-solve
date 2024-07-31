using System;
using UnityEngine;

namespace SplashAndSolve {
    public class ProjectileThrower : MonoBehaviour
    {
        public static Action<int> OnBallonThrow;
        public static ProjectileThrower Instance;
        [SerializeField] private float rayDistance = 10f;
        [SerializeField] private float gravityMultiplier = 1f;
        [SerializeField] private Transform throwFrom;
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private GameObject hitMarkerPrefab;
        private int ammoCount;
        private GameObject hitMarker;
        private Camera mainCamera;

        private void Awake()
        {
            Instance = this;
            ammoCount = AppConstants.MAX_AMMO;
            OnBallonThrow?.Invoke(ammoCount);
        }

        private void OnEnable()
        {
            GetControls.OnShootClick += ThrowProjectile;
        }

        private void OnDisable()
        {
            GetControls.OnShootClick -= ThrowProjectile;
        }

        void Start()
        {
            mainCamera = Camera.main;
            hitMarker = Instantiate(hitMarkerPrefab);
        }

        public void RefillAmmo()
        {
            ammoCount = AppConstants.MAX_AMMO;
            OnBallonThrow?.Invoke(ammoCount);
        }
        
        private void Update()
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                ThrowProjectile();
            }

            // shoot a ray from the camera in the forward direction
            Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);

            // perform a raycast
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, rayDistance))
            {
                // if an object is hit, print a message and draw a line to the hit point
                //CustomLog.Log("Hit object: " + hit.transform.name + "\tAt point: " + hit.point);
                Debug.DrawLine(ray.origin, hit.point, Color.red, 2f, false);
                hitMarker.transform.position = hit.point;
            }
        }

        void ThrowProjectile()
        {
            if (ammoCount <= 0)
            {
                CustomLog.Log("Out of ammo.");
                OnBallonThrow?.Invoke(ammoCount);
                return;
            }

            CustomLog.Log("Throw Projectile...");
            ammoCount--;
            OnBallonThrow?.Invoke(ammoCount);
            if(ammoCount == 0)
            {
                UiManager.Instance.ShowGameOver();
            }

            Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, rayDistance))
            {
                GameObject projectile = Instantiate(projectilePrefab, throwFrom.position, Quaternion.identity);
                Vector3 targetPosition = hit.point;
                Vector3 direction = (targetPosition - throwFrom.position).normalized;
                float distance = Vector3.Distance(throwFrom.position, targetPosition);
                float velocity = CalculateVelocity(distance);
                projectile.GetComponent<Rigidbody>().velocity = direction * velocity;
            }
        }

        float CalculateVelocity(float distance)
        {
            float gravity = Physics.gravity.magnitude * gravityMultiplier;
            float angle = 45f; // 45 degrees
            float velocity = distance / (Mathf.Sin(2f * angle * Mathf.Deg2Rad) / gravity);
            return velocity;
        }
    }
}