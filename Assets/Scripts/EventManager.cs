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
	
	public delegate void EnemyDamaged(int id, int amount);

	public static event EnemyDamaged OnEnemyDamaged;

	public static void AddDamageToEnemy(int id, int amount)
	{
		if (OnEnemyDamaged != null)
		{
			OnEnemyDamaged(id, amount);
		}
	}
	
	public delegate void PortalReached();

	public static event PortalReached OnPortalReached;

	public static void ReachPortal()
	{
		if (OnPortalReached != null)
		{
			OnPortalReached();
		}
	}
}
