using UnityEngine;
using System.Collections;

public class MouseInput : MonoBehaviour {
	const int LEFT_BUTTON = 0;
	const int RIGHT_BUTTON = 1;
	const int RAYCAST_RANGE = 50;

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
					var shouldBeSelected = other.GetComponent<Cell>();
					if(shouldBeSelected.WithinRange){
						if (selectedCell != null){
							selectedCell.Selected = false;
						}
						selectedCell = shouldBeSelected;
						selectedCell.Selected = true;
					}
				}
			}
		} else if (Input.GetMouseButtonDown (RIGHT_BUTTON)) {
			if (selectedCell != null){
				selectedCell.Selected = false;
				selectedCell = null;
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

					var cells = new Pathfinder(3, 5, Ways.FOUR).From(1, 0).To(hoveredCell.gx, hoveredCell.gz).Pathfind().Cells;

					for(int x = 0; x < 3; x++){
						for(int y = 0; y < 5; y++){
							Battle.cells[x, 0 , y].OnRoute = cells[x, y].IsPath;
						}
					}

                }
			}
		}
	}
}
