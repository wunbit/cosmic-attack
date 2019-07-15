using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossScript : MonoBehaviour
{
    public GameObject bomb;
    public float initialDelay;
    public float repeatDelay;
    public GameObject BoomLittle;
    public GameObject BoomBig;
    public GameObject HealthBar;
    private GameObject[] BadGuys;
    public GameObject SpawnerScript;
    public GameObject GameControl;
    public AudioClip bossHit;
    public AudioClip bossDestroyed;
    public AudioClip winMusic;

    void OnEnable()
    {
        SpawnerScript = GameObject.Find("SpawnerScript");
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
                    AudioSource.PlayClipAtPoint(winMusic, new Vector3(0, 0, 0));
                }
                Instantiate(BoomBig, this.transform.position, Quaternion.identity);
                DestroyBadGuys();
                EndInvoke();
                //Time.timeScale = 0.0f;
                if(GameControl)
                {
                    GameControl.GetComponent<GameControl>().WinCard.SetActive(true);
                }
                if (SpawnerScript)
                {
                    SpawnerScript.GetComponent<SpawnerScript>().StopSpawning();
                }
                gameObject.SetActive(false);
                EndInvoke();
                print("BOSS GONE!");
            }
        }
    }

    void DestroyBadGuys()
    {
        print("Destroybadguys is at start");
        BadGuys = GameObject.FindGameObjectsWithTag("Enemy");
        print("Badguys lenght is " + BadGuys.Length);
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
