using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sucker : MonoBehaviour
{

	[SerializeField] private Manoeuvre.ManoeuvreFPSController _fpsController;

	private bool triggered = false;
	private Collider other;
	
	private void OnTriggerEnter(Collider other)
	{
		if (TagUtils.IsEnemy(other))
		{
			triggered = true;
			this.other = other;
			var enemy = other.gameObject.GetComponent<Enemy>();
			_fpsController.AttackManager.AddTarget(enemy.Id);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (TagUtils.IsEnemy(other))
		{
			_fpsController.AttackManager.RemoveTarget();
		}
	}

	private void Update()
	{
		if (triggered && !other)
		{
			triggered = false;
			_fpsController.AttackManager.RemoveTarget();
		}
	}
}
