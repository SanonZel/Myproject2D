using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    private const float Jump_Speed = 10.0f;
    private const float MovementSpeed = 3.0f;
    private const float FallTime = 1.3f;

    private float CurrentTimeFall = 0.0f;

    [SerializeField] private ScoreManager scoreManager;

    private Rigidbody2D PlayerRb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Batuts batuts = collision.gameObject.GetComponent<Batuts>();
        if (batuts != null)
        {
            DoJump();
            if (batuts.isPassed == false)
            {

                batuts.GetComponent<SpriteRenderer>().color = Color.red;
                scoreManager.OnAddScore();
                batuts.IsPlatformTrigger();
            }
        }
    }

    private void Start()
    {
        PlayerRb = GetComponent<Rigidbody2D>();
        InitCamera();
    }

    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        transform.Translate(new Vector2(hor, 0f) * MovementSpeed * Time.deltaTime);
        CurrentTimeFall += Time.deltaTime;

    }
    private void InitCamera()
    {
        CameraPlease cameraPlease = Camera.main.GetComponent<CameraPlease>();
        if (cameraPlease != null)
            cameraPlease.SetTarget(transform);
    }

    private void DoJump()
    {
        PlayerRb.velocity = Vector2.zero;
        float hor = PlayerRb.velocity.x;
        CurrentTimeFall = Mathf.Clamp(CurrentTimeFall, 0.0f, FallTime);
        float vert = Jump_Speed * CurrentTimeFall / FallTime;
        PlayerRb.velocity = new Vector2(hor, vert);
        CurrentTimeFall = 0.0f;
    }

}
