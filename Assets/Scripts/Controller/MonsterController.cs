﻿using UnityEngine;

public class MonsterController : MonoBehaviour
{
    private PlayerParametersModel _player;
    private MonsterModel _enemy;
    private Animator _animator;
    private MonsterState _state;

    private float _distance;

    private void Start()
    {
        _player = FindObjectOfType<PlayerParametersModel>();
        _enemy = GetComponent<MonsterModel>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _distance = Vector3.Distance(transform.position, _player.transform.position);

        if (_distance <= _enemy.GetRangeOfView())
        {
            transform.LookAt(_player.transform);
            Moving();
        }
    }

    private void Moving()
    {
        _animator.SetBool(MonsterAnimatorStrings.Walk, true);
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _enemy.GetSpeed() * Time.deltaTime);
    }

    public void GetDamage(float damage)
    {
        _enemy.GetDamage(damage);

        _animator.SetBool(MonsterAnimatorStrings.UnderDamage, true);
    }

}
