using System;
using UnityEngine;
using UnityEngine.InputSystem;

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
        if (isBirdAlive && Time.timeScale == 1)
        {
            if (InputSystem.actions.FindAction("Jump").IsPressed() || InputSystem.actions.FindAction("Click").IsPressed())
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

        if (InputSystem.actions.FindAction("Cancel").IsPressed())
        {
            logic.pauseGame();
            logic.exitGameScreen.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        isBirdAlive = false;
    }
}
