using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public float SPAWN_TIME;
    private float SPAWN_HEIGHT = 6;
    private float MIN_X = -11.5f;
    private float MAX_X = 11.5f;
    private float timer;
    private bool spawning = true;
    public GameObject enemy;

    void Update() {
        if (!this.spawning) return;

        if (this.timer >= this.SPAWN_TIME) {
            float x = Random.Range(this.MIN_X, this.MAX_X);
            Instantiate(this.enemy, new Vector3(x, this.SPAWN_HEIGHT, 0), Quaternion.identity);
            this.timer = 0;
        } else {
            this.timer += Time.deltaTime;
        }
    }
    
    public void Stop() {
        this.spawning = false;
    }

    public void Reset() {
        this.spawning = true;
    }
}
