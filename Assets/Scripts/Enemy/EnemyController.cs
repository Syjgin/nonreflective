using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
	public class EnemyController : MonoBehaviour
{

	public int Id;
	[SerializeField] private int _hp;
	[SerializeField] private float _targetCorrectionTimer = 5f;
	[SerializeField] private float _nearTargetCorrectionTimer = 0.5f;
	[SerializeField] private float _attackDistance = 1f;
	[SerializeField] private float _attackTimer = 1f;
	[SerializeField] private int _attackAmount = 3;
	[SerializeField] private EnemyAttack _attacker;
	
	private float _currentAttackTimer;
	private float _currentTimer;
	private GameObject _player;
	private NavMeshAgent _agent;
	
	private void Awake()
	{
		_currentTimer = _targetCorrectionTimer;
		_currentAttackTimer = _attackTimer;
		_agent = GetComponent<NavMeshAgent>();
		_player = GameObject.FindGameObjectWithTag("Player");
	}

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

	private void Update()
	{
		var dist = Vector3.Distance(transform.position, _player.transform.position);
		var reactsSlowly = !_attacker.IsPlayerVisible;
		var currentTimer =
			 reactsSlowly
				? _targetCorrectionTimer
				: _nearTargetCorrectionTimer;
		Attack(dist < _attackDistance && _attacker.IsPlayerVisible);
		if (dist > _attackDistance)
		{
			MoveToPlayer(currentTimer);
		}
		_currentTimer += Time.deltaTime;
	}

	private void MoveToPlayer(float currentTimer)
	{
		if (_currentTimer >= currentTimer)
		{
			_currentTimer = 0;
			_agent.destination = _player.transform.position;
		}
	}

	private void Attack(bool isAllowed)
	{
		if (isAllowed)
		{
			_agent.destination = transform.position;
			if (_currentAttackTimer >= _attackTimer)
			{
				_currentAttackTimer = 0;
				EventManager.AddDamageToPlayer(_attackAmount);		
			}
		}
		_currentAttackTimer += Time.deltaTime;
	}
}	

}
