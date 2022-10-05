using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public GameObject projectile;
    public AudioClip hitSFX;
    public float power = 200.0f;
    private const float BOTTOM = -1.5f;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() {
        // create ray from camera to point on screen on mouse click to shoot projectile
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            // instantiate a hammer towards clicked direction on clicking any game object
            if (Physics.Raycast(ray, out hit, 100)) {
                GameObject hammer = Instantiate(projectile, transform.position, projectile.transform.rotation);
                Vector3 hitDir = hit.point - transform.position;
                hammer.GetComponent<Rigidbody>().AddForce(hitDir * power);
            }
        }
    }

    public void PlayHitSFX() {
        GetComponent<AudioSource>().PlayOneShot(hitSFX, 1.0f);
    }
}