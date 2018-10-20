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
	[SerializeField] private int _hp = 50;
	[SerializeField] private float _targetCorrectionTimer = 20f;
	[SerializeField] private float _attackTimer = 1f;
	[SerializeField] private int _attackAmount = 5;
	[SerializeField] private EnemyAttack _attacker;
	[SerializeField] private float _maxDistance = 50f;
	[SerializeField] private float _rotateReactionTime = 2f;

	private float _currentAttackTimer;
	private float _currentTimer;
	private float _currentRotationTimer = 0f;
	private bool _rotationTimerStarted = false;
	[SerializeField] private float _attackDistance = 2;
	[SerializeField]
	private List<AudioClip> _walkSounds = new List<AudioClip>();
	[SerializeField]
	private List<AudioClip> _attackSounds = new List<AudioClip>();
	[SerializeField]
	private List<AudioClip> _woundSounds = new List<AudioClip>();
	[SerializeField]
	private List<AudioClip> _deathSounds = new List<AudioClip>();
	private GameObject _player;
	private NavMeshAgent _agent;
	[SerializeField]
	private AudioSource _audioSource;
	[SerializeField]
	private AudioSource _walkAudio;
	private bool _isWalking;
	private float _walkSoundDelay;
	
	private void Awake()
	{
		_currentTimer = _targetCorrectionTimer;
		_currentAttackTimer = _attackTimer;
		_agent = GetComponent<NavMeshAgent>();
		_agent.stoppingDistance = _attackDistance;
		_player = GameObject.FindGameObjectWithTag("Player");
		_walkSoundDelay = 1 / _agent.speed;
		StartCoroutine(PlayFootSound());
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
		var distCoef = dist / _maxDistance;
		var currentUpdateTimer = distCoef * _targetCorrectionTimer;
		Attack(_attacker.IsPlayerVisible);
		var dist2 = Vector3.Distance(_agent.destination, transform.position);
		_isWalking = dist2 > _attackDistance*2;
		if (
			dist < _attackDistance 
			&& !_attacker.IsPlayerVisible)
		{
			if (!_rotationTimerStarted)
			{
				_currentRotationTimer = 0f;
				_rotationTimerStarted = true;	
			}
		}
		else
		{
			_rotationTimerStarted = false;
		}
		if (_rotationTimerStarted)
		{
			_currentRotationTimer += Time.deltaTime;
			if (_currentRotationTimer >= _rotateReactionTime)
			{
				transform.Rotate(Vector3.up, 5f);	
			}
		}
		if (dist > _attackDistance)
		{
			MoveToPlayer(currentUpdateTimer);
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
			if (_currentAttackTimer >= _attackTimer)
			{
				_currentAttackTimer = 0;
				EventManager.AddDamageToPlayer(_attackAmount);		
			}
		}
		_currentAttackTimer += Time.deltaTime;
	}
	
	public IEnumerator PlayFootSound()
	{

		while (true)
		{

			if (_isWalking)
			{
				AudioManager.PlaySound(_walkAudio, _walkSounds);
			}
			else
			{
				_walkAudio.Stop();
			}

			yield return new WaitForSeconds(_walkSoundDelay * 2);
		}

	}

}	

}
