using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public bool hasKicked;
    public float shotPower;
    public float shotAngleModifierX;
    public float shotAngleModifierY;
    public float minPowerY;
    private Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        hasKicked = false;
        playerAnim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!hasKicked && Input.GetMouseButtonDown(0))
        {
            kick();
        }

        
    }

    void kick()
    {
        hasKicked = true;
        
        //set animation
        playerAnim.SetBool("animShot", true);

        GameObject ball = GameObject.FindGameObjectWithTag("Ball");

        Vector2 footContactPos = GameObject.FindGameObjectWithTag("FootContact").transform.position;

        Vector2 ballPos = ball.transform.position;

        Vector2 ballFootDiff = ballPos - footContactPos;

        Vector2 finalVector = new Vector2(ballFootDiff.x - shotAngleModifierX, Mathf.Clamp(ballFootDiff.y - shotAngleModifierY, minPowerY/shotPower, ballFootDiff.y - shotAngleModifierY));

        ball.GetComponent<Rigidbody2D>().velocity = finalVector * shotPower;

    }
}
