using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float _movementSpeed;

    [SerializeField]
    private float _waypointDistanceThreshhold;

    [SerializeField]
    private List<Transform> _waypointTransforms;

    private Vector3[] _waypoints;

    private int _currentWaypointIndex;
    private float _flipForward;
    private float _flipBack;

    private void Awake()
    {
        var count = _waypointTransforms.Count;
        _waypoints = new Vector3[count];
        for (int i = 0; i < count; i++)
        {
            _waypoints[i] = _waypointTransforms[i].position;
        }

        var scale = transform.localScale;
        _flipBack = -scale.x;
        _flipForward = scale.x;

        SetFlip();
    }

    private void Update()
    {
        var currentWaypoint = _waypoints[_currentWaypointIndex];
        if (Vector3.Distance(transform.position, currentWaypoint) < _waypointDistanceThreshhold)
        {
            _currentWaypointIndex = (++_currentWaypointIndex) % _waypoints.Length;
            currentWaypoint = _waypoints[_currentWaypointIndex];

            SetFlip();
        }

        var translation = Vector3.MoveTowards(transform.position, currentWaypoint, _movementSpeed * Time.deltaTime);
        translation.y = transform.position.y;
        transform.position = translation;
    }

    private void SetFlip()
    {
        var currentWaypoint = _waypoints[_currentWaypointIndex];

        var scale = transform.localScale;
        scale.x = currentWaypoint.x > transform.position.x ? _flipBack : _flipForward;
        transform.localScale = scale;
    }
}