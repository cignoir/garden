using UnityEngine;
using System.Collections;

public class PathfinderCell: MonoBehaviour
{
	const int DEFAULT_STEPS = 10000;

	public int x;
	public int y;
	public PathfinderContent ContentCode { get; set; }

	public int Steps { get; set; }
	public bool IsPath { get; set; }
	public bool IsWall;
	public Direction Direction { get; set; }

	public GameObject N;
	public GameObject E;
	public GameObject W;
	public GameObject S;
	public GameObject marker;

	void Start(){
		ContentCode = IsWall? PathfinderContent.Wall : PathfinderContent.Empty;
		Steps = DEFAULT_STEPS;
	}

	void Update(){
		if(IsPath)
		{
			renderer.material.color = Color.cyan;
		} else if(IsWall) {
			renderer.material.color = Color.gray;
		} else {
			renderer.material.color = Color.white;
		}

		if(IsPath){
			switch(Direction){
			case Direction.N:
				N.SetActive(true);
				E.SetActive(false);
				W.SetActive(false);
				S.SetActive(false);
				break;
			case Direction.E:
				N.SetActive(false);
				E.SetActive(true);
				W.SetActive(false);
				S.SetActive(false);
				break;
			case Direction.W:
				N.SetActive(false);
				E.SetActive(false);
				W.SetActive(true);
				S.SetActive(false);
				break;
			case Direction.S:
				N.SetActive(false);
				E.SetActive(false);
				W.SetActive(false);
				S.SetActive(true);
				break;
			default:
				N.SetActive(false);
				E.SetActive(false);
				W.SetActive(false);
				S.SetActive(false);
				break;
			}
		} else {
			N.SetActive(false);
			E.SetActive(false);
			W.SetActive(false);
            S.SetActive(false);
        }
    }
}