using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    float speed;

    void Awake() {
        speed = 40f;
    }

    void Update() {
        if(Input.GetKey("w")) transform.position += transform.up * speed * Time.deltaTime;
        if(Input.GetKey("s")) transform.position -= transform.up * speed * Time.deltaTime;
        if(Input.GetKey("a")) transform.position -= transform.right * speed * Time.deltaTime;
        if(Input.GetKey("d")) transform.position += transform.right * speed * Time.deltaTime;
    }
}
