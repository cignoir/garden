using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	// grid-based
	public int gx;
	public int gy;
	public int gz;
	
	void Start () {
		transform.position = new Vector3 (gx * transform.localScale.x, (float)(gy * transform.localScale.y * 1.5), gz * transform.localScale.z);
	}

	void Update () {
	
	}
}
