using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody2D))]
[RequireComponent(typeof (Animator))]
public class Player : MonoBehaviour {
    public float SPEED;
    public int MAX_HEALTH;
    private float input;
    private Rigidbody2D rigidBody;
    private Animator animator;
    private int health;
    private Vector3 START_POS;

    void Start() {
        this.rigidBody = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.health = this.MAX_HEALTH;
        this.START_POS = this.transform.position;
    }

    void Update() {
        this.input = Input.GetAxisRaw("Horizontal");

        this.animator.SetBool("isRunning", this.input != 0);

        if (this.input < 0) {
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
        } else if (this.input != 0) {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void FixedUpdate() {
        this.rigidBody.velocity = new Vector2(this.SPEED * this.input, 0);
    }

    public void Reset() {
        this.health = this.MAX_HEALTH;
        this.transform.position = this.START_POS;
        this.gameObject.SetActive(true);
    }
    
    public void Damage() {
        this.health--;
        if (this.health <= 0) {
            GameManager.Get().GameOver();
        }
    }

    public int GetHealth() {
        return this.health;
    }
}
