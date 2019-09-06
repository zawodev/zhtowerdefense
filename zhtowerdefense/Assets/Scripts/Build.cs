using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Build : MonoBehaviour {
    
    public GameObject tower;

    bool built = false;

    void Awake() {
        GetComponent<Button>().onClick.AddListener(Create);
    }

    void Create() {
        if(!built) {
            GameObject pref;

            pref = Instantiate(tower, transform.position, transform.rotation) as GameObject;

            pref.transform.parent = GameObject.Find("RenderMap").transform;

            built = true;
        }
    }
}
