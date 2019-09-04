using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    public float speed;
    public Rigidbody2D rb;

    void Update() {
        /*if(Input.GetKey("w")) transform.position += transform.up * speed * Time.deltaTime;
        if(Input.GetKey("s")) transform.position -= transform.up * speed * Time.deltaTime;
        if(Input.GetKey("a")) transform.position -= transform.right * speed * Time.deltaTime;
        if(Input.GetKey("d")) transform.position += transform.right * speed * Time.deltaTime;/*/

        // musiałem zakomentowac sry xD

        MoveCharacter(new Vector2 (Input.GetAxis("Horizontal"), 0));
    }
    public void MoveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }
}
