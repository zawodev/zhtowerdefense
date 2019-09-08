using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    SpawnEnemy spawnEnemy;

    public float distance;

    public Transform enemy;

    float timer, timerAttack;

    void Awake() {
        spawnEnemy = GameObject.Find("RenderMap").GetComponent<SpawnEnemy>();
        GetEnemy();
    }

    void Update()
    {
        timerAttack += Time.deltaTime; 
        timer += Time.deltaTime;

        if(timer > 2.5f) {
            GetEnemy();
            timer = 0f;
        }

        if(timerAttack > 1f) {
            try {
                enemy.GetComponent<Enemy>().hp -= 5;
            }

            catch {
                timer = 3f;
            }
            timerAttack = 0f;
        }

        Focus();
    }

    void GetEnemy() {
        for(int i = 0; i < spawnEnemy.enemys.Length; i++) {
            try {
                distance = Vector2.Distance(transform.position, spawnEnemy.enemys[i].transform.position);

                if(distance < 500f) {
                    enemy = spawnEnemy.enemys[i].transform;
                }
            }

            catch {

            }
        }
    }

    void Focus() {
        try {
            Vector2 dir = new Vector2(
                enemy.transform.position.x - transform.position.x,
                enemy.transform.position.y - transform.position.y
            );

            transform.GetChild(0).transform.up = dir;
        }

        catch {}
    }
}
