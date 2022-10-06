using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public List<GameObject> targets;
    public List<GameObject> holes;
    private const float XOFFSET = 2.15f;
    private const float ZOFFSET = -3.5f;
    private const float SPAWNPOSY = -1.4f;

    private float spawnRate = 1.5f;
    private int score;
    private float time;

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(SpawnTarget());
    }

    IEnumerator SpawnTarget() {
        while (true) {
            yield return new WaitForSeconds(spawnRate);
            GameObject target = targets[Random.Range(0, targets.Count)];
            Vector3 holePos = holes[Random.Range(0, holes.Count)].transform.position;
            Instantiate(target, new Vector3(holePos.x + XOFFSET, SPAWNPOSY, holePos.z + ZOFFSET), target.transform.rotation);
        }
    }
}
