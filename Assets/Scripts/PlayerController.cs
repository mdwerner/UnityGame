using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;

    private Rigidbody2D player;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool movingLeft;
    private bool movingRight;

    private void Start(){
        player = GetComponent<Rigidbody2D> ();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        movingRight = true;
        movingLeft = false;
    }//end Start() 


    private void FixedUpdate(){
        Vector3 orig_pos = this.transform.position;
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        if( moveHorizontal == 0 && moveVertical == 0)
        {
            animator.SetFloat("Speed", 0);
            return;
        }//end if

        float h_speed = moveHorizontal * speed;
        float v_speed = moveVertical * speed;

        float newX = orig_pos.x + h_speed;
        float newY = orig_pos.y + v_speed;

        animator.SetFloat("Speed", Mathf.Abs(h_speed));
        Debug.Log("Setting animator Speed to = " + h_speed);


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
