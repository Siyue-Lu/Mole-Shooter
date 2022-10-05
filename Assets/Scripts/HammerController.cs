using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerController : MonoBehaviour {
    public ParticleSystem explosion;
    public AudioClip hitSFX;
    private const float BOTTOM = -1.5f;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() {
        if (transform.position.y < BOTTOM) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Mole")) {
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
