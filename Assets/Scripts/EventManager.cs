using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{

	public delegate void PlayerDamaged(int amount);

	public static event PlayerDamaged OnPlayerDamaged;

	public static void AddDamageToPlayer(int amount)
	{
		if (OnPlayerDamaged != null)
		{
			OnPlayerDamaged(amount);
		}
	}
}
