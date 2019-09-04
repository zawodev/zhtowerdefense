using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRandomer : MonoBehaviour
{
    public List<Sprite> bgs = new List<Sprite>();

    public void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = bgs[Random.Range(0, bgs.Count)];
    }
}
