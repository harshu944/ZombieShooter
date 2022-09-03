using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    private Rigidbody2D myBody;
    private float moveForce_X = 5f, moveForce_Y = 5f;

    private bool moveLeft;
    private bool moveRight;
    private bool moveup;
    private bool movedown;



    private PlayerAnimations playerAnimation;



    void start()
    {
        moveLeft = false;
        moveRight = false;
        moveup = false;
        movedown = false;
    }
	void Awake () {
        myBody = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<PlayerAnimations>();
	}

	void FixedUpdate () {
        Move();
	}




    public void PointerDownLeft()
    {

        moveLeft = true;
    }

    public void PointerUpLeft()
    {
        moveLeft = false;
    }

    public void PointerDownRight()
    {

        moveRight = true;
    }

    public void PointerUpRight()
    {
        moveRight = false;
    }





    public void PointerDownnegativey()
    {

        movedown = true;
    }

    public void PointerUppnegativey()
    {
        movedown = false;
    }



    public void PointerDownpostivey()
    {

        moveup = true;
    }

    public void PointerUppositivey()
    {
        moveup = false;
    }











    void Move()
    {

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (moveRight)
        {
            myBody.velocity = new Vector2(moveForce_X, myBody.velocity.y);

        }
        else if (moveLeft)
        {
            myBody.velocity = new Vector2(-moveForce_X, myBody.velocity.y);

        }
        else
        {
            myBody.velocity = new Vector2(0f, myBody.velocity.y);
        }

        if (moveup)
        {
            myBody.velocity = new Vector2(myBody.velocity.x, moveForce_Y);

        }
        else if (movedown)
        {
            myBody.velocity = new Vector2(myBody.velocity.x, -moveForce_Y);

        }
        else
        {
            myBody.velocity = new Vector2(myBody.velocity.x, 0f);
        }

        // ANIMATE
        if(myBody.velocity.x != 0 || myBody.velocity.y != 0) {
            playerAnimation.PlayerRunAnimation(true);

        } else if(myBody.velocity.x == 0 && myBody.velocity.y == 0) {
            playerAnimation.PlayerRunAnimation(false);
        }

        Vector3 tempScale = transform.localScale;

        if (moveRight) {
            tempScale.x = -1f;

        } else if (moveLeft) {
            tempScale.x = 1f;

        }

        transform.localScale = tempScale;

    }
   

} // class










































