using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {
    public float moveSpeed = 0.1f;
    public float waitTime = 1.0f;
    public int score;
    public int penalty;

    private const float TOP = 0.15f;
    private const float BOTTOM = -1.5f;

    private GameManager gameManager;
    private bool fullyAppeared = false;
    private float timer = 0.0f;

    // Start is called before the first frame update
    void Start() {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void FixedUpdate() {
        // move mole up when not fully appeared
        if (!fullyAppeared) {
            transform.Translate(0, moveSpeed, 0);
        }
        // limit mole moving within TOP
        if (transform.position.y > TOP) {
            transform.position = new Vector3(transform.position.x, TOP, transform.position.z);
            timer = 0;
            fullyAppeared = true;
        }
        // count down till waitTime runs out, then move mole down
        if (fullyAppeared) {
            timer += Time.deltaTime;
            if (timer > waitTime) {
                transform.Translate(0, -moveSpeed, 0);
            }
        }
        // destroy when mole moved under BOTTOM
        if (transform.position.y < BOTTOM) {
            Destroy(gameObject);
        }
    }
}