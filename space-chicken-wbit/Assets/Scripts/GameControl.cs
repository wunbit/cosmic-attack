using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    
    [Header("Game Variables")]
    public bool noboss = true;
    public float BGScrollSpeed = -2f;
    public float CharacterSpeed = 5;
    public float AmmoInitialDelay;
    public float AmmoMinRepeat;
    public float AmmoMaxRepeat;
    public float asteroid_initialDelay;
    public float asteroidMinRepeat;
    public float asteroidMaxRepeat;
    public Vector2 AsteroidDirection = new Vector2(1f, 0f);
    public Vector2 PowerupDirection = new Vector2(0f, 5f);

    [Header("Script References")]
    public SpawnerScript spawner;
    public GameObject welcomeCard;
    public GameObject instructionsCard;
    public GameObject gameOverCard;
    public GameObject WinCard;
    public SpaceChickenScript spaceChicken;
    public GameObject HealthBar;
    public GameObject boss;
    public GameObject gameover;
    public GameObject ChickenBoom;
    public Text scoreText;
    AudioSource source;
    public AudioClip bgMusic;
    public AudioClip playerHit;
    public AudioClip pickupSound;
    public static GameControl instance;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        source = GetComponent<AudioSource>();source = GetComponent<AudioSource>();
        StartGame();
    }

private void StartGame()
    {
        spaceChicken.ResetScore();
        //turn on the chicken!
        gameOverCard.SetActive(false);
        instructionsCard.SetActive(false);
        welcomeCard.SetActive(true);
        if (bgMusic)
        {
            source.PlayOneShot(bgMusic, 1f);
        }
        if (WinCard != null)
        {
            WinCard.SetActive(false);
        }
        boss.SetActive(false);
        noboss = true;
        if(HealthBar)
        {
            HealthBar.SetActive(false);
        }
    }

    public void OnWelcomeCardClick()
    {
        welcomeCard.SetActive(false);
        instructionsCard.SetActive(true);
    }

    public void OnInstructionCardClick()
    {
        instructionsCard.SetActive(false);
        spaceChicken.gameObject.SetActive(true);
        spawner.StartSpawning();
    }

    public void OnGameOverCardClick()
    {
        //source.Stop();
        StartGame();
    }

    public void WinCardClick()
    {
        StartGame();
    }

    public void PlayerIsHit()
    {
        spawner.StopSpawning();
        gameOverCard.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
