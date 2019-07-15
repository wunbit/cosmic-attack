using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpaceChickenScript : MonoBehaviour
{
    public int score;
    public GameObject boss;
    public GameObject ChickenBoom;
    public GameObject spline;
    //When we hit any object that has a 2D collider...)
    void OnTriggerEnter2D(Collider2D coll)
    {
        //If the object we collided with has a tag of "Enemy")
        if (coll.gameObject.tag == "Enemy")
        {
            if (GameControl.instance.playerHit)
            {
                AudioSource.PlayClipAtPoint(GameControl.instance.playerHit, new Vector3(0, 0, 0));
            }
            print("You hit an enemy!");
            GameControl.instance.PlayerIsHit();
            if (ChickenBoom != null)
                {
                    Instantiate(ChickenBoom, this.transform.position, Quaternion.identity);
                }
            gameObject.SetActive(false);
        }
        //If the object we collided with has a tag of "Pickup")
        if (coll.gameObject.tag == "Pickup")
        {
            if (GameControl.instance.pickupSound)
            {
                AudioSource.PlayClipAtPoint(GameControl.instance.pickupSound, new Vector3(0, 0, 0));
            }
            //print only shows in the Console window, helpful to see if that section of code is running
            print("You picked up ammo!");
            //the object we collided with, make it inactive
            coll.gameObject.SetActive(false);
            //Add a point to our score
            score++;
            //Update the GUI text
            GameControl.instance.scoreText.text = "Score: " + score;
           // If score is greater or equal to 3, and there isn't already a boss...)
           if (score >= 3 && GameControl.instance.noboss == true)
            {
                //Activate the boss
               boss.SetActive(true);
               spline.SetActive(true);
                //change noboss off so another boss isn't created
               GameControl.instance.noboss = false;
             }
        }

    }

    //this function runs when a game starts to set score back to 0.
    public void ResetScore()
    {
        score = 0;
        GameControl.instance.scoreText.text = "Score: " + score.ToString();
    }

    //Run this function whenever the score goes up or down to update GUI text
    public void UpdateScore()
    {
        GameControl.instance.scoreText.text = "Score: " + score;
    }
}
