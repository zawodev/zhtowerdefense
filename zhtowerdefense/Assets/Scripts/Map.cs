﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {
	
	public GameObject[] mapRoad;

	int[,] map;
	int n;
	string line;
	
	
	public GameObject[] sprites;

	void Awake () {
		n = 20;
		InitMap();
		RednerMap();
		GrassMap();
	}
	
	void InitMap() {
		map = new int[n, n];
		mapRoad = new GameObject[n*n];
	}

	void GrassMap() {
		for(int i = 0; i < n; i++) {
			for(int j = 0; j < n; j++) {
				if(map[i, j] == 0) {
					GameObject pref;
					pref = Instantiate(sprites[0], new Vector3(i * 3, j * 3), new Quaternion(0f, 0f, 0f, 0f)) as GameObject;
				}
			}
		}
	}

	int x, y;
	bool canUp, canDown, right = false;
	int h;

	void RednerMap() {
		int z = 0;
		int l = 0;
		
		while(x < n) {
			try {
				if(l == 0) {
					x = 0;
					y = Random.Range(0, n);
					GameObject pref;
					pref = Instantiate(sprites[1], new Vector3(x * 3, y * 3), new Quaternion(0f, 0f, 0f, 0f)) as GameObject;

					mapRoad[z] = pref;

					map[x, y] = 1;
				
					z++;
				}

				else {
					int r; 
					if(h > 0 && canUp) {
						r = 1;
					}

					else if(h > 0 && canDown) {
						r = 2;
					}

					else
						r = Random.Range(0, 3);

					if(r == 0) {
						x++;
						canUp = true;
						canDown = true;
						right = true;
					}

					else if(r == 1 && canUp) {
						y++;
						canDown = false;

						if(h == 0) h = Random.Range(1, 5);
						else h--;

						if(y > n) {
							y--;
							right = true;
						}
					}

					else if(r == 2 && canDown) {
						y--;
						canUp = false;

						if(h == 0) h = Random.Range(1, 5);
						else h--;

						if(y < 1) {
							y++;
							right = true;
						}
					}

					else {
						x++;
						canUp = true;
						canDown = true;
						right = true;
					}

					GameObject pref;
					pref = Instantiate(sprites[1], new Vector3(x * 3, y * 3), new Quaternion(0f, 0f, 0f, 0f)) as GameObject;

					mapRoad[z] = pref;

					map[x, y] = 1;
				
					z++;

					if(right) {
						x++;

						pref = Instantiate(sprites[1], new Vector3(x * 3, y * 3), new Quaternion(0f, 0f, 0f, 0f)) as GameObject;

						mapRoad[z] = pref;

						map[x, y] = 1;

						right = false;
						z++;
					}
				}
			}

			catch {

			}

			l++;
		}
	}

	public Transform GetSpawnPosition() {
		return mapRoad[0].transform;
	}
}