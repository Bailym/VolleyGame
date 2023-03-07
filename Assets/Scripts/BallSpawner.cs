using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    private Rigidbody2D body;
    public GameObject ball;
    public float minForceX;
    public float maxForceX;
    public float minForceY;
    public float maxForceY;
    private GameObject game;
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        game = GameObject.FindGameObjectWithTag("GameManager");
        Player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(NextBall());

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator NextBall()
    {
        if (game.GetComponent<GameManager>().ballsLeft>=0)
        {
            //destroy any leftover balls
            GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");

            if (balls.Length > 0)
            {
                for (int i = 0; i < balls.Length; i++)
                {
                    Destroy(balls[i]);
                }
            }

            //reset hasKicked before spawning the next ball
            Player.GetComponent<PlayerActions>().hasKicked = false;

            //min and max forces for ball trajectory
            float randX = Random.Range(minForceX, maxForceX);
            float randY = Random.Range(minForceY, maxForceY);

            //combined vector
            Vector2 ballDirection = new Vector2(randX, randY);

            //create a new ball 
            GameObject newBall = Instantiate(ball, gameObject.transform);

            //apply the vector
            newBall.GetComponent<Rigidbody2D>().velocity = ballDirection;

            //game manager function 
            game.GetComponent<GameManager>().shotTaken();

            yield return new WaitForSeconds(5);

            StartCoroutine(NextBall());
        }
    }
}
