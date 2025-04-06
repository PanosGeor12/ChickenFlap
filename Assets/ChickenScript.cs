using UnityEngine;

public class ChickenScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength = 10;
    public bool isBirdAlive = false;

    public Sprite initialSprite;
    public Sprite jumpingSprite;
    public SpriteRenderer currentSprite;

    public AudioSource chickenPluck;

    public LogicScript logic;
    private bool isJumping = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentSprite.sprite = initialSprite;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isBirdAlive)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                myRigidBody.linearVelocity = Vector2.up * flapStrength;
                chickenPluck.Play();
                isJumping = true;
            }

            if (isJumping)
            {
                currentSprite.sprite = jumpingSprite;
                isJumping = false;
            }
            else
            {
                currentSprite.sprite = initialSprite;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        isBirdAlive = false;
    }
}
