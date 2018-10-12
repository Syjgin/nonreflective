using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGenerator {

	public enum CellType
	{
		None,
		CentralMirror, //1 all
		SixDirectionsHorizontal,
		SixDirectionsVertical, //2 six
		FiveDirectionsRight,
		FiveDirectionsLeft,
		FiveDirectionsTop,
		FiveDirectionsBottom, //4 five
		FourDirections, 
		FourDirectionsDialognal, //2 four
		ThreeDirectionsVerticalLeft,
		ThreeDirectionsVerticalRight,
		ThreeDirectionsHorizontalTop,
		ThreeDirectionsHorizontalBottom,
		ThreeDirectionsDiagonalTopLeft,
		ThreeDirectionsDiagonalTopRight,
		ThreeDirectionsDiagonalBottomLeft,
		ThreeDirectionsDiagonalBottomRight, //8 three
		TwoDirectionsTopLeft,
		TwoDirectionsTopRight,
		TwoDirectionsBottomLeft,
		TwoDirectionsBottomRight,
		TwoDirectionsDiagonalLeft,
		TwoDirectionsDiagonalRight,
		TwoDirectionsDiagonalTop,
		TwoDirectionsDiagonalBottom,
		TwoDirectionsVertical,
		TwoDirectionsHorizontal,
		TwoDirectionsDiagonalBottomRightTopLeft,
		TwoDirectionsDiagonalBottomLeftTopRight, //12 two
		OneDirectionBottom,
		OneDirectionBottomRight,
		OneDirectionRight,
		OneDirectionTopRight,
		OneDirectionTop,
		OneDirectionTopLeft,
		OneDirectionLeft,
		OneDirectionBottomLeft //8 one
	}

	enum OutputType
	{
		Bottom = 0,
		BottomLeft = 1,
		Left = 2,
		TopLeft = 3,
		Top = 4,
		TopRight = 5,
		Right = 6,
		BottomRight = 7
	}

	private List<OutputType> OutputsForCell(CellType cell)
	{
		switch (cell)
		{
			case CellType.None: 
				return new List<OutputType>();
			case CellType.CentralMirror:
				return new List<OutputType>()
				{
					OutputType.Bottom, 
					OutputType.BottomLeft, 
					OutputType.Left, 
					OutputType.TopLeft, 
					OutputType.Top, 
					OutputType.TopRight, 
					OutputType.Right, 
					OutputType.BottomRight
				};
			case CellType.SixDirectionsHorizontal:
				return new List<OutputType>()
				{
					OutputType.BottomLeft, 
					OutputType.Left, 
					OutputType.TopLeft,  
					OutputType.TopRight, 
					OutputType.Right, 
					OutputType.BottomRight
				};
			case CellType.SixDirectionsVertical:
				return new List<OutputType>()
				{
					OutputType.Bottom, 
					OutputType.BottomLeft,
					OutputType.TopLeft, 
					OutputType.Top, 
					OutputType.TopRight,
					OutputType.BottomRight
				};
			case CellType.FiveDirectionsLeft:
				return new List<OutputType>()
				{
					OutputType.Bottom, 
					OutputType.BottomLeft, 
					OutputType.Left, 
					OutputType.TopLeft, 
					OutputType.Top, 
				};
			case CellType.FiveDirectionsRight:
				return new List<OutputType>()
				{
					OutputType.Bottom,  
					OutputType.Top, 
					OutputType.TopRight, 
					OutputType.Right, 
					OutputType.BottomRight
				};
			case CellType.FiveDirectionsTop:
				return new List<OutputType>()
				{ 
					OutputType.Left, 
					OutputType.TopLeft, 
					OutputType.Top, 
					OutputType.TopRight, 
					OutputType.Right
				};
			case CellType.FiveDirectionsBottom:
				return new List<OutputType>()
				{
					OutputType.Bottom, 
					OutputType.BottomLeft, 
					OutputType.Left,  
					OutputType.Right, 
					OutputType.BottomRight
				};
			case CellType.FourDirections:
				return new List<OutputType>()
				{
					OutputType.Bottom, 
					OutputType.Left,  
					OutputType.Top,  
					OutputType.Right
				};
			case CellType.FourDirectionsDialognal:
				return new List<OutputType>()
				{
					OutputType.BottomLeft, 
					OutputType.TopLeft, 
					OutputType.TopRight, 
					OutputType.BottomRight
				};
			case CellType.ThreeDirectionsVerticalLeft:
				return new List<OutputType>()
				{
					OutputType.Bottom, 
					OutputType.Left,  
					OutputType.Top
				};
			case CellType.ThreeDirectionsVerticalRight:
				return new List<OutputType>()
				{
					OutputType.Bottom, 
					OutputType.Top,  
					OutputType.Right
				};
			case CellType.ThreeDirectionsHorizontalTop:
				return new List<OutputType>()
				{
					OutputType.Left, 
					OutputType.Top, 
					OutputType.Right, 
				};
			case CellType.ThreeDirectionsHorizontalBottom:
				return new List<OutputType>()
				{
					OutputType.Bottom, 
					OutputType.Left, 
					OutputType.Right, 
				};
			case CellType.ThreeDirectionsDiagonalTopLeft:
				return new List<OutputType>()
				{
					OutputType.BottomLeft, 
					OutputType.TopLeft, 
					OutputType.TopRight, 
				};
			case CellType.ThreeDirectionsDiagonalTopRight:
				return new List<OutputType>()
				{
					OutputType.TopLeft, 
					OutputType.TopRight, 
					OutputType.BottomRight
				};
			case CellType.ThreeDirectionsDiagonalBottomLeft:
				return new List<OutputType>()
				{
					OutputType.BottomLeft, 
					OutputType.TopLeft,  
					OutputType.BottomRight
				};
			case CellType.ThreeDirectionsDiagonalBottomRight:
				return new List<OutputType>()
				{ 
					OutputType.BottomLeft, 
					OutputType.TopRight, 
					OutputType.BottomRight
				};
			case CellType.TwoDirectionsTopLeft:
				return new List<OutputType>()
				{
					OutputType.Left, 
					OutputType.Top, 
				};
			case CellType.TwoDirectionsTopRight:
				return new List<OutputType>()
				{
					OutputType.Top, 
					OutputType.Right, 
				};
			case CellType.TwoDirectionsBottomLeft:
				return new List<OutputType>()
				{
					OutputType.Bottom, 
					OutputType.Left, 
				};
			case CellType.TwoDirectionsBottomRight:
				return new List<OutputType>()
				{
					OutputType.Bottom, 
					OutputType.Right, 
				};
			case CellType.TwoDirectionsDiagonalLeft:
				return new List<OutputType>()
				{
					OutputType.BottomLeft, 
					OutputType.TopLeft, 
				};
			case CellType.TwoDirectionsDiagonalRight:
				return new List<OutputType>()
				{
					OutputType.TopRight, 
					OutputType.BottomRight
				};
			case CellType.TwoDirectionsDiagonalTop:
				return new List<OutputType>()
				{
					OutputType.TopLeft, 
					OutputType.TopRight, 
				};
			case CellType.TwoDirectionsDiagonalBottom:
				return new List<OutputType>()
				{
					OutputType.BottomLeft, 
					OutputType.BottomRight
				};
			case CellType.TwoDirectionsVertical:
				return new List<OutputType>()
				{
					OutputType.Bottom, 
					OutputType.Top, 
				};
			case CellType.TwoDirectionsHorizontal:
				return new List<OutputType>()
				{
					OutputType.Left, 
					OutputType.Right, 
				};
			case CellType.TwoDirectionsDiagonalBottomRightTopLeft:
				return new List<OutputType>()
				{
					OutputType.TopLeft, 
					OutputType.BottomRight
				};
			case CellType.TwoDirectionsDiagonalBottomLeftTopRight:
				return new List<OutputType>()
				{
					OutputType.BottomLeft, 
					OutputType.TopRight, 
				};
			case CellType.OneDirectionBottom:
				return new List<OutputType>()
				{
					OutputType.Bottom
				};
			case CellType.OneDirectionBottomRight:
				return new List<OutputType>()
				{ 
					OutputType.BottomRight
				};
			case CellType.OneDirectionRight:
				return new List<OutputType>()
				{ 
					OutputType.Right
				};
			case CellType.OneDirectionTopRight:
				return new List<OutputType>()
				{
					OutputType.TopRight
				};
			case CellType.OneDirectionTop:
				return new List<OutputType>()
				{ 
					OutputType.Top, 
				};
			case CellType.OneDirectionTopLeft:
				return new List<OutputType>()
				{
					OutputType.TopLeft
				};
			case CellType.OneDirectionLeft:
				return new List<OutputType>()
				{ 
					OutputType.Left
				};
			case CellType.OneDirectionBottomLeft:
				return new List<OutputType>()
				{
					OutputType.BottomLeft
				};
			default:
				throw new ArgumentOutOfRangeException("cell", cell, null);
		}
	}

	private bool IsOutputOpenedByNeigbour(CellType[] neighbors, OutputType output)
	{
		switch (output)
		{
			case OutputType.Bottom:
				return OutputsForCell(neighbors[(int) output]).Contains(OutputType.Top);
			case OutputType.BottomLeft:
				return OutputsForCell(neighbors[(int) output]).Contains(OutputType.TopRight) ||
					OutputsForCell(neighbors[(int)OutputType.Bottom]).Contains(OutputType.TopLeft) ||
				       OutputsForCell(neighbors[(int)OutputType.Left]).Contains(OutputType.BottomRight);
			case OutputType.Left:
				return OutputsForCell(neighbors[(int) output]).Contains(OutputType.Right);
			case OutputType.TopLeft:
				return OutputsForCell(neighbors[(int) output]).Contains(OutputType.BottomRight) ||
				       OutputsForCell(neighbors[(int) OutputType.Top]).Contains(OutputType.BottomLeft) ||
				       OutputsForCell(neighbors[(int) OutputType.Left]).Contains(OutputType.TopRight);
			case OutputType.Top:
				return OutputsForCell(neighbors[(int) output]).Contains(OutputType.Bottom);
			case OutputType.TopRight:
				return OutputsForCell(neighbors[(int) output]).Contains(OutputType.BottomLeft) ||
				       OutputsForCell(neighbors[(int) OutputType.Top]).Contains(OutputType.BottomRight) ||
				       OutputsForCell(neighbors[(int) OutputType.Right]).Contains(OutputType.TopLeft);
			case OutputType.Right:
				return OutputsForCell(neighbors[(int) output]).Contains(OutputType.Left);
			case OutputType.BottomRight:
				return OutputsForCell(neighbors[(int) output]).Contains(OutputType.TopLeft) ||
				       OutputsForCell(neighbors[(int) OutputType.Bottom]).Contains(OutputType.TopRight) ||
				       OutputsForCell(neighbors[(int) OutputType.Right]).Contains(OutputType.BottomLeft);
			default:
				throw new ArgumentOutOfRangeException("output", output, null);
		}
	}

	private List<CellType> GetAcceptableCellTypes(CellType[] neighbors)
	{
		var isBottomOpened = IsOutputOpenedByNeigbour(neighbors, OutputType.Bottom);
		var isBottomLeftOpened = IsOutputOpenedByNeigbour(neighbors, OutputType.BottomLeft);
		var isLeftOpened = IsOutputOpenedByNeigbour(neighbors, OutputType.Left);
		var isTopLeftOpened = IsOutputOpenedByNeigbour(neighbors, OutputType.TopLeft);
		var isTopOpened = IsOutputOpenedByNeigbour(neighbors, OutputType.Top);
		var isTopRightOpened = IsOutputOpenedByNeigbour(neighbors, OutputType.TopRight);
		var isRightOpened = IsOutputOpenedByNeigbour(neighbors, OutputType.Right);
		var isBottomRightOpened = IsOutputOpenedByNeigbour(neighbors, OutputType.BottomRight);
		/*Debug.Log("---outputs---");
		Debug.Log("is bottom opened: " + isBottomOpened);
		Debug.Log("is bottom left opened: " + isBottomLeftOpened);
		Debug.Log("is left opened: " + isLeftOpened);
		Debug.Log("is top left opened: " + isTopLeftOpened);
		Debug.Log("is top opened: " + isTopOpened);
		Debug.Log("is top right opened: " + isTopRightOpened);
		Debug.Log("is right opened: " + isRightOpened);
		Debug.Log("is bottom right opened: " + isBottomRightOpened);*/
		var targetCells = Enum.GetValues(typeof(CellType)).Cast<CellType>().ToList();
		targetCells.Remove(CellType.None);
		targetCells.Remove(CellType.CentralMirror);
		if (isBottomOpened)
		{
			targetCells.RemoveAll(type => !OutputsForCell(type).Contains(OutputType.Bottom));													
		}

		if (isBottomLeftOpened)
		{
			targetCells.RemoveAll(type => !OutputsForCell(type).Contains(OutputType.BottomLeft));
		}

		if (isLeftOpened)
		{
			targetCells.RemoveAll(type => !OutputsForCell(type).Contains(OutputType.Left));
		}

		if (isTopLeftOpened)
		{
			targetCells.RemoveAll(type => !OutputsForCell(type).Contains(OutputType.TopLeft));
		}

		if (isTopOpened)
		{
			targetCells.RemoveAll(type => !OutputsForCell(type).Contains(OutputType.Top));
		}

		if (isTopRightOpened)
		{
			targetCells.RemoveAll(type => !OutputsForCell(type).Contains(OutputType.TopRight));	
		}

		if (isRightOpened)
		{
			targetCells.RemoveAll(type => !OutputsForCell(type).Contains(OutputType.Right)); 			
		}

		if (isBottomRightOpened)
		{
			targetCells.RemoveAll(type => !OutputsForCell(type).Contains(OutputType.BottomRight));
		}
		return targetCells;
	}

	private int side;

	public CellType[] GenerateLevel(int side)
	{
		this.side = side;
		Random.InitState((int) DateTime.Now.Ticks);
		var result = new CellType[side * side];
		for (int i = 0; i < side; i++)
		{
			for (int j = 0; j < side; j++)
			{
				var neighbors = new CellType[8];
				for (int k = 0; k < 8; k++)
				{
					neighbors[k] = CellType.None;
				}
				if (i < side - 1)
				{
					neighbors[(int) OutputType.Bottom] = GetByCoordinates(result, i + 1, j);
				}
				if (i > 0)
				{
					neighbors[(int) OutputType.Top] = GetByCoordinates(result, i - 1, j);
				}
				if (j > 0)
				{
					neighbors[(int) OutputType.Left] = GetByCoordinates(result, i, j - 1);
				}
				if (j < side - 1)
				{
					neighbors[(int) OutputType.Right] = GetByCoordinates(result, i, j + 1);
				}
				if (j > 0 && i < side - 1)
				{
					neighbors[(int) OutputType.BottomLeft] = GetByCoordinates(result, i + 1, j - 1);
				}
				if(j < side - 1 && i < side - 1)
				{
					neighbors[(int) OutputType.BottomRight] = GetByCoordinates(result, i + 1, j + 1);
				}
				if (i > 0 && j < side - 1)
				{
					neighbors[(int) OutputType.TopRight] = GetByCoordinates(result, i - 1, j + 1);
				}
				if (i > 0 && j > 0)
				{
					neighbors[(int) OutputType.TopLeft] = GetByCoordinates(result, i - 1, j - 1);
				}
				/*Debug.Log("x:" + i);
				Debug.Log("y:" + j);
				Debug.Log("---neighbours:---");
				Debug.Log("Bottom:");
				Debug.Log(neighbors[(int)OutputType.Bottom]);
				Debug.Log("BottomLeft:");
				Debug.Log(neighbors[(int)OutputType.BottomLeft]);
				Debug.Log("Left:");
				Debug.Log(neighbors[(int)OutputType.Left]);
				Debug.Log("TopLeft:");
				Debug.Log(neighbors[(int)OutputType.TopLeft]);
				Debug.Log("Top:");
				Debug.Log(neighbors[(int)OutputType.Top]);
				Debug.Log("TopRight:");
				Debug.Log(neighbors[(int)OutputType.TopRight]);
				Debug.Log("Right:");
				Debug.Log(neighbors[(int)OutputType.Right]);
				Debug.Log("BottomRight:");
				Debug.Log(neighbors[(int)OutputType.BottomRight]);*/
				var acceptableNeighbors = GetAcceptableCellTypes(neighbors);
				/*Debug.Log("---possible variants:---");
				foreach (var acceptableNeighbor in acceptableNeighbors)
				{
					Debug.Log(acceptableNeighbor);	
				}*/
				var decision = (acceptableNeighbors.Count == 0) ? CellType.CentralMirror : acceptableNeighbors[Random.Range(0, acceptableNeighbors.Count)];
				/*Debug.Log("---decision:---");
				Debug.Log(decision);*/
				result[i * side + j] = decision;
			}
		}
		return result;
	}

	private CellType GetByCoordinates(CellType[] level, int i, int j)
	{
		return level[i * side + j];
	}
}
