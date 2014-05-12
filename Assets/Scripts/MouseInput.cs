using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MouseInput : MonoBehaviour {
	const int LEFT_BUTTON = 0;
	const int RIGHT_BUTTON = 1;
	const int RAYCAST_RANGE = 50;

	Cell selectedCell;
	Cell hoveredCell; 

	public Character character;
	
	void Start () {
		
	}

	void Update () {
		if (Input.GetMouseButtonDown (LEFT_BUTTON)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, RAYCAST_RANGE)) {
				var other = hit.collider.gameObject;
				if (other.CompareTag ("Cell")) {
					var shouldBeSelected = other.GetComponent<Cell>();
					if(shouldBeSelected.WithinRange){
						if (selectedCell != null){
							selectedCell.Selected = false;
						}
						selectedCell = shouldBeSelected;
						selectedCell.Selected = true;

						var tmpNodes = new List<TimelineNode>();
						for(int x = 0; x < Battle.SIZE_X; x++){
							for(int z = 0; z < Battle.SIZE_Z; z++){
								if(Battle.cells[x, 0, z].IsPath){
									tmpNodes.Add(new TimelineNode(Battle.cells[x, 0, z]));
								}
							}
						}
						tmpNodes.Sort ((a, b) => a.Cell.Steps - b.Cell.Steps);

						TimelineNode lastNode = null;
						foreach(TimelineNode node in tmpNodes){
							character.timeline.Nodes.Add(node);

							if(lastNode != null){
								if(node.Cell.gx > lastNode.Cell.gx){
									node.Direction = Direction.E;
								} else if(node.Cell.gx < lastNode.Cell.gx){
									node.Direction = Direction.W;
								} else if(node.Cell.gy > lastNode.Cell.gy){
									node.Direction = Direction.N;
                                } else {
                                    node.Direction = Direction.S;
                                }
                            }
							lastNode = node;
						}

						tmpNodes = null;
					}
				}
			}
		} else if (Input.GetMouseButtonDown (RIGHT_BUTTON)) {
			if (selectedCell != null){
				selectedCell.Selected = false;
				selectedCell = null;
				character.timeline.Nodes.Clear();
			}
		} else {			
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit, RAYCAST_RANGE)){
				var other = hit.collider.gameObject;
				if(other.CompareTag("Cell")){
					if(hoveredCell != null){
						hoveredCell.Hovered = false;
					}
					hoveredCell = other.GetComponent<Cell>();
					hoveredCell.Hovered = true;

					var pathfinder = new Pathfinder(Battle.SIZE_X, Battle.SIZE_Z, Ways.FOUR);
					if(character.timeline.LastNode != null){
						var lastNode = character.timeline.LastNode;
						pathfinder = pathfinder.From(lastNode.Cell.gx, lastNode.Cell.gz);
					} else {
						pathfinder = pathfinder.From(1, 0);
					}

					pathfinder = pathfinder.To(hoveredCell.gx, hoveredCell.gz);
					for(int x = 0; x < Battle.SIZE_X; x++){
						for(int z = 0; z < Battle.SIZE_Z; z++){
							if(Battle.cells[x, 0 , z].IsWall){
								pathfinder = pathfinder.Wall(x, z);
							}
						}
					}

					var cells = pathfinder.Pathfind().Cells;

					for(int x = 0; x < Battle.SIZE_X; x++){
						for(int y = 0; y < Battle.SIZE_Z; y++){
							if(!character.timeline.Contains(Battle.cells[x, 0 , y])){
								Battle.cells[x, 0 , y].IsPath = cells[x, y].IsPath;
								Battle.cells[x, 0 , y].Steps = cells[x, y].Steps;
							}
						}
					}

                }
			}
		}
	}
}
