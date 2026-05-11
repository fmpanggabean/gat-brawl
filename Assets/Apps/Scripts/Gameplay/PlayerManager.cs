using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;
    private List<PlayerInput> _playerInputs = new List<PlayerInput>();

    public Action<GameObject> OnPlayerAdded;

    private void Awake()
    {
        
    }

    private void Start()
    {
        SpawnPlayer();
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        PlayerInput playerInput = PlayerInput.Instantiate(_playerPrefab, 0);
        _playerInputs.Add(playerInput);
        
        OnPlayerAdded?.Invoke(playerInput.gameObject);
    }
}
