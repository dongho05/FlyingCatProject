using UnityEngine;

public class CatMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private float jumpForce = 6f;
    private bool start;
    public GameObject obstacleGenerate;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        start = false;
        rigidbody2D.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!start)
            {
                start = true;
                rigidbody2D.gravityScale = 1.5f;
                obstacleGenerate.GetComponent<ObstacleGenerate>().enable = true;
            }
            BirdJump();
        }
    }

    private void BirdJump()
    {
        rigidbody2D.velocity = Vector3.up * jumpForce;
        AudioManager.Play(AudioClipName.Fly);
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Auu");
            Time.timeScale = 0;
            AudioManager.Play(AudioClipName.Die);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("point"))
        {
            AudioManager.Play(AudioClipName.point);
            HUD hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
            hud.AddPoints(1);
            Debug.Log("+1");
        }
    }
}
