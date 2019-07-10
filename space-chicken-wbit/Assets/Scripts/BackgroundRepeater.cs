using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeater : MonoBehaviour
{
    private float groundHorizonHeight;
    private Rigidbody2D rb2dbground;

    // Start is called before the first frame update
    void Start()
    {
        groundHorizonHeight = GetComponent<SpriteRenderer>().size.y;
        rb2dbground = GetComponent<Rigidbody2D> ();
        rb2dbground.velocity = new Vector2(0, GameControl.instance.scrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -groundHorizonHeight) 
        {
            RepositionBackground ();
        }
    }
    private void RepositionBackground()
    {
        Vector2 groundOffset = new Vector2 (0, groundHorizonHeight * 1.9f);
        transform.position = (Vector2) transform.position + groundOffset;
    }
}
