using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {
    Map map;

    public GameObject enemy;

    float timer;

    void Awake() {
        map = GetComponent<Map>();
    }

    void Update() {
        timer += Time.deltaTime;

        if(timer > 2f) {
            Spawn();

            timer = 0f;
        }
    }

    void Spawn() {
        GameObject pref;

        pref = Instantiate(enemy, map.GetSpawnPosition().position, new Quaternion(0f, 0f, 0f, 0f)) as GameObject;
        pref.transform.parent = GameObject.Find("BACKGROUND").transform;
    }
}
