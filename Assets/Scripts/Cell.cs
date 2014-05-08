using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour {
	// grid-based
	public int gx;
	public int gy;
	public int gz;

	public bool Selected { get; set; }
	public bool Hovered { get; set; }

	static Color defaultColor = new Color(255, 255, 255);
	static Color shownColor = defaultColor;
	static Color selectedColor = new Color(255, 0, 0);
	static Color hoveredColor = new Color(0, 0, 255);

	void Start () {
		transform.position = new Vector3 (gx * transform.localScale.x, gy * transform.localScale.y, gz * transform.localScale.z);
		Selected = false;
		Hovered = false;
	}
	
	void Update () {
		Color ();

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

	private void Color(){
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
}
