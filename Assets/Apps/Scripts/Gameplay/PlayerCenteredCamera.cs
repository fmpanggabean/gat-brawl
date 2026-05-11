using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCenteredCamera : MonoBehaviour
{
    private PlayerManager _playerManager;
    [SerializeField] private List<GameObject> _playerInputs = new List<GameObject>();

    private void Awake()
    {
        _playerManager = FindAnyObjectByType<PlayerManager>();

        _playerManager.OnPlayerAdded += OnPlayerAdded;
    }

    private void Update()
    {
        transform.position = GetCenteredPosition();
    }

    private Vector3 GetCenteredPosition()
    {
        Vector3 centeredPosition = new Vector3();

        foreach (GameObject player in _playerInputs)
        {
            centeredPosition.x += player.transform.position.x;
            centeredPosition.y += player.transform.position.y;
            centeredPosition.z += player.transform.position.z;
        }
        
        centeredPosition.x /= _playerInputs.Count;
        centeredPosition.y /= _playerInputs.Count;
        centeredPosition.z /= _playerInputs.Count;
        
        return centeredPosition;
    }

    public void OnPlayerAdded(GameObject  player)
    {
        _playerInputs.Add(player);
    }

    public void OnPlayerRemoved()
    {
        
    }
}
