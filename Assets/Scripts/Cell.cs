﻿using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour {
	// grid-based
	public int gx;
	public int gy;
	public int gz;

	public bool Selected { get; set; }
	public bool Hovered { get; set; }
	public bool WithinRange { get; set; }
	public bool OnRoute{ get; set; }

	static Color defaultColor = Color.white;
	static Color shownColor = defaultColor;
	static Color selectedColor = Color.magenta;
	static Color hoveredColor = Color.yellow;
	static Color rangeColor = Color.cyan;
	static Color routeColor = Color.yellow;

	void Start () {
		transform.position = new Vector3 (gx * transform.localScale.x, gy * transform.localScale.y, gz * transform.localScale.z);
		Selected = false;
		Hovered = false;
		WithinRange = false;
		OnRoute = false;
	}
	
	void Update () {
		UpdateColor ();

	}

	private void UpdateColor(){
		if(WithinRange){
			shownColor = rangeColor;
		} else {
			shownColor = defaultColor;
		}

		if(OnRoute){
			renderer.material.color = routeColor; 
		} else if (Selected && Hovered) {
			renderer.material.color = selectedColor;
		} else if (Selected) {
			renderer.material.color = selectedColor;
		} else if (Hovered) {
			renderer.material.color = hoveredColor;
		} else {
            renderer.material.color = shownColor;
        }
    }

	public int DistanceTo(int x, int y, int z){
		return Mathf.Abs(gx - x) + Mathf.Abs(gy - y) + Mathf.Abs(gz - z);
    }

	public int DistanceTo(Cell other){
		return Mathf.Abs(gx - other.gx) + Mathf.Abs(gy - other.gy) + Mathf.Abs(gz - other.gz);
	}
}
