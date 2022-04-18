using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayerScript : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    private Vector3 _distanceFromPlayer;

    void Start()
    {
        _distanceFromPlayer = _player.transform.position - gameObject.transform.position;
    }

    void Update()
    {
        transform.position = _player.transform.position - _distanceFromPlayer;
    }
}
