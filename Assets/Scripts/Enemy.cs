using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

	public int Id;
	[SerializeField] private int _hp;

	private void OnEnable()
	{
		EventManager.OnEnemyDamaged += AcceptDamage;
	}

	private void OnDisable()
	{
		EventManager.OnEnemyDamaged -= AcceptDamage;
	}

	private void AcceptDamage(int id, int amount)
	{
		if(id != Id)
			return;
		_hp -= amount;
		//TODO: play hurt animation etc.
		if (_hp <= 0)
		{
			Die();
		}
	}

	private void Die()
	{
		//TODO: play death animation
		Destroy(gameObject);
	}
}
