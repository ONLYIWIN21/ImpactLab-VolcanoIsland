using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (AudioSource))]
public class MusicManager : MonoBehaviour {
    private static MusicManager _instance = null;

    void Awake() {
        if (MusicManager._instance == null) {
            MusicManager._instance = this;
        } else {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this);
    }

    public static MusicManager Get() {
        return MusicManager._instance;
    }
    private AudioSource audioSource;

    void Start() {
        this.audioSource = GetComponent<AudioSource>();

        if (!this.audioSource.isPlaying) this.audioSource.Play();
    }
}
