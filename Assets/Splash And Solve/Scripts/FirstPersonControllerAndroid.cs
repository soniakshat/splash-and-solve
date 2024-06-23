using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FirstPersonControllerAndroid : MonoBehaviour
{
    private GameObject gameOverCanvas;
    private GameObject playerControlCanvas;
    private float gravity = 10;
    private bool _collisionEntered = false;

    private Transform cameraTransform;
    private CharacterController characterController;

    // Player settings
    [SerializeField] private float moveSpeed = 500;
    [SerializeField] private float moveInputDeadZone=15;
    private float cameraSensitivity = 50.0f;
    private float originalMovespeed;
    Vector2 movementDirection;

    // Touch detection
    private int leftFingerId, rightFingerId;
    private float halfScreenWidth;

    // Camera control
    private Vector2 lookInput;
    private float lookXLimit = 45.0f;
    private float cameraPitch;

    // Player movement
    private Vector2 moveTouchStartPosition;
    private Vector2 moveInput;

    private bool isRunning = false;
    private Toggle isRunningToggle;
    private Button shootButton;

    private void Awake()
    {
        characterController = this.GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;
        playerControlCanvas = GameObject.FindGameObjectWithTag("ControlCanvas");
        gameOverCanvas = GameObject.FindGameObjectWithTag("GameOverCanvas");
        gameOverCanvas.SetActive(false);
        isRunningToggle = playerControlCanvas.GetComponent<GetControls>().GetRunningToggle();
        shootButton = playerControlCanvas.GetComponent<GetControls>().GetShootButton();
    }
    // Start is called before the first frame update
    void Start()
    {
        cameraSensitivity = PlayerPrefs.GetInt("CameraSensitivity", 50);
        // print("Camera Sensitivity: " + cameraSensitivity);

        originalMovespeed = moveSpeed;
        // id = -1 means the finger is not being tracked
        leftFingerId = -1;
        rightFingerId = -1;

        // only calculate once
        halfScreenWidth = Screen.width / 2;

        // calculate the movement input dead zone
        moveInputDeadZone = Mathf.Pow(Screen.height / moveInputDeadZone, 2);
    }


    // Update is called once per frame
    void Update()
    {
        // Handles input
        GetTouchInput();

        // Check if is running
        isRunning = isRunningToggle.isOn;
        //if (isRunning)
        //{
        //    isRunningToggle.GetComponentInChildren<Text>().text = $"RunningSpeed: {moveSpeed}";
        //    print($"RunningSpeed: {moveSpeed}");
        //}
        //else
        //{
        //    isRunningToggle.GetComponentInChildren<Text>().text = $"WalkingSpeed: {moveSpeed}";
        //    print($"WalkingSpeed: {moveSpeed}");
        //}
    }

    private void FixedUpdate()
    {
        // Move According to Inputs
        if (rightFingerId != -1)
        {
            // Ony look around if the right finger is being tracked
            // Debug.Log("Rotating");
            LookAround();
        }
        if (leftFingerId != -1)
        {
            // Ony move if the left finger is being tracked
            // Debug.Log("Moving");
            Move();
        }
    }

    void GetTouchInput()
    {
        // Iterate through all the detected touches
        for (int i = 0; i < Input.touchCount; i++)
        {

            Touch t = Input.GetTouch(i);

            // Check each touch's phase
            switch (t.phase)
            {
                case TouchPhase.Began:

                    if (t.position.x < halfScreenWidth && leftFingerId == -1)
                    {
                        // Start tracking the left finger if it was not previously being tracked
                        leftFingerId = t.fingerId;

                        // Set the start position for the movement control finger
                        moveTouchStartPosition = t.position;
                    }
                    else if (t.position.x > halfScreenWidth && rightFingerId == -1)
                    {
                        // Start tracking the rightfinger if it was not previously being tracked
                        rightFingerId = t.fingerId;
                    }

                    break;
                case TouchPhase.Ended:
                case TouchPhase.Canceled:

                    if (t.fingerId == leftFingerId)
                    {
                        // Stop tracking the left finger
                        leftFingerId = -1;
                        // Debug.Log("Stopped tracking left finger");
                    }
                    else if (t.fingerId == rightFingerId)
                    {
                        // Stop tracking the right finger
                        rightFingerId = -1;
                        // Debug.Log("Stopped tracking right finger");
                    }

                    break;
                case TouchPhase.Moved:

                    // Get input for looking around
                    if (t.fingerId == rightFingerId)
                    {
                        lookInput = t.deltaPosition * cameraSensitivity * Time.deltaTime;
                    }
                    else if (t.fingerId == leftFingerId)
                    {

                        // calculating the position delta from the start position
                        moveInput = t.position - moveTouchStartPosition;
                    }

                    break;
                case TouchPhase.Stationary:
                    // Set the look input to zero if the finger is still
                    if (t.fingerId == rightFingerId)
                    {
                        lookInput = Vector2.zero;
                    }
                    break;
            }
        }
    }

    void LookAround()
    {
        // vertical (pitch) rotation
        cameraPitch = Mathf.Clamp(cameraPitch - lookInput.y, -lookXLimit, lookXLimit);
        cameraTransform.localRotation = Quaternion.Euler(cameraPitch, 0, 0);

        // horizontal (yaw) rotation
        transform.Rotate(transform.up, lookInput.x);
    }

    void Move()
    {
        Run();
        // Don't move if the touch delta is shorter than the designated dead zone
        if (moveInput.sqrMagnitude <= moveInputDeadZone) return;

        // Multiply the normalized direction by the speed
        movementDirection = moveInput.normalized * moveSpeed * Time.deltaTime;
        Vector3 _3DMovement = new Vector3(movementDirection.x, movementDirection.y, 50f);
        // Move relatively to the local transform's direction
        //characterController.SimpleMove(transform.right * movementDirection.x + transform.forward * movementDirection.y);
        characterController.SimpleMove(transform.right * _3DMovement.x + transform.forward * _3DMovement.y);
    }

    public void Run()
    {
        if (isRunningToggle.isOn)
        {
            moveSpeed = originalMovespeed + 200;
        }
        else
        {
            moveSpeed = originalMovespeed;
        }
    }
   
    private void OnCollisionExit(Collision other)
    {
        _collisionEntered = false;
    }
  
    private IEnumerator CoroutineYouLoseAudioPlayer()
    {
        gameOverCanvas.SetActive(true);
        playerControlCanvas.SetActive(false);
        
        yield return new WaitForSeconds(1);

        // UnLock cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        StartCoroutine(CoroutinePlayerDies());
    }

    //[SerializeField] private GameObject _explosionParticleSystem;

    private IEnumerator CoroutinePlayerDies()
    {
        this.gameObject.SetActive(false);
        //Instantiate(_explosionParticleSystem, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0);
    }
}