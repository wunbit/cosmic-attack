using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonShootLaser : MonoBehaviour
{
    public GameObject laser;
    private SpaceChickenScript Score;
    public GameObject chicken;
    public AudioClip shootLaser;

    void Awake()
    {
        Score = chicken.GetComponent<SpaceChickenScript>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShootLaser();
        }
    }
    public void ShootLaser()
    {
        if (Score.score > 0)
        {
            Instantiate(laser, chicken.transform.position, Quaternion.identity);
            //if the AudioClip shootLaser is assigned, play it.
            if (shootLaser)
            {
                AudioSource.PlayClipAtPoint(shootLaser, new Vector3(0, 0, 0));
            }
            print("make laser");
            Score.score  -= 1;
            Score.UpdateScore();
        }
    }
}
