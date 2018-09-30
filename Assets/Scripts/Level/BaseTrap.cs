using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BaseTrap : MonoBehaviour
{
	[FormerlySerializedAs("amount")] [SerializeField]
	private int _playerDamageAmount;

	private bool _isDamaging = false;

	private void OnTriggerEnter(Collider other)
	{
		if (IsPlayer(other))
		{
			EventManager.AddDamageToPlayer(_playerDamageAmount);
			if (!_isDamaging)
			{
				_isDamaging = true;
				StartCoroutine(AddDamage());			
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (IsPlayer(other))
		{
			_isDamaging = false;
		}	
	}

	private static bool IsPlayer(Collider other)
	{
		return other.gameObject.CompareTag("Player");
	}

	private IEnumerator AddDamage()
	{
		while (_isDamaging)
		{
			yield return new WaitForSeconds(1f);
			if(_isDamaging)
				EventManager.AddDamageToPlayer(_playerDamageAmount);	
		}
	}
}
