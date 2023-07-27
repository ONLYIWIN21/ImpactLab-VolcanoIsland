using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody2D))]
public class Player : MonoBehaviour {
    public float SPEED;
    public int MAX_HEALTH;
    private float input;
    private Rigidbody2D rigidBody;
    void Start() {
        this.rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update() {
        this.input = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate() {
        this.rigidBody.velocity = new Vector2(this.SPEED * this.input, 0);
    }
}
