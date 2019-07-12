using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
   	public bool relativeToRotation = false;
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
}
