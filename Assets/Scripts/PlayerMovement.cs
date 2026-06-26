using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float baseSpeed = 6f;
    public float speedIncreasePerMeter = 0.05f; 
    public float maxSpeed = 15f; 

    public float playerSpeed; 

    public float horizontalSpeed = 3;
    public float rightLimit = 5.5f;
    public float leftLimit = -5.5f;

    public float jumpForce = 7f;
    public float groundCheckDistance = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;

    [SerializeField] bool isRunning;

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
       if (GameOverManager.isGameOver) return;
       
        playerSpeed = Mathf.Min(baseSpeed + (MasterInfo.distanceRun * speedIncreasePerMeter), maxSpeed);

        if (isRunning == false)
        {
            isRunning = true;
            StartCoroutine(AddDistance());
        }

        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.World);

        if (Input.GetKey(KeyCode.A))
        {
            if (transform.position.x > leftLimit)
                transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed, Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (transform.position.x < rightLimit)
                transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed, Space.World);
        }

        Debug.DrawRay(groundCheck.position, Vector3.down * groundCheckDistance, Color.red);
        isGrounded = Physics.Raycast(groundCheck.position, Vector3.down, groundCheckDistance, groundLayer);

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && isGrounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
        }
    }

    IEnumerator AddDistance()
    {
        yield return new WaitForSeconds(0.65f);
        MasterInfo.AddDistance(1f);
        isRunning = false;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger detectado con: " + other.gameObject.name + " - Tag: " + other.tag);

        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("Es un obstáculo, llamando Game Over");
            GameOverManager.TriggerGameOver();
        }
    }
}