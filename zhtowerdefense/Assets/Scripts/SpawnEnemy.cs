using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {
    RenderMap renderMap;

    public GameObject enemy;

    float timer;

    public GameObject[] enemys;

    void Start() {
        renderMap = GetComponent<RenderMap>();

        enemys = new GameObject[100];
        
        Spawn();
    }

    void Update() {
        timer += Time.deltaTime;

        if(timer > 6f) {
            Spawn();

            timer = 0f;
        }
    }

    void Spawn() {
        if(FullEnemy()) {
            GameObject pref;

            pref = Instantiate(enemy, renderMap.road[0].transform.position, new Quaternion(0f, 0f, 0f, 0f)) as GameObject;

            pref.GetComponent<RectTransform>().sizeDelta = new Vector2(renderMap.block_size_x, renderMap.block_size_y);
            pref.GetComponent<RectTransform>().SetParent(transform);

            AddEnemy(pref);
        }
    }

    bool FullEnemy() {
        for(int i = 0; i < enemys.Length; i++) {
            if(enemys[i] == null) {
                return true;
            }
        }

        return false;
    }

    void AddEnemy(GameObject pref) {
        for(int i = 0; i < enemys.Length; i++) {
            if(enemys[i] == null) {
                enemys[i] = pref;
                break;
            }
        }
    }
}
