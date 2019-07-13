using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
   	public bool relativeToRotation = false;
    public GameObject boom;
    public AudioClip boomAsteroidSoud;
    private Rigidbody2D rb2d;

    void Start ()
    {
    rb2d = GetComponent<Rigidbody2D> ();
    }

	// Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, 25) * Time.deltaTime);
        if(relativeToRotation)
		{
			rb2d.AddRelativeForce(GameControl.instance.AsteroidDirection * 2f);
		}
		else
		{
			rb2d.AddForce(GameControl.instance.AsteroidDirection * 2f);
		}
    }
     void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Laser")
        {
            Instantiate(boom, this.transform.position, Quaternion.identity);
            if(boomAsteroidSoud)
            {
                AudioSource.PlayClipAtPoint(boomAsteroidSoud, new Vector3(0, 0, 0));
            }

            coll.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
