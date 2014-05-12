using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Timeline {
	public List<TimelineNode> Nodes { get; set; }
	public TimelineNode LastNode {
		get { return Nodes.Count > 0 ? Nodes[Nodes.Count - 1] : null; }
	}

	public Timeline(){
		this.Nodes = new List<TimelineNode>();
	}

	public bool Contains(Cell cell){
		return	Nodes.Find(x => x.Cell == cell) != null;
	}

	void Start () {
	
	}
	
	void Update () {
	
	}
}
