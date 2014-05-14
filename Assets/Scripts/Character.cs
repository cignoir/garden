using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	public int MP { get; set; }
	public int AP { get; set; }
	public Direction direction { get; set; }

	void Start () {
		MP = 10;
	}
	
	void Update () {
	
	}
}
