using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Vector3 startPos;
    private readonly float thrust = 350.0f;
    private readonly float speedupFac = 0.04f;
    private readonly float maxSpeed = 600f;

    public void startBall()
    {
        gameObject.SetActive(true);
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        Vector2 vec2 = new Vector2(Random.Range(-0.5f, 0.5f), -1);
        rb2D.AddForce(vec2 * thrust);
    }


    public void stopBall()
    {
        // set velocity to zero
        rb2D.velocity = new Vector2(0, 0);
        transform.position = startPos;
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // increase the velocity of the ball with each touch
        if (rb2D.velocity.SqrMagnitude() <= maxSpeed)
            rb2D.velocity *= (1 + speedupFac);

        // Destroy Blocks on collision
        if (collision.gameObject.name == "Block")
            Destroy(collision.gameObject);

        if (collision.gameObject.name == "BottomCollider")
            transform.parent.GetComponent<GameLogicManager>().handleBallCollidesBottom();

    }

    // Update is called once per frame
    void Update()
    {
    }
}
