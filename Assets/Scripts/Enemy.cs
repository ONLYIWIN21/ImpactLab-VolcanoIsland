using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public int DAMAGE;
    public int MIN_SPEED;
    public int MAX_SPEED;
    private int speed;

    void Start() {
        this.speed = Random.Range(this.MIN_SPEED, this.MAX_SPEED);
    }

    void Update() {
        this.transform.Translate(Vector3.down * (this.speed * Time.deltaTime));
    }
}
