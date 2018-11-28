using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;

    private Rigidbody2D player;
    private SpriteRenderer spriteRenderer;
    private bool movingLeft;
    private bool movingRight;

    private void Start(){
        player = GetComponent<Rigidbody2D> ();
        spriteRenderer = GetComponent<SpriteRenderer>();
        movingRight = true;
        movingLeft = false;
    }//end Start() 


    private void FixedUpdate(){
        Vector3 orig_pos = this.transform.position;
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        float newX = orig_pos.x + moveHorizontal * speed;
        float newY = orig_pos.y + moveVertical * speed;

        player.MovePosition(new Vector2(newX, newY));
                   
        if( movingRight && moveHorizontal < 0 ){
            movingLeft = true;
            movingRight = false;
            this.spriteRenderer.flipX = !this.spriteRenderer.flipX;
            //Debug.Log("Flipping Image From Right to Left.");
        }else if ( movingLeft && moveHorizontal > 0 ){
            movingRight = true;
            movingLeft = false;
            this.spriteRenderer.flipX = !this.spriteRenderer.flipX;
            //Debug.Log("Flipping Image From Left to Right.");
        }//end if-else
    }//end FixedUpdate()

}//end PlayerController class
