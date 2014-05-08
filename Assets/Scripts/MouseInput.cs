﻿using UnityEngine;
using System.Collections;

public class MouseInput : MonoBehaviour {
	const int LEFT_BUTTON = 0;
	const int RIGHT_BUTTON = 1;
	const int RAYCAST_RANGE = 100;

	Cell selectedCell;
	Cell hoveredCell; 
	
	void Start () {
		
	}
	
	void Update () {
		if (Input.GetMouseButtonDown (LEFT_BUTTON)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, RAYCAST_RANGE)) {
				var other = hit.collider.gameObject;
				if (other.CompareTag ("Cell")) {
					if (selectedCell != null){
						selectedCell.Unselect();
					}
					selectedCell = other.GetComponent<Cell>();
					selectedCell.Select();
				}
			}
		} else if (Input.GetMouseButtonDown (RIGHT_BUTTON)) {
			if (selectedCell != null){
				selectedCell.Unselect();
				selectedCell = null;
			}
		} else {			
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit, RAYCAST_RANGE)){
				var other = hit.collider.gameObject;
				if(other.CompareTag("Cell")){
					if(hoveredCell != null){
						hoveredCell.HoverOut();
					}
					hoveredCell = other.GetComponent<Cell>();
                    hoveredCell.HoverIn();
                }
			}
		}
	}
}
