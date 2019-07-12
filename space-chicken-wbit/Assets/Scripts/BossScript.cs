/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
     public GameObject bomb;
    public float initialDelay;
    public float repeatDelay;
    public GameObject BoomLittle;
    public GameObject BoomBig;
    public GameObject HealthBar;
    private GameObject[] BadGuys;
    public GameObject spawner;
    public GameObject GameManager;
    public AudioClip bossHit;
    public AudioClip bossDestroyed;

    void OnEnable()
    {
        spawner = GameObject.Find("Spawner");
        BeginInvoke();
        HealthBar.SetActive(true);
    }

    void spawnBomb()
    {
        Instantiate(bomb, transform.position, Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Laser")
        {
            if (bossHit)
            {
                AudioSource.PlayClipAtPoint(bossHit, new Vector3(0, 0, 0));
            }
            HealthBarScript.health -= 20f;
            Instantiate(BoomLittle, this.transform.position, Quaternion.identity);
            col.gameObject.SetActive(false);
            

            if (HealthBarScript.health <= 0)
            {
                if (bossDestroyed)
                {
                    AudioSource.PlayClipAtPoint(bossDestroyed, new Vector3(0, 0, 0));
                }
                Instantiate(BoomBig, this.transform.position, Quaternion.identity);
                EndInvoke();
                //Time.timeScale = 0.0f;
                DestroyBadGuys();
                if(GameManager)
                {
                    GameManager.GetComponent<GameManager>().WinCard.SetActive(true);
                }
                if (spawner)
                {
                    spawner.GetComponent<Spawner>().StopSpawning();
                }
                gameObject.SetActive(false);
                print("BOSS GONE!");
            }
        }
        
    }

    void DestroyBadGuys()
    {
        BadGuys = GameObject.FindGameObjectsWithTag("Enemy");

        for (var i = 0; i < BadGuys.Length; i++)
        {
            Destroy(BadGuys[i]);
        }
    }

        public void BeginInvoke()
    {
        InvokeRepeating("spawnBomb", initialDelay, repeatDelay);
    }

    public void EndInvoke()
    {
        CancelInvoke();
    }
}
 */