﻿using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	// grid-based
	public int gx;
	public int gy;
	public int gz;

	public float MaxAP { get; set; }
	public float CurrentAP { get; set; }

	public Timeline timeline;
	
	void Start () {
		MaxAP = 3.0f;
		CurrentAP = MaxAP;
		transform.position = new Vector3((float)gx * 2f, (float)gy * 1 + 0.5f, (float)gz * 2f);
		timeline = new Timeline();
	}

	void Update () {
		ShowMovingRange();
	}

	void ShowMovingRange(){
		var cells = FindObjectsOfType<Cell>();
		foreach(Cell cell in cells){
			if(cell.DistanceTo(gx, gy, gz) <= CurrentAP){
				cell.WithinRange = true;
				cell.IsWall = false;
			} else {
				cell.WithinRange = false;
				cell.IsWall = true;
			}
		}
	}
}
