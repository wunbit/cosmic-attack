using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    //public GameObject savesInstance;
    public GameObject asteroidInstance;
    public GameObject AmmoInstance;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("GameControl") == null)
        {
            StartSpawning();
        }
    }
    public void StartSpawning()
    {
        InvokeRepeating("spawnAmmo", GameControl.instance.AmmoInitialDelay, Random.Range(GameControl.instance.AmmoMinRepeat, GameControl.instance.AmmoMaxRepeat));
        InvokeRepeating("spawnAsteroid", GameControl.instance.asteroid_initialDelay, Random.Range(GameControl.instance.asteroidMinRepeat, GameControl.instance.asteroidMaxRepeat));
    }
    public void StopSpawning()
    {
        CancelInvoke();
    }
    void spawnAmmo()
    {
        Instantiate(AmmoInstance, transform.position, Quaternion.identity);
    }
    void spawnAsteroid()
    {
        Instantiate(asteroidInstance, transform.position, Quaternion.identity);
    }
}
