using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    private static GameManager _instance = null;

    void Awake() {
        if (GameManager._instance == null) {
            GameManager._instance = this;
        }
    }

    public static GameManager Get() {
        return GameManager._instance;
    }

    public Player player;
    public Canvas gameOverCanvas;
    public Canvas heartsCanvas;
    public Spawner spawner;
    public GameObject heart;
    private GameObject[] hearts;

    void Start() {
        this.hearts = new GameObject[this.player.MAX_HEALTH];
        float y = this.heartsCanvas.transform.position.y;
        for (int i = 0; i < this.hearts.Length; i++) {
            this.hearts[i] = Instantiate(this.heart, new Vector3(10 + 70 * i, 0, 0), Quaternion.identity, this.heartsCanvas.transform);
        }
    }
    
    public void GameOver() {
        this.player.gameObject.SetActive(false);
        this.spawner.Stop();
        this.gameOverCanvas.gameObject.SetActive(true);
    }

    public void DamagePlayer() {
        this.player.Damage();
        this.hearts[this.player.GetHealth()].gameObject.SetActive(false);
    }

    public void RestartGame() {
        this.player.Reset();
        this.spawner.Reset();
        this.gameOverCanvas.gameObject.SetActive(false);

        for (int i = 0; i < this.hearts.Length; i++) {
            this.hearts[i].gameObject.SetActive(true);
        }
    }

    public void Menu() {
        SceneManager.LoadScene("MainMenu");
    }
}
