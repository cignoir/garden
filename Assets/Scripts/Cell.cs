using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour {
	// grid-based
	public int gx;
	public int gy;
	public int gz;

	public bool Selected { get; set; }
	public bool Hovered { get; set; }
	public bool Ranged { get; set; }

	static Color defaultColor = new Color(1f, 1f, 1f);
	static Color shownColor = defaultColor;
	static Color selectedColor = new Color(1f, 0.5f, 0.5f);
	static Color hoveredColor = new Color(0.5f, 0.8f, 1f);
	static Color rangedColor = new Color(0.5f, 0.6f, 0.8f);

	void Start () {
		transform.position = new Vector3 (gx * transform.localScale.x, gy * transform.localScale.y, gz * transform.localScale.z);
		Selected = false;
		Hovered = false;
		Ranged = false;
	}
	
	void Update () {
		Color ();

	}

	private void Color(){
		if(Ranged){
			shownColor = rangedColor;
		} else {
			shownColor = defaultColor;
		}

		if (Selected && Hovered) {
			renderer.material.color = selectedColor;
		} else if (Selected) {
			renderer.material.color = selectedColor;
		} else if (Hovered) {
			renderer.material.color = hoveredColor;
		} else {
            renderer.material.color = shownColor;
        }
    }

	public void Select(){
		Selected = true;
	}

	public void Unselect(){
		Selected = false;
	}

	public void HoverIn(){
		Hovered = true;
	}

	public void HoverOut(){
		Hovered = false;
	}

	public void WithinRange(){
		Ranged = true;
	}

	public void OutOfRange(){
		Ranged = false;
	}

	public int DistanceTo(int x, int y, int z){
		return Mathf.Abs(gx - x) + Mathf.Abs(gy - y) + Mathf.Abs(gz - z);
    }

	public int DistanceTo(Cell other){
		return Mathf.Abs(gx - other.gx) + Mathf.Abs(gy - other.gy) + Mathf.Abs(gz - other.gz);
	}
}
