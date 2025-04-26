using System.Collections;
using UnityEngine;

public class Clickonperson : MonoBehaviour
{
    public SpawnAndDespawn spawnAndDespawn;
    private GameManagercounter gameManager;
    private BoxCollider2D boxCollider;

    public float rotationSpeed = 100f;
    public float rotation = -90f;
    private bool isRotating = false;
    public bool destroy = false;
    public ParticleSystem destroyParticles;
    public bool isArrow = false;
    public float despawnTime = .5f;

    public AudioClip clickSound; // AudioClip instead of AudioSource

    void Start()
    {
        gameManager = FindObjectOfType<GameManagercounter>();
        boxCollider = GetComponent<BoxCollider2D>();

        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene");
        }

        if (boxCollider == null)
        {
            Debug.LogError("This object does not have a BoxCollider2D");
        }

        destroyParticles.Stop();
    }

    void OnMouseDown()
    {
        // Play click sound using AudioManager
        if (clickSound != null)
        {
            AudioManager.instance.PlaySFX(clickSound);
        }

        if (gameManager != null && boxCollider != null && !destroy)
        {
            gameManager.IncrementClickCount();
            RotateToTargetAngle();
            boxCollider.enabled = false;
        }

        if (gameManager != null && boxCollider != null && destroy && !isArrow)
        {
            gameManager.IncrementClickCount();
            destroyParticles.Play();
            Destroy(gameObject);
        }
    }

    void RotateToTargetAngle()
    {
        isRotating = true;
    }

    void Update()
    {
        if (isRotating)
        {
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, rotation, rotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0f, 0f, angle);

            if (Mathf.Approximately(angle, rotation))
            {
                isRotating = false;
            }
        }
    }
}
