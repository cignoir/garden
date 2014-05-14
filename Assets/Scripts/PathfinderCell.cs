using UnityEngine;
using System.Collections;

public class PathfinderCell: MonoBehaviour
{
	const int DEFAULT_STEPS = 10000;

	public int x { get { return (int)transform.position.x; } }
	public int y { get { return (int)transform.position.z; } }
	public PathfinderContent ContentCode { get; set; }

	public int Steps { get; set; }
	public bool IsPath { get; set; }
	public bool IsWall;
	public Direction Direction { get; set; }

	public GameObject cube;
	public GameObject plot;
	public GameObject marker;

	void Start(){
		ContentCode = IsWall? PathfinderContent.Wall : PathfinderContent.Empty;
		Steps = DEFAULT_STEPS;
	}

	void Update(){
		if(IsPath)
		{
			cube.renderer.material.color = Color.cyan;
		} else if(IsWall) {
			cube.renderer.material.color = Color.gray;
		} else {
			cube.renderer.material.color = Color.white;
		}

		plot.SetActive(IsPath);
    }
}