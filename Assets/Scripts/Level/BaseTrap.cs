using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BaseTrap : MonoBehaviour
{
	[FormerlySerializedAs("amount")] [SerializeField]
	private int _playerDamageAmount;

	private bool _isDamaging = false;
	[SerializeField] private float _period;
	[SerializeField]
	private Animator _animator;
	private bool _isActivated;
	private float _currentTime;

	private void Awake()
	{
		_currentTime = Random.Range(0, _period);
		_animator.SetBool("active", false);
	}

	private void OnTriggerEnter(Collider other)
	{
		if(!_isActivated)
			return;
		if (TagUtils.IsPlayer(other))
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
		if (TagUtils.IsPlayer(other))
		{
			_isDamaging = false;
		}	
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

	private void Update()
	{
		_currentTime += Time.deltaTime;
		if (_currentTime > _period)
		{
			_currentTime = 0;
			_isActivated = !_isActivated;
			_animator.SetBool("active", _isActivated);
		}
	}
}
