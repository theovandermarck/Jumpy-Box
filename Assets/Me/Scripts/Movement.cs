using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int speed;
    public int sp;
    public int score = 1;
    public Rigidbody2D rb;
    public Transform tr;
    public float jumpH = 1;
    public float jumpSH = .75f;
    public float crouchT = 10;
    private double crouchTL = 0;
    private bool jump = false;
    private bool jumpS = false;
    public double crouchG = -0.1;
    public double pScore = 0;

    void Start()
    {
        rb.velocity = new Vector2(1, rb.velocity.y);
        pScore = 0;
    }

    void Update()
    {
       if (rb.velocity.y < .01 && rb.velocity.y > -.1){

        if (Input.GetButtonDown("Jump_Big") ) {
            jump = true;
            endCrouch();
            FindObjectOfType<PlaySound>().PlayJump();
        // }else if (Input.GetButtonDown("Jump_Small")){
        //     jumpS = true;
        //     endCrouch();
        }
       }
       
        if (Input.GetButtonDown("Crouch") && crouchTL < -crouchT/4+.1) {
            endJump();
            crouchTL = crouchT;
            tr.transform.localScale = new Vector2(1,.5f);
            tr.transform.position = new Vector2(tr.transform.position.x, tr.transform.position.y-.25f);
            FindObjectOfType<PlaySound>().PlayCrouch();
            UnityEngine.Debug.Log("Crouch");
        }
        //could replace "Crouch" with "UnCrouch" to set a distinct input
        if (Input.GetButtonDown("Crouch") && crouchTL > -crouchT / 4 + .1 && crouchTL < crouchT-(crouchT/10))
        {
            crouchTL = -crouchT / 4 + .1;
        }
    }
    void endCrouch() {
        crouchTL = -crouchT/4;
    }

    void endJump() {
        rb.velocity = new Vector2(rb.velocity.x, (float)crouchG/sp+1);
    }

    void FixedUpdate() {
        
        pScore += Time.deltaTime;
        rb.velocity = new Vector2(5+(speed)/sp, rb.velocity.y);
        if (jump == true){
            rb.velocity = new Vector2(rb.velocity.x, jumpH);
            jump = false;
            UnityEngine.Debug.Log("Jump");
        }else if (jumpS == true){
            rb.velocity = new Vector2(rb.velocity.x, jumpSH);
            jumpS = false;
        }
        
        if (crouchTL > 0){
            crouchTL -= Time.deltaTime;
        }else{
            if(crouchTL > -1 && crouchTL < 0){
                tr.transform.localScale = new Vector2(1,1);
                tr.transform.position = new Vector2(tr.transform.position.x, tr.transform.position.y+.25f);
                crouchTL = -1;
            }
            if (crouchTL > -crouchT/2){
                crouchTL -= Time.deltaTime;
            }
        }
    }

    public void increaseSpeed(){
        speed++;
        crouchG = speed*-2.5;
    }

    public void JumpFunction(){
       if (rb.velocity.y < .01 && rb.velocity.y > -.1){
            jump = true;
            endCrouch();
            FindObjectOfType<PlaySound>().PlayJump();
       }
    }

    public void CrouchFunction(){
        if (crouchTL < -crouchT / 4 + .1)
        {
            endJump();
            crouchTL = crouchT;
            tr.transform.localScale = new Vector2(1, .5f);
            tr.transform.position = new Vector2(tr.transform.position.x, tr.transform.position.y - .25f);
            FindObjectOfType<PlaySound>().PlayCrouch();
            UnityEngine.Debug.Log("Crouch");
        }
        //could replace "Crouch" with "UnCrouch" to set a distinct input
        if (crouchTL > -crouchT / 4 + .1 && crouchTL < crouchT - (crouchT / 10))
        {
            crouchTL = -crouchT / 4 + .1;
        }
    }
}
