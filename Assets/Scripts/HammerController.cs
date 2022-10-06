using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerController : MonoBehaviour {
    public ParticleSystem explosion;
    private GameManager gameManager;
    private const float BOTTOM = -1.5f;

    private void Start() {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update() {
        if (transform.position.y < BOTTOM) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Mole")) {
            // get score and penalty from mole and update
            Target mole = other.gameObject.GetComponent<Target>();
            gameManager.UpdateStat(mole.score, mole.penalty);
            // destroy hammer and mole if hit
            Destroy(gameObject);
            Destroy(other.gameObject);
            // instantiate explosion particle
            Instantiate(explosion, other.transform.position, explosion.transform.rotation);
            // get Player to play hitSFX
            GameObject.Find("Player").GetComponent<PlayerController>().PlayHitSFX();
        }
    }
}
