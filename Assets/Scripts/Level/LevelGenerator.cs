﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGenerator {

	public enum CellType
	{
		None = 0,
		CentralMirror = 1, //1 all
		SixDirectionsHorizontal = 2,
		SixDirectionsVertical = 3, //2 six
		FiveDirectionsRight = 4,
		FiveDirectionsLeft = 5,
		FiveDirectionsTop = 6,
		FiveDirectionsBottom = 7, //4 five
		FourDirections = 8, 
		FourDirectionsDialognal = 9, //2 four
		ThreeDirectionsVerticalLeft = 10,
		ThreeDirectionsVerticalRight = 11,
		ThreeDirectionsHorizontalTop = 12,
		ThreeDirectionsHorizontalBottom = 13,
		ThreeDirectionsDiagonalTop = 14,
		ThreeDirectionsDiagonalRight = 15,
		ThreeDirectionsDiagonalBottom = 16,
		ThreeDirectionsDiagonalLeft = 17,
		ThreeDirectionsDiagonalTopLeft = 18,
		ThreeDirectionsDiagonalTopRight = 19,
		ThreeDirectionsDiagonalBottomLeft = 20,
		ThreeDirectionsDiagonalBottomRight = 21, //12 three
		TwoDirectionsTopLeft = 22,
		TwoDirectionsTopRight = 23,
		TwoDirectionsBottomLeft = 24,
		TwoDirectionsBottomRight = 25,
		TwoDirectionsDiagonalLeft = 26,
		TwoDirectionsDiagonalRight = 27,
		TwoDirectionsDiagonalTop = 28,
		TwoDirectionsDiagonalBottom = 29,
		TwoDirectionsVertical = 30,
		TwoDirectionsHorizontal = 31,
		TwoDirectionsDiagonalBottomRightTopLeft = 32,
		TwoDirectionsDiagonalBottomLeftTopRight = 33, //12 two
		OneDirectionBottom = 34,
		OneDirectionBottomRight = 35,
		OneDirectionRight = 36,
		OneDirectionTopRight = 37,
		OneDirectionTop = 38,
		OneDirectionTopLeft = 39,
		OneDirectionLeft = 40,
		OneDirectionBottomLeft = 41 //8 one
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
			case CellType.ThreeDirectionsDiagonalBottom:
				return new List<OutputType>()
				{
					OutputType.Bottom, 
					OutputType.BottomLeft, 
					OutputType.BottomRight, 
				};
			case CellType.ThreeDirectionsDiagonalLeft:
				return new List<OutputType>()
				{
					OutputType.Left, 
					OutputType.BottomLeft, 
					OutputType.TopLeft, 
				};
			case CellType.ThreeDirectionsDiagonalTop:
				return new List<OutputType>()
				{
					OutputType.Top, 
					OutputType.TopLeft, 
					OutputType.TopRight, 
				};
			case CellType.ThreeDirectionsDiagonalRight:
				return new List<OutputType>()
				{
					OutputType.Right, 
					OutputType.BottomRight, 
					OutputType.TopRight, 
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

	private int _side;
	private CellType[] _cells;

	public CellType[] GenerateLevel(int side)
	{
		this._side = side;
		Random.InitState((int) DateTime.Now.Ticks);
		_cells = new CellType[side*side];
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
					neighbors[(int) OutputType.Bottom] = GetByCoordinates(i + 1, j);
				}
				if (i > 0)
				{
					neighbors[(int) OutputType.Top] = GetByCoordinates(i - 1, j);
				}
				if (j > 0)
				{
					neighbors[(int) OutputType.Left] = GetByCoordinates(i, j - 1);
				}
				if (j < side - 1)
				{
					neighbors[(int) OutputType.Right] = GetByCoordinates(i, j + 1);
				}
				if (j > 0 && i < side - 1)
				{
					neighbors[(int) OutputType.BottomLeft] = GetByCoordinates(i + 1, j - 1);
				}
				if(j < side - 1 && i < side - 1)
				{
					neighbors[(int) OutputType.BottomRight] = GetByCoordinates(i + 1, j + 1);
				}
				if (i > 0 && j < side - 1)
				{
					neighbors[(int) OutputType.TopRight] = GetByCoordinates(i - 1, j + 1);
				}
				if (i > 0 && j > 0)
				{
					neighbors[(int) OutputType.TopLeft] = GetByCoordinates(i - 1, j - 1);
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
				_cells[i * side + j] = decision;
			}
		}
		return _cells;
	}

	public CellType GetByCoordinates(int i, int j)
	{
		return _cells[i * _side + j];
	}
}
