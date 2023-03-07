using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ballPhysics : MonoBehaviour
{
    private GameObject Player;
    private Rigidbody2D body;
    private GameObject game;
    private bool hasScored; //flag to stop adding goals (since goalScored() is called in update)
    public float goalBoundaryLeft;
    public float goalBoundaryRight;
    public float goalBoundaryTop;
    public float goalBoundaryBottom;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        game = GameObject.FindGameObjectWithTag("GameManager");
        Player = GameObject.FindGameObjectWithTag("Player");
        hasScored = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Player.GetComponent<PlayerActions>().hasKicked && body.velocity.y <= 0)
        {
            body.constraints = RigidbodyConstraints2D.FreezePositionX;
            body.constraints = RigidbodyConstraints2D.FreezePositionY;
            
            Vector2 ballPos = transform.position;

            //if the ball is in and they havent just scored 
            if ((ballPos.x >= goalBoundaryLeft && ballPos.x <= goalBoundaryRight) &&
                (ballPos.y >= goalBoundaryBottom && ballPos.y <= goalBoundaryTop) && !hasScored)
            {
                Debug.Log("GOAL SCORED!");
                game.GetComponent<GameManager>().goalScored();
                hasScored = true;
            } 
        }
        
    }
}
 