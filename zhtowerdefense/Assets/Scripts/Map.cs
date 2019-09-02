using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {
	
	int[,] map;
	int n;
	string line;
	
	int x, y;
	
	public GameObject[] sprites;

	void Start() {
		n = 20;
		InitMap();
		ResetMap();
		RednerMap();
		DrawMap();
		DebugMap();
	}
	
	void InitMap() {
		map = new int[n, n];
	}

	void ResetMap() {
		for(int i = 0; i < n; i++) {
			for(int j = 0; j < n; j++) {
				map[i, j] = 0;
			}
		}
	}
	
	void RednerMap() {
		for(int i = 0; i < n; i++) {
			for(int j = 0; j < n; j++) {
				try {
					if(i == 0) {
						x = 0;
						y = Random.Range(0, n);
						map[x, y] = 1;
						break;
					}
					
					else {
						int rand = Random.Range(0, 12);
						
						if(rand > 0 && rand < 4) {
							if(x < n-1) {
								x++;
								
								map[x, y] = 1;
							}
						}
						
						else if(rand >= 4 && rand < 8) {
							if(y < n-1) {
								y++;
								if(map[x, y] == 0)
									map[x, y] = 1;
								else
									y--;
							}
						}
						
						else if(rand >= 8) {
							if(y > 0) {
								y--;
								if(map[x, y] == 0)
									map[x, y] = 1;
								else
									y++;
							}
						}
					}
				} catch {}
			}
		}
	}
	
	void DrawMap() {
		for(int i = 0; i < n; i++) {
			for(int j = 0; j < n; j++) {
				GameObject pref;

				pref = Instantiate(sprites[map[i, j]], new Vector3(i * 1, j * 1), new Quaternion(0f, 0f, 0f, 0f)) as GameObject;
			}
			
			Debug.Log(line);
			line = "";
		}
	}

	void DebugMap() {
		for(int i = 0; i < n; i++) {
			for(int j = 0; j < n; j++) {
				line += map[i, j];
			}
			
			Debug.Log(line);
			line = "";
		}
	}
}