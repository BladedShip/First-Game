using UnityEngine;
using System.Collections;
 
public class MovieBoiV2 : MonoBehaviour {
 
    public float walkSpeed = 6; // player left right walk speed
    private bool _isGrounded = true; // is player on the ground?
     private AudioSource audioSource;
 
    Animator animator;
 
    //some flags to check when certain animations are playing
    bool _isPlaying_run = false;
    bool _isPlaying_jump = false;


    //animation states - the values in the animator conditions
    const int STATE_IDLE = 0;
    const int STATE_RUN = 1;
    const int STATE_JUMP = 2;
 
    string _currentDirection = "right";
    int _currentAnimationState = STATE_IDLE;

 
    // Use this for initialization
    void Start()
    {
        //define the animator attached to the player
        animator = this.GetComponent<Animator>();
        audioSource = this.GetComponent<AudioSource>();
    }
 
    // FixedUpdate is used insead of Update to better handle the physics based jump
    void FixedUpdate()
    {
        //Check for keyboard input
         if (Input.GetKey ("w"))
        {
            if(_isGrounded)
            {
                _isGrounded = false;
               //simple jump code using unity physics
               GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 250));
                changeState(STATE_JUMP);
                audioSource.Play();
                _isPlaying_jump=true;
        
            }
        }
        else if (Input.GetKey ("d"))
        {
            changeDirection ("right");
            transform.Translate(Vector3.right * walkSpeed * Time.deltaTime);
 
            if(_isGrounded)
            changeState(STATE_RUN);
 
        }
        else if (Input.GetKey ("a"))
        {
            changeDirection ("left");
            transform.Translate(Vector3.right * walkSpeed * Time.deltaTime);
 
            if(_isGrounded)
            changeState(STATE_RUN);
 
        }
        else
        {
            if(_isGrounded)
            changeState(STATE_IDLE);
        }
 
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("HomieRun"))
            _isPlaying_run = true;
        else
            _isPlaying_run = false;
 
    }
 
    //--------------------------------------
    // Change the players animation state
    //--------------------------------------
    void changeState(int state){
 
        if (_currentAnimationState == state)
        return;
 
        switch (state) {
 
        case STATE_RUN:
            animator.SetInteger ("State", STATE_RUN);
            break;

        case STATE_JUMP:
            animator.SetInteger ("State", STATE_JUMP);
            break;
 
        case STATE_IDLE:
            animator.SetInteger ("State", STATE_IDLE);
            break;
 
        }
 
        _currentAnimationState = state;
    }
 
    //--------------------------------------
    // Check if player has collided with the floor
    //--------------------------------------
     void OnCollisionEnter2D(Collision2D hit)
        {
            _isGrounded = true;
        }
 
     //--------------------------------------
     // Flip player sprite for left/left walking
     //--------------------------------------
     void changeDirection(string direction)
     {
 
         if (_currentDirection != direction)
         {
             if (direction == "right")
             {
             transform.Rotate (0, 180, 0);
             _currentDirection = "right";
             }
             else if (direction == "left")
             {
             transform.Rotate (0, -180, 0);
             _currentDirection = "left";
             }
         }
 
     }
 
}