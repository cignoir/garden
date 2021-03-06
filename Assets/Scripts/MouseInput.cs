﻿using UnityEngine;
using System.Collections;

public class MouseInput : MonoBehaviour {
	public Pathfinder pathfinder;
	const int LEFT_MOUSE_BUTTON = 0;
	const int RIGHT_MOUSE_BUTTON = 1;

	void Start () {
	}
	
	void Update () {
		if(Input.GetMouseButtonDown(LEFT_MOUSE_BUTTON)){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit, 100)){
				var other = hit.collider.gameObject;
				if(other.CompareTag("Cell")){
					var collision = other.GetComponent<PathfinderCell>();

				}
			}
		} else if(Input.GetMouseButtonDown(RIGHT_MOUSE_BUTTON)){
		} else {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit, 100)){
				var other = hit.collider.gameObject;
				if(other.CompareTag("Cell")){
					var collision = other.GetComponent<PathfinderCell>();
					
					pathfinder.ClearLogic();
					pathfinder.From(0, 0).To(collision.x, collision.y);
					pathfinder.SetMovingPriorities(Direction.W, Direction.E, Direction.N, Direction.S);
					pathfinder.Pathfind();
					
					var gui = GameObject.FindGameObjectWithTag("GUIText");
					gui.guiText.text = 
						"(x, y) = (" + collision.x + ", " + collision.y + ")"
							+ "\n IsPath = " + collision.IsPath.ToString()
							+ "\n IsWall = " + collision.IsWall.ToString()
							+ "\n Direction = " + collision.Direction.ToString()
							+ "\n Steps = " + collision.Steps.ToString();
				}
			}
		}
	}
}
