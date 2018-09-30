using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BaseTrap : MonoBehaviour
{
	[FormerlySerializedAs("amount")] [SerializeField]
	private int _playerDamageAmount;

	private bool _insideDamageCoroutine = false;

	private void OnTriggerEnter(Collider other)
	{
		if (IsPlayer(other))
		{
			EventManager.AddDamageToPlayer(_playerDamageAmount);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (IsPlayer(other))
		{
			_insideDamageCoroutine = false;
			StopCoroutine(AddDamage());
		}	
	}

	private static bool IsPlayer(Collider other)
	{
		return other.gameObject.CompareTag("Player");
	}

	private void OnTriggerStay(Collider other)
	{
		if (IsPlayer(other) && !_insideDamageCoroutine)
		{
			StartCoroutine(AddDamage());	
		}
	}

	private IEnumerator AddDamage()
	{
		_insideDamageCoroutine = true;
		while (true)
		{
			yield return new WaitForSeconds(0.5f);
			EventManager.AddDamageToPlayer(_playerDamageAmount);	
		}
	}
}
