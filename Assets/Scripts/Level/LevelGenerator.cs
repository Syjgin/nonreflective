using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator {

	enum CellType
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
		Bottom,
		BottomLeft,
		Left,
		TopLeft,
		Top,
		TopRight,
		Right,
		BottomRight
	}

	private List<OutputType> OutputsForCell(CellType cell)
	{
		switch (cell)
		{
			case CellType.None: 
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

	private List<CellType> GetAcceptableCellTypes(CellType[] neighbors)
	{
				return new List<CellType>();
	}
}
