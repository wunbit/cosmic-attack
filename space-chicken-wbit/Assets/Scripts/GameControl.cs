using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
