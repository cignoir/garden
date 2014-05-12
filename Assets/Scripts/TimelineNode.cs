using UnityEngine;
using System.Collections;

public enum Direction {
	N, W, E, S
}

public class TimelineNode {
	public Cell Cell { get; set; }
	public Direction Direction { get; set; }
 
	public TimelineNode(Cell cell){
		this.Cell = cell;
	}
}
