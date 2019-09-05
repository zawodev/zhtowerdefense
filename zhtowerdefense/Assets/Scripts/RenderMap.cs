using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RenderMap : MonoBehaviour {
    float screen_width;
    float screen_height;

    public float block_size_x, block_size_y;

    public GameObject grass, ground;

    public GameObject[] road;

    public int x, y;

    void Awake() {
        x = 24;
        y = 10;

        screen_width = Screen.width;
        screen_height = Screen.height;

        block_size_x = screen_width / x;
        block_size_y = screen_height / y;

        Reset();
        Render();
    }

    void Reset() {
        for(int i = 0; i < x; i++) {
            for(int j = 0; j < y; j++) {
                GameObject block;

                block = Instantiate(grass, new Vector2(i * block_size_x + block_size_x / 2, j * block_size_y + block_size_y / 2), new Quaternion(0f, 0f, 0f, 0f)) as GameObject;

                block.GetComponent<RectTransform>().sizeDelta = new Vector2(block_size_x, block_size_y);
                block.GetComponent<RectTransform>().SetParent(transform);

                Debug.Log(j * block_size_y + block_size_y / 2);
            }
        }
    }

 
    void Render() {
        float max_x = this.x;
        float max_y = this.y;
    
        float x = 0;
        int rand_y = Random.Range(0, int.Parse("" + max_y));
        float y = float.Parse("" + rand_y / 2);

        int n = 0, i = 0;

        road = new GameObject[1000];

        bool up = true, down = true;

        while(x < max_x - 1) {
            if(n == 0) {
                GameObject block;

                block = Instantiate(ground, new Vector2(x * block_size_x + block_size_x / 2, y * block_size_y + block_size_y / 2), new Quaternion(0f, 0f, 0f, 0f)) as GameObject;

                block.GetComponent<RectTransform>().sizeDelta = new Vector2(block_size_x, block_size_y);
                block.GetComponent<RectTransform>().SetParent(transform);
            
                road[i] = block;
                i++;
                n++;
            }

            else {
                int random = Random.Range(0, 3);

                if(random == 0) {
                    x++;
                    n++;

                    up = true;
                    down = true;
                }

                else if(random == 1 && up && y * block_size_y + block_size_y / 2 < 1026) {
                    y++;

                    down = false;

                    Debug.Log(y * block_size_y + block_size_y / 2);
                }

                else if(random == 2 && down && y * block_size_y + block_size_y / 2 > 54) {
                    y--;

                    Debug.Log(y * block_size_y + block_size_y / 2);

                    up = false;
                }

                else {
                    x++;
                    n++;

                    up = true;
                    down = true;
                }

                GameObject block;

                block = Instantiate(ground, new Vector2(x * block_size_x + block_size_x / 2, y * block_size_y + block_size_y / 2), new Quaternion(0f, 0f, 0f, 0f)) as GameObject;

                block.GetComponent<RectTransform>().sizeDelta = new Vector2(block_size_x, block_size_y);
                block.GetComponent<RectTransform>().SetParent(transform);

                road[i] = block;
                i++;

                if(random == 0) {
                    x++;
                    n++;

                    up = true;
                    down = true;


                    block = Instantiate(ground, new Vector2(x * block_size_x + block_size_x / 2, y * block_size_y + block_size_y / 2), new Quaternion(0f, 0f, 0f, 0f)) as GameObject;

                    block.GetComponent<RectTransform>().sizeDelta = new Vector2(block_size_x, block_size_y);
                    block.GetComponent<RectTransform>().SetParent(transform);

                    road[i] = block;
                    i++;
                }
            }
        }
    }
}