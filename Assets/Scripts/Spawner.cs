using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public float SPAWN_HEIGHT;
    public float SPAWN_TIME;
    private float timer;
    public GameObject enemy;
    void Start() {
        
    }

    void Update() {
        if (this.timer >= this.SPAWN_TIME) {
            float x = Random.Range(-1.0f, 1.0f);
            Instantiate(this.enemy, new Vector3(x, this.SPAWN_HEIGHT, 0), Quaternion.identity);
            this.timer = 0;
        } else {
            this.timer += Time.deltaTime;
        }
    }
}
