using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {
    RenderMap renderMap;

    public GameObject enemy;

    float timer;

    void Start() {
        renderMap = GetComponent<RenderMap>();
        Spawn();
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

        pref = Instantiate(enemy, renderMap.road[0].transform.position, new Quaternion(0f, 0f, 0f, 0f)) as GameObject;

        pref.GetComponent<RectTransform>().sizeDelta = new Vector2(renderMap.block_size_x, renderMap.block_size_y);
        pref.GetComponent<RectTransform>().SetParent(transform);
    }
}
