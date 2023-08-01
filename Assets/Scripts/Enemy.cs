using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    private int DAMAGE;
    public GameObject explosion;
    public int MAX_DAMAGE;
    public int MIN_DAMAGE;
    public int MIN_SPEED;
    public int MAX_SPEED;
    private int SPEED;

    void Start() {
        this.SPEED = Random.Range(this.MIN_SPEED, this.MAX_SPEED);
        this.DAMAGE = Random.Range(this.MAX_DAMAGE, this.MIN_DAMAGE);
    }

    void Update() {
        this.transform.Translate(Vector3.down * (this.SPEED * Time.deltaTime));
    }

    void OnTriggerEnter2D(Collider2D other) {
        Instantiate(this.explosion, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        if (other.tag == "Player") {
            GameManager.get().DamagePlayer(this.DAMAGE);
        }
    }
}
