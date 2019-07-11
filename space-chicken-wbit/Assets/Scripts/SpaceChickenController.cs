using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceChickenController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private bool isOver = false;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (isOver == false)
        {
        float moveHorizontal = Input.GetAxis ("Horizontal") * GameControl.instance.CharacterSpeed * Time.deltaTime;
        float moveVertical = Input.GetAxis ("Vertical") * GameControl.instance.CharacterSpeed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x + moveHorizontal, transform.position.y + moveVertical);
        }
    }
}
