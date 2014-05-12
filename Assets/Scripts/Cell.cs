using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour {
	// grid-based
	public int gx;
	public int gy;
	public int gz;

	public bool Selected { get; set; }
	public bool Hovered { get; set; }
	public bool WithinRange { get; set; }
	public bool IsPath{ get; set; }
	public bool IsWall { get; set; }
	public int Steps{ get; set;}
	public Direction Direction{ get; set; }

	static Color defaultColor = Color.white;
	static Color shownColor = defaultColor;
	static Color selectedColor = Color.magenta;
	static Color hoveredColor = Color.blue;
	static Color rangeColor = Color.cyan;
	static Color pathColor = Color.yellow;

	void Start () {
		transform.position = new Vector3 (gx * transform.localScale.x, gy * transform.localScale.y, gz * transform.localScale.z);
		Selected = false;
		Hovered = false;
		WithinRange = false;
		IsPath = false;
	}
	
	void Update () {
		UpdateColor ();

		switch(Direction){
		case Direction.N:
			break;
		case Direction.E:
			break;
		case Direction.W:
			break;
		case Direction.S:
			break;
		}
	}

	private void UpdateColor(){
		if(WithinRange){
			shownColor = rangeColor;
		} else {
			shownColor = defaultColor;
		}

		if (Selected) {
			renderer.material.color = selectedColor;
		} else if (Hovered) {
			renderer.material.color = hoveredColor;
		} else if(IsPath){
			renderer.material.color = pathColor;
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
