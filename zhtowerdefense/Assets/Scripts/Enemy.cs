using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    Map map;

    int n = 0;

    float speed;

    float distance;

    void Awake() {
        map = GameObject.Find("Map").GetComponent<Map>();

        speed = Random.Range(5f, 15f);
    }

    void Update() {
        try {
            distance = Vector2.Distance(transform.position, map.mapRoad[n].transform.position);

            if(distance < 0.1f) {
                n++;
            }

            else {
                Vector2 dir = new Vector2(
                    map.mapRoad[n].transform.position.x - transform.position.x,
                    map.mapRoad[n].transform.position.y - transform.position.y
                );

                transform.up = dir;

                transform.position += transform.up * speed * Time.deltaTime;
            }
        }

        catch {
            Destroy(gameObject);
        }
    }
}
