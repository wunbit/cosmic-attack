using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public float BGScrollSpeed = -2f;
    public float CharacterSpeed = 5;
    //public float savesInitialDelay;
    //public float savesRepeatDelay;
    public float asteroid_initialDelay;
    public float asteroid_repeatDelay;

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
