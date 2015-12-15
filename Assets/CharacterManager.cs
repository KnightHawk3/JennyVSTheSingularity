using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class CharacterManager : MonoBehaviour {

    public static int score = 0;
    private Rigidbody2D rb;
    public float maxspeed = 40;
    public float jumpHeight = 300;
    public Animator anim;

    [Flags]
    public enum Actions {
        IDLE = 0,
        WALK = 1,
        JUMP = 2,
        KICK = 4,
        FLY = 8,
        STOPPING = 16
    }

    Actions state = Actions.IDLE;

    void loseGame() {
        //TODO: Write this
        SceneManager.LoadScene("GameOver");
    }

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        score = 0;
    }

    bool hasFlag(Actions flag) {
        bool r = (state & flag) != 0;
        return r;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "ShieldRobot") {
            if (hasFlag(Actions.KICK)) {
                state = state ^ Actions.KICK;
                // TODO: Kill animation
                Destroy(collision.gameObject);
                score++;
            } else {
                loseGame();
            }
        } else if (collision.gameObject.tag == "Ground") {
            if (hasFlag(Actions.JUMP)) {
                Debug.Log("Jump Collision");
                state = state ^ Actions.JUMP;
            }
            if (hasFlag(Actions.KICK)) {
                Debug.Log("Kick Collision");
                state = state ^ Actions.KICK;
            }
        }
    }

    // Update is called once per frame
    void Update() {
        /*
        Debug.Log(Actions.JUMP + "JUMP     " + hasFlag(Actions.JUMP));
        Debug.Log(Actions.FLY + "IDLE     " + hasFlag(Actions.FLY));
        Debug.Log(Actions.WALK + " WALK    " + hasFlag(Actions.WALK));

        // Set the state
        Debug.Log(rb.velocity.y);
        */

        if (Input.GetButton("Right")) {
            if (rb.velocity.x < maxspeed) {
                rb.AddForce(new Vector3(maxspeed - rb.velocity.x, 0, 0));
                // if(!hasFlag(Actions.WALK))
                state = state | Actions.WALK;
            }
        } else {
            rb.AddForce(new Vector3(rb.velocity.x * -1, 0, 0));
            if (hasFlag(Actions.WALK))
                state = state ^ Actions.WALK;
        }
        // Handle input
        if (Input.GetButtonDown("Jump")) {
            if (!hasFlag(Actions.JUMP)) {
                Debug.Log("Jump!");
                state = state | Actions.JUMP;
                //Jump animation placeholder is red
                rb.AddForce(new Vector3(0, jumpHeight, 0));
                rb.AddForce(new Vector3(0, -1, 0));
            } else {
                state = state | Actions.KICK;
                rb.AddForce(new Vector3(0, -500, 0));
                rb.AddForce(new Vector3(500, -250, 0));
            }
        }

        if (state == 0) {
            if (rb.velocity.x > 1) {
                state = Actions.STOPPING;
            } else {
                state = Actions.IDLE;
            }
        } else if (state == Actions.STOPPING) {
            state = Actions.IDLE;
        }
        if (hasFlag(Actions.KICK)) {
            anim.SetBool("KICK", true);
            anim.SetBool("JUMP", false);
            anim.SetBool("WALK", false);
            anim.SetBool("IDLE", false);
        } else if (hasFlag(Actions.JUMP)) {
            anim.SetBool("JUMP", true);
            anim.SetBool("KICK", false);
            anim.SetBool("WALK", false);
            anim.SetBool("IDLE", false);
        } else if (hasFlag(Actions.WALK)) {
            Debug.Log("Walking!~~");
            anim.SetBool("WALK", true);
            anim.SetBool("IDLE", false);
            anim.SetBool("KICK", false);
            anim.SetBool("JUMP", false);
        } else {
            anim.SetBool("WALK", false);
            anim.SetBool("KICK", false);
            anim.SetBool("IDLE", false);
            anim.SetBool("JUMP", false);
        }
        Debug.Log(state + "   " + rb.velocity.x);
    }
}