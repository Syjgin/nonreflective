using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGenerator {

	public enum CellType
	{
		None,
		CentralMirror,
		AllDirections, //3 all
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
			case CellType.AllDirections:
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
		var targetCells = Enum.GetValues(typeof(CellType)).Cast<CellType>().ToList();
		targetCells.Remove(CellType.None);
		if (isBottomOpened)
		{
			targetCells.Remove(CellType.SixDirectionsHorizontal);
			targetCells.Remove(CellType.FiveDirectionsTop);
			targetCells.Remove(CellType.FourDirectionsDialognal);
			targetCells.Remove(CellType.ThreeDirectionsHorizontalTop);
			targetCells.Remove(CellType.ThreeDirectionsDiagonalTopLeft);
			targetCells.Remove(CellType.ThreeDirectionsDiagonalTopRight);
			targetCells.Remove(CellType.ThreeDirectionsDiagonalBottomLeft);
			targetCells.Remove(CellType.ThreeDirectionsDiagonalBottomRight);
			targetCells.Remove(CellType.TwoDirectionsTopLeft);
			targetCells.Remove(CellType.TwoDirectionsTopRight);
			targetCells.Remove(CellType.TwoDirectionsDiagonalLeft);
			targetCells.Remove(CellType.TwoDirectionsDiagonalRight);
			targetCells.Remove(CellType.TwoDirectionsDiagonalTop);
			targetCells.Remove(CellType.TwoDirectionsDiagonalBottom);
			targetCells.Remove(CellType.TwoDirectionsHorizontal);
			targetCells.Remove(CellType.TwoDirectionsDiagonalBottomRightTopLeft);
			targetCells.Remove(CellType.TwoDirectionsDiagonalBottomLeftTopRight);
			targetCells.Remove(CellType.OneDirectionBottomRight);
			targetCells.Remove(CellType.OneDirectionRight);
			targetCells.Remove(CellType.OneDirectionTopRight);
			targetCells.Remove(CellType.OneDirectionTop);
			targetCells.Remove(CellType.OneDirectionTopLeft);
			targetCells.Remove(CellType.OneDirectionLeft);
			targetCells.Remove(CellType.OneDirectionBottomLeft);																					
		}

		if (isBottomLeftOpened)
		{
			targetCells.Remove(CellType.FiveDirectionsTop);
			targetCells.Remove(CellType.FourDirections);
			targetCells.Remove(CellType.ThreeDirectionsVerticalLeft);
			targetCells.Remove(CellType.ThreeDirectionsVerticalRight);
			targetCells.Remove(CellType.ThreeDirectionsHorizontalTop);
			targetCells.Remove(CellType.ThreeDirectionsHorizontalBottom);
			targetCells.Remove(CellType.ThreeDirectionsDiagonalTopRight);
			targetCells.Remove(CellType.TwoDirectionsTopLeft);
			targetCells.Remove(CellType.TwoDirectionsTopRight);
			targetCells.Remove(CellType.TwoDirectionsBottomLeft);
			targetCells.Remove(CellType.TwoDirectionsBottomRight);
			targetCells.Remove(CellType.TwoDirectionsDiagonalTop);
			targetCells.Remove(CellType.TwoDirectionsDiagonalRight);
			targetCells.Remove(CellType.TwoDirectionsVertical);
			targetCells.Remove(CellType.TwoDirectionsHorizontal);
			targetCells.Remove(CellType.TwoDirectionsDiagonalBottomRightTopLeft);
			targetCells.Remove(CellType.OneDirectionBottom);
			targetCells.Remove(CellType.OneDirectionBottomRight);
			targetCells.Remove(CellType.OneDirectionRight);
			targetCells.Remove(CellType.OneDirectionTopRight);
			targetCells.Remove(CellType.OneDirectionTop);
			targetCells.Remove(CellType.OneDirectionTopLeft);
			targetCells.Remove(CellType.OneDirectionLeft);
		}

		if (isLeftOpened)
		{
			targetCells.Remove(CellType.SixDirectionsVertical);
			targetCells.Remove(CellType.FiveDirectionsRight);
			targetCells.Remove(CellType.FourDirectionsDialognal);	
			targetCells.Remove(CellType.ThreeDirectionsVerticalRight);
			targetCells.Remove(CellType.ThreeDirectionsDiagonalTopLeft);
			targetCells.Remove(CellType.ThreeDirectionsDiagonalTopRight);
			targetCells.Remove(CellType.ThreeDirectionsDiagonalBottomLeft);
			targetCells.Remove(CellType.ThreeDirectionsDiagonalBottomRight);
			targetCells.Remove(CellType.TwoDirectionsTopRight);		
			targetCells.Remove(CellType.TwoDirectionsBottomRight);
			targetCells.Remove(CellType.TwoDirectionsDiagonalLeft);	
			targetCells.Remove(CellType.TwoDirectionsDiagonalRight);
			targetCells.Remove(CellType.TwoDirectionsDiagonalTop);
			targetCells.Remove(CellType.TwoDirectionsDiagonalBottom);
			targetCells.Remove(CellType.TwoDirectionsVertical);
			targetCells.Remove(CellType.TwoDirectionsDiagonalBottomRightTopLeft);		
			targetCells.Remove(CellType.TwoDirectionsDiagonalBottomLeftTopRight);
			targetCells.Remove(CellType.OneDirectionBottom);
			targetCells.Remove(CellType.OneDirectionBottom);
			targetCells.Remove(CellType.OneDirectionBottomRight);
			targetCells.Remove(CellType.OneDirectionRight);
			targetCells.Remove(CellType.OneDirectionTopRight);
			targetCells.Remove(CellType.OneDirectionTop);
			targetCells.Remove(CellType.OneDirectionTopLeft);
			targetCells.Remove(CellType.OneDirectionBottomLeft);		 
		}

		if (isTopLeftOpened)
		{
			targetCells.Remove(CellType.FiveDirectionsRight);
			targetCells.Remove(CellType.FiveDirectionsBottom);
			targetCells.Remove(CellType.FourDirections);
			targetCells.Remove(CellType.ThreeDirectionsVerticalLeft);
			targetCells.Remove(CellType.ThreeDirectionsVerticalRight);
			targetCells.Remove(CellType.ThreeDirectionsHorizontalTop);
			targetCells.Remove(CellType.ThreeDirectionsHorizontalBottom);
			targetCells.Remove(CellType.ThreeDirectionsDiagonalBottomRight);
			targetCells.Remove(CellType.TwoDirectionsTopLeft);
			targetCells.Remove(CellType.TwoDirectionsTopRight);
			targetCells.Remove(CellType.TwoDirectionsBottomLeft);
			targetCells.Remove(CellType.TwoDirectionsBottomRight);
			targetCells.Remove(CellType.TwoDirectionsDiagonalRight);
			targetCells.Remove(CellType.TwoDirectionsDiagonalBottom);	
			targetCells.Remove(CellType.TwoDirectionsVertical);
			targetCells.Remove(CellType.TwoDirectionsHorizontal);
			targetCells.Remove(CellType.TwoDirectionsDiagonalBottomLeftTopRight);
			targetCells.Remove(CellType.OneDirectionBottom);
			targetCells.Remove(CellType.OneDirectionBottomRight);
			targetCells.Remove(CellType.OneDirectionRight);
			targetCells.Remove(CellType.OneDirectionTopRight);
			targetCells.Remove(CellType.OneDirectionTop);
			targetCells.Remove(CellType.OneDirectionLeft);
			targetCells.Remove(CellType.OneDirectionBottomLeft);
		}

		if (isTopOpened)
		{
			targetCells.Remove(CellType.SixDirectionsHorizontal);
			targetCells.Remove(CellType.FiveDirectionsBottom);
			targetCells.Remove(CellType.FourDirectionsDialognal);	
			targetCells.Remove(CellType.ThreeDirectionsHorizontalBottom);
			targetCells.Remove(CellType.ThreeDirectionsDiagonalTopLeft);
			targetCells.Remove(CellType.ThreeDirectionsDiagonalTopRight);
			targetCells.Remove(CellType.ThreeDirectionsDiagonalBottomLeft);
			targetCells.Remove(CellType.ThreeDirectionsDiagonalBottomRight);
			targetCells.Remove(CellType.TwoDirectionsBottomLeft);
			targetCells.Remove(CellType.TwoDirectionsBottomRight);
			targetCells.Remove(CellType.TwoDirectionsDiagonalLeft);
			targetCells.Remove(CellType.TwoDirectionsDiagonalRight);
			targetCells.Remove(CellType.TwoDirectionsDiagonalTop);
			targetCells.Remove(CellType.TwoDirectionsDiagonalBottom);
			targetCells.Remove(CellType.TwoDirectionsHorizontal);
			targetCells.Remove(CellType.TwoDirectionsDiagonalBottomRightTopLeft);
			targetCells.Remove(CellType.TwoDirectionsDiagonalBottomLeftTopRight);
			targetCells.Remove(CellType.OneDirectionBottom);
			targetCells.Remove(CellType.OneDirectionBottomRight);
			targetCells.Remove(CellType.OneDirectionRight);
			targetCells.Remove(CellType.OneDirectionTopRight);
			targetCells.Remove(CellType.OneDirectionTopLeft);
			targetCells.Remove(CellType.OneDirectionLeft);
			targetCells.Remove(CellType.OneDirectionBottomLeft);			
		}

		if (isTopRightOpened)
		{
			targetCells.Remove(CellType.FiveDirectionsLeft);
			targetCells.Remove(CellType.FiveDirectionsBottom);
			targetCells.Remove(CellType.FourDirections);
			targetCells.Remove(CellType.ThreeDirectionsVerticalLeft);
			targetCells.Remove(CellType.ThreeDirectionsVerticalRight);
			targetCells.Remove(CellType.ThreeDirectionsHorizontalTop);
			targetCells.Remove(CellType.ThreeDirectionsHorizontalBottom);
			targetCells.Remove(CellType.ThreeDirectionsDiagonalBottomLeft);
			targetCells.Remove(CellType.TwoDirectionsTopLeft);
			targetCells.Remove(CellType.TwoDirectionsTopRight);
			targetCells.Remove(CellType.TwoDirectionsBottomLeft);
			targetCells.Remove(CellType.TwoDirectionsBottomRight);
			targetCells.Remove(CellType.TwoDirectionsDiagonalLeft);
			targetCells.Remove(CellType.TwoDirectionsDiagonalBottom);
			targetCells.Remove(CellType.TwoDirectionsVertical);
			targetCells.Remove(CellType.TwoDirectionsHorizontal);
			targetCells.Remove(CellType.TwoDirectionsDiagonalBottomRightTopLeft);
			targetCells.Remove(CellType.OneDirectionBottom);
			targetCells.Remove(CellType.OneDirectionBottomRight);
			targetCells.Remove(CellType.OneDirectionRight);
			targetCells.Remove(CellType.OneDirectionTop);
			targetCells.Remove(CellType.OneDirectionTopLeft);
			targetCells.Remove(CellType.OneDirectionLeft);
			targetCells.Remove(CellType.OneDirectionBottomLeft);		 						
		}

		if (isRightOpened)
		{
			targetCells.Remove(CellType.SixDirectionsVertical);
			targetCells.Remove(CellType.FiveDirectionsLeft);
			targetCells.Remove(CellType.FourDirectionsDialognal);
			targetCells.Remove(CellType.ThreeDirectionsVerticalLeft);
			targetCells.Remove(CellType.ThreeDirectionsDiagonalTopLeft);
			targetCells.Remove(CellType.ThreeDirectionsDiagonalTopRight);
			targetCells.Remove(CellType.ThreeDirectionsDiagonalBottomLeft);
			targetCells.Remove(CellType.ThreeDirectionsDiagonalBottomRight);
			targetCells.Remove(CellType.TwoDirectionsTopLeft);
			targetCells.Remove(CellType.TwoDirectionsBottomLeft);
			targetCells.Remove(CellType.TwoDirectionsDiagonalLeft);
			targetCells.Remove(CellType.TwoDirectionsDiagonalRight);
			targetCells.Remove(CellType.TwoDirectionsDiagonalTop);
			targetCells.Remove(CellType.TwoDirectionsDiagonalBottom);
			targetCells.Remove(CellType.TwoDirectionsVertical);
			targetCells.Remove(CellType.TwoDirectionsDiagonalBottomRightTopLeft);
			targetCells.Remove(CellType.TwoDirectionsDiagonalBottomLeftTopRight);
			targetCells.Remove(CellType.OneDirectionBottom);
			targetCells.Remove(CellType.OneDirectionBottomRight);
			targetCells.Remove(CellType.OneDirectionTopRight);
			targetCells.Remove(CellType.OneDirectionTop);
			targetCells.Remove(CellType.OneDirectionTopLeft);
			targetCells.Remove(CellType.OneDirectionLeft);
			targetCells.Remove(CellType.OneDirectionBottomLeft); 			
		}

		if (isBottomRightOpened)
		{
			targetCells.Remove(CellType.FiveDirectionsLeft);
			targetCells.Remove(CellType.FourDirections);
			targetCells.Remove(CellType.ThreeDirectionsVerticalLeft);
			targetCells.Remove(CellType.ThreeDirectionsVerticalRight);
			targetCells.Remove(CellType.ThreeDirectionsHorizontalTop);
			targetCells.Remove(CellType.ThreeDirectionsHorizontalBottom);
			targetCells.Remove(CellType.ThreeDirectionsDiagonalTopLeft);
			targetCells.Remove(CellType.TwoDirectionsTopLeft);
			targetCells.Remove(CellType.TwoDirectionsTopRight);
			targetCells.Remove(CellType.TwoDirectionsBottomLeft);
			targetCells.Remove(CellType.TwoDirectionsBottomRight);
			targetCells.Remove(CellType.TwoDirectionsDiagonalLeft);
			targetCells.Remove(CellType.TwoDirectionsDiagonalTop);
			targetCells.Remove(CellType.TwoDirectionsVertical);
			targetCells.Remove(CellType.TwoDirectionsHorizontal);	
			targetCells.Remove(CellType.TwoDirectionsDiagonalBottomLeftTopRight);
			targetCells.Remove(CellType.OneDirectionBottom);
			targetCells.Remove(CellType.OneDirectionRight);
			targetCells.Remove(CellType.OneDirectionTopRight);
			targetCells.Remove(CellType.OneDirectionTop);
			targetCells.Remove(CellType.OneDirectionTopLeft);
			targetCells.Remove(CellType.OneDirectionLeft);
			targetCells.Remove(CellType.OneDirectionBottomLeft);
		}
		return targetCells;
	}

	public CellType[] GenerateLevel(int side)
	{
		Random.InitState((int) System.DateTime.Now.Ticks);
		var result = new CellType[side * side];
		for (int i = 0; i < side; i++)
		{
			for (int j = 0; j < side; j++)
			{
				var neighbors = new CellType[8];
				if (i < side - 1)
				{
					neighbors[(int) OutputType.Bottom] = GetByCoordinates(result, i + 1, j, side);
				}
				else
				{
					neighbors[(int) OutputType.Bottom] = CellType.None;
				}
				if (i > 0)
				{
					neighbors[(int) OutputType.Top] = GetByCoordinates(result, i - 1, j, side);
				}
				else
				{
					neighbors[(int) OutputType.Top] = CellType.None;
				}
				if (j > 0)
				{
					neighbors[(int) OutputType.Left] = GetByCoordinates(result, i, j - 1, side);
				}
				else
				{
					neighbors[(int) OutputType.Left] = CellType.None;
				}
				if (j < side - 1)
				{
					neighbors[(int) OutputType.Right] = GetByCoordinates(result, i, j + 1, side);
				}
				else
				{
					neighbors[(int) OutputType.Left] = CellType.None;
				}
				if (j > 0 && i < side - 1)
				{
					neighbors[(int) OutputType.BottomLeft] = GetByCoordinates(result, i + 1, j - 1, side);
				}
				else
				{
					neighbors[(int) OutputType.BottomLeft] = CellType.None;
				}
				if(j < side - 1 && i < side - 1)
				{
					neighbors[(int) OutputType.BottomRight] = GetByCoordinates(result, i + 1, j + 1, side);
				}
				else
				{
					neighbors[(int) OutputType.BottomRight] = CellType.None;
				}
				if (i > 0 && j < side - 1)
				{
					neighbors[(int) OutputType.TopRight] = GetByCoordinates(result, i - 1, j + 1, side);
				}
				else
				{
					neighbors[(int) OutputType.TopRight] = CellType.None;
				}
				if (i > 0 && j > 0)
				{
					neighbors[(int) OutputType.TopLeft] = GetByCoordinates(result, i - 1, j - 1, side);
				}
				else
				{
					neighbors[(int) OutputType.TopLeft] = CellType.None;
				}

				var acceptableNeighbors = GetAcceptableCellTypes(neighbors);
				var decision = acceptableNeighbors[Random.Range(0, acceptableNeighbors.Count)];
				result[i * side + j] = decision;
			}
		}
		return result;
	}

	private CellType GetByCoordinates(CellType[] level, int i, int j, int side)
	{
		return level[i * side + j];
	}
}
