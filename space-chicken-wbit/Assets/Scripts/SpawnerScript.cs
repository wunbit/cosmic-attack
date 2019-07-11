using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    //public GameObject savesInstance;
    public GameObject asteroidInstance;

    // Start is called before the first frame update
    void Start()
    {
         StartSpawning();
    }
    public void StartSpawning()
    {
        InvokeRepeating("spawnAsteroid", GameControl.instance.asteroid_initialDelay, GameControl.instance.asteroid_repeatDelay);
    }
    public void StopSpawning()
    {
        CancelInvoke();
    }
    /*void spawnSave()
    {
        Instantiate(savesInstance, transform.position, Quaternion.identity);
    } */
    void spawnAsteroid()
    {
        Instantiate(asteroidInstance, transform.position, Quaternion.identity);
    }
}
