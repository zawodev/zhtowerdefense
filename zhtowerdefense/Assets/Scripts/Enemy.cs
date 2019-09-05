using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    RenderMap renderMap;

    int n = 0;

    float speed;

    float distance;

    void Awake() {
        renderMap = GameObject.Find("RenderMap").GetComponent<RenderMap>();

        speed = 100f;
    }

    void Update() {
        try {
            distance = Vector2.Distance(transform.position, renderMap.road[n].transform.position);

            if(distance < 1f) {
                n++;
            }

            else {
                Vector2 dir = new Vector2(
                    renderMap.road[n].transform.position.x - transform.position.x,
                    renderMap.road[n].transform.position.y - transform.position.y
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
