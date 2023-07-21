using Assets.Scripts.Flappy;
using Assets.Scripts.Flappy.StatePattern;
using UnityEngine;

public class CatMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private float jumpForce = 6f;
    private bool start;
    public GameObject obstacleGenerate;
    [SerializeField]
    GameObject gameOverMenu;


    public bool isDead = false;
    private PlayerBaseState currentState;
    public Animator animator;
    Timer timer;
    private bool endGameCalled = false;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        start = false;
        rigidbody2D.gravityScale = 0;

        timer = gameObject.AddComponent<Timer>();
        animator = gameObject.GetComponent<Animator>();
        currentState = new FlyState(this);
        currentState.EnterState();

    }
    public void LoadPlayer(Cat cat)
    {
        gameObject.transform.position = new Vector2(cat.xPlayer, cat.yPlayer);
    }
    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState();
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

        if (timer.Finished && !endGameCalled)
        {
            endGameCalled = true;
            EndGame();
        }
    }

    private void EndGame()
    {
        Debug.Log("Auu");
        gameOverMenu.SetActive(true);

        HUD hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        float score = hud.GetPoints();
        PlayerPrefs.SetString("Score", score.ToString());
        Time.timeScale = 0;


        AudioManager.Play(AudioClipName.Die);
    }

    public void ChangeState(PlayerBaseState newState)
    {
        currentState.ExitState();
        currentState = newState;
        currentState.EnterState();
    }


    private void BirdJump()
    {
        rigidbody2D.velocity = Vector3.up * jumpForce;
        AudioManager.Play(AudioClipName.Fly);
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle")
            || collision.gameObject.CompareTag("down")
            || collision.gameObject.CompareTag("up"))
        {
            isDead = true;
            timer.Duration = 0.5f;
            timer.Run();

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
