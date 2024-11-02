using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    AudioManager audioManager;
    public Sprite[] wingSprites;
    private SpriteRenderer wingSpriteRenderer;
    private int currentSpriteIndex = 0;
    private float spriteChangeDuration = 0.5f;
    private float timer = 0f;
    private bool isSpriteChanged = false;
    private Sprite originalWingSprite;


    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        wingSpriteRenderer = transform.Find("Wing").GetComponent<SpriteRenderer>();
        originalWingSprite = wingSprites[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive)
        {
            rb.velocity = Vector2.up * flapStrength;
            audioManager.PlaySFX(audioManager.flap);
            ChangeWingSprite();

        }
        if ((transform.position.y > 16 || transform.position.y < -16) && birdIsAlive)
        {
            leaveScreen(birdIsAlive);
        }

        RotateBird();
        HandleSpriteTimer();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        death();
    }

    private void leaveScreen(bool birdIsAlive)
    {
        death();
    }

    private void death()
    {
        if (birdIsAlive)
        {
            birdIsAlive = false;
            logic.gameOver();
        }
    }

    void RotateBird()
    {
        float angle = Mathf.Atan2(rb.velocity.y, 10) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void ChangeWingSprite()
    {
        currentSpriteIndex = (currentSpriteIndex + 1) % wingSprites.Length;

        wingSpriteRenderer.sprite = wingSprites[currentSpriteIndex];

        timer = spriteChangeDuration;
        isSpriteChanged = true;
    }

    void HandleSpriteTimer()
    {
        if (isSpriteChanged)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                wingSpriteRenderer.sprite = originalWingSprite;
                isSpriteChanged = false;
            }
        }
    }
}
