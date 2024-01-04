using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovementDisabler : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sprite;
    void Start(){
        sprite=GetComponent<SpriteRenderer>();
    }
    // public B = script
    public void DisableMovement(){
        GetComponent<Movement>().enabled = false;
        sprite.color = new Color (1, 0, 0, 1);
        rb.velocity=new Vector2(0,0);
    }
}
