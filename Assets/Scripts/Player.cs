using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody2D))]
public class Player : MonoBehaviour {
    public float SPEED;
    public int MAX_HEALTH;
    private float input;
    private Rigidbody2D rigidBody;
    private int health;
    private Vector3 START_POS;

    void Start() {
        this.rigidBody = GetComponent<Rigidbody2D>();
        this.health = MAX_HEALTH;
        this.START_POS = this.transform.position;
    }

    void Update() {
        this.input = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate() {
        this.rigidBody.velocity = new Vector2(this.SPEED * this.input, 0);
    }

    public void Reset() {
        this.health = this.MAX_HEALTH;
        this.transform.position = this.START_POS;
        this.gameObject.SetActive(true);
    }
    
    public void Damage(int damage) {
        this.health -= damage;
        if (this.health <= 0) {
            GameManager.get().GameOver();
        }
    }
}
