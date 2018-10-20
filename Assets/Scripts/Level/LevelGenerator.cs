﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGenerator {

	public enum CellType
	{
		HunterPortal = 0,
		Four = 1,
		Three = 2,
		ThreeMirror = 3,
		Two = 4,
		TwoCurved = 5,
		TwoCurvedMirror = 6,
		One = 7,
		OneMirror = 8
	}
	
	public class CellDescription
	{
		public readonly CellType Cell;
		public readonly int Rotation;

		public CellDescription(CellType cell, int rotation)
		{
			Cell = cell;
			Rotation = rotation;
		}
	}

	private CellDescription[] _preset1 = new[]
	{
		new CellDescription(CellType.TwoCurvedMirror, 270),
		new CellDescription(CellType.Three, 180),
		new CellDescription(CellType.One, 90),
		new CellDescription(CellType.Four, 270),
		new CellDescription(CellType.ThreeMirror, 0),
		new CellDescription(CellType.Three, 0),
		new CellDescription(CellType.TwoCurved, 180),
		new CellDescription(CellType.Three, 90),
		new CellDescription(CellType.OneMirror, 180)
	};
	
	private CellDescription[] _preset2 = new[]
	{
		new CellDescription(CellType.TwoCurved, 270),
		new CellDescription(CellType.TwoCurvedMirror, 90),
		new CellDescription(CellType.TwoCurvedMirror, 180),
		new CellDescription(CellType.Three, 90),
		new CellDescription(CellType.Three, 270),
		new CellDescription(CellType.Two, 270),
		new CellDescription(CellType.Four, 270),
		new CellDescription(CellType.ThreeMirror, 90),
		new CellDescription(CellType.Two, 0)
	};
	
	private CellDescription[] _preset3 = new[]
	{
		new CellDescription(CellType.Two, 270),
		new CellDescription(CellType.TwoCurvedMirror, 180),
		new CellDescription(CellType.TwoCurved, 0),
		new CellDescription(CellType.ThreeMirror, 0),
		new CellDescription(CellType.Four, 270),
		new CellDescription(CellType.Three, 270),
		new CellDescription(CellType.Three, 180),
		new CellDescription(CellType.Three, 0),
		new CellDescription(CellType.TwoCurvedMirror, 90)
	};
	
	private CellDescription[] _preset4 = new[]
	{
		new CellDescription(CellType.Two, 0),
		new CellDescription(CellType.Three, 270),
		new CellDescription(CellType.TwoCurved, 0),
		new CellDescription(CellType.TwoCurved, 0),
		new CellDescription(CellType.TwoCurved, 270),
		new CellDescription(CellType.ThreeMirror, 180),
		new CellDescription(CellType.TwoCurvedMirror, 180),
		new CellDescription(CellType.Three, 90),
		new CellDescription(CellType.TwoCurvedMirror, 270)
	};
	
	private CellDescription[] _preset5 = new[]
	{
		new CellDescription(CellType.OneMirror, 0),
		new CellDescription(CellType.Three, 270),
		new CellDescription(CellType.TwoCurved, 90),
		new CellDescription(CellType.Three, 90),
		new CellDescription(CellType.ThreeMirror, 270),
		new CellDescription(CellType.TwoCurvedMirror, 270),
		new CellDescription(CellType.TwoCurved, 180),
		new CellDescription(CellType.Four, 270),
		new CellDescription(CellType.TwoCurved, 90)
	};

	public const int Side = 8;
	private const int SampleSize = 3; 
	private CellDescription[] _cells;

	public CellDescription[] GenerateLevel()
	{
		Random.InitState((int) DateTime.Now.Ticks);
		_cells = new CellDescription[Side*Side];
		var randomPresets = new CellDescription[][]
		{
			_preset1,
			_preset2,
			_preset3,
			_preset4,
			_preset5
		};
		var currentRandom = Random.Range(0, randomPresets.Length);
		var currentPreset1 = randomPresets[currentRandom];
		//Debug.Log("first preset selected:"+currentRandom);
		currentRandom = Random.Range(0, randomPresets.Length);
		var currentPreset2 = randomPresets[currentRandom];
		//Debug.Log("second preset selected:"+currentRandom);
		currentRandom = Random.Range(0, randomPresets.Length);
		var currentPreset3 = randomPresets[currentRandom];
		//Debug.Log("third preset selected:"+currentRandom);
		currentRandom = Random.Range(0, randomPresets.Length);
		var currentPreset4 = randomPresets[currentRandom];
		//Debug.Log("forth preset selected:"+currentRandom);
		for (int i = 0; i < Side; i++)
		{
			for (int j = 0; j < Side; j++)
			{
				CellDescription decision = null;
				if (i == 0 || j == 0 || i == Side - 1 || j == Side - 1)
				{
						decision = new CellDescription(CellType.HunterPortal, 0); 
				} 
				else
				{
					if (
						i > 0 && 
						i <= SampleSize &&
						j > 0 &&
						j <= SampleSize)
					{
						var diff = 1;
						decision = GetByCoordinatesInternal(currentPreset1, i - diff, j - diff, SampleSize);
					}
					if (
						i > 0 && 
						i <= SampleSize &&
						j > SampleSize &&
						j <= SampleSize*2)
					{
						var xdiff = 1;
						var ydiff = 1+SampleSize;
						decision = GetByCoordinatesInternal(currentPreset2, i - xdiff, j - ydiff, SampleSize);
					}
					if (
						i > SampleSize && 
						i <= SampleSize*2 &&
						j > 0 &&
						j <= SampleSize)
					{
						var xdiff = 1+SampleSize;
						var ydiff = 1;
						decision = GetByCoordinatesInternal(currentPreset3, i - xdiff, j - ydiff, SampleSize);
					}
					if (
						i > SampleSize && 
						i <= SampleSize*2 &&
						j > SampleSize &&
						j <= SampleSize*2)
					{
						var xdiff = 1+SampleSize;
						var ydiff = 1+SampleSize;
						decision = GetByCoordinatesInternal(currentPreset4, i - xdiff, j - ydiff, SampleSize);
					}
				}
				_cells[i * Side + j] = decision;
			}
		}
		/*foreach (var cellDescription in _cells)
		{
			Debug.Log(cellDescription.Cell + ":" + cellDescription.Rotation);
		}*/
		return _cells;
	}

	public CellDescription GetByCoordinates(int i, int j)
	{
		return GetByCoordinatesInternal(_cells, i, j, Side);
	}
	
	private CellDescription GetByCoordinatesInternal(
		CellDescription[] arr,
		int i, 
		int j, 
		int side)
	{
		return arr[i * side + j];
	}
}
