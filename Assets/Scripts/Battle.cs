﻿using UnityEngine;
using System.Collections;

public class Battle : MonoBehaviour {
	public const int SIZE_X = 3;
	public const int SIZE_Y = 1;
	public const int SIZE_Z = 5;

	public static Cell[,,] cells = new Cell[SIZE_X, SIZE_Y, SIZE_Z];

	void Start () {
		foreach(Cell cell in FindObjectsOfType<Cell>()){
			cells[cell.gx, cell.gy, cell.gz] = cell;
		}
	
	}
	
	void Update () {
	
	}

	public Cell Cell(int x, int y, int z){
		return cells[x, y, z];
	}
}
