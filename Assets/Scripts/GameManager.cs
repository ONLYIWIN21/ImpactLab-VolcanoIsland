using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private static GameManager _instance = null;

    void Awake() {
        if (_instance == null) {
            _instance = this;
        }
    }

    public static GameManager get() {
        return GameManager._instance;
    }

    public Player player;
    
    public void GameOver() {
        this.player.gameObject.SetActive(false);
    }

    public void DamagePlayer(int damage) {
        this.player.Damage(damage);
    }
}
