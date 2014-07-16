using UnityEngine;
using System.Collections;

public class Selection {

	private Vector2 start;
	private Vector2 end;
	private int width;
	private int height;

	public Selection(Vector2 start, Vector2 end) {

		this.start = start;
		this.end = end;
		recalculateSize();
	}

	public void setEnd(Vector2 end) {

		this.end = end;
		recalculateSize();
	}

	public void setStart(Vector2 start) {

		this.start = start;
		recalculateSize();
	}

	public Vector2 getEnd() {

		return end;
	}

	public Vector2 getStart() {

		return start;
	}

	private void recalculateSize() {

		width = (int) Mathf.Abs(start.x - end.x) + 1;
		height = (int) Mathf.Abs(start.y - end.y) + 1;
	}

	public bool isSquare() {

		return width == height;
	}

	public int getWidth() {

		return width;
	}

	public int getHeight() {

		return height;
	}

	public Vector2[] getVectorsInside() {

		Vector2[] result = new Vector2[getWidth() * getHeight()];


			//If the end point is at smaller coordinates than the start point we need to decrement.
			int xModifier = (start.x < end.x) ? 1 : -1;
			int yModifier = (start.y < end.y) ? 1 : -1;


			int i = 0;
			for(int x = width - 1; x >= 0; x--) {
				for(int y = height - 1; y >= 0; y--) {
					result[i] = new Vector2(start.x + (x * xModifier), start.y + (y * yModifier));
					i++;
				}
			}
			
			return result;
	}
}