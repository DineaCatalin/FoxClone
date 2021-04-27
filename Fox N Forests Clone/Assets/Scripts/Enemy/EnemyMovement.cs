using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float _movementSpeed;

    [SerializeField]
    private float _waypointDistanceThreshhold;

    [SerializeField]
    private List<Vector3> _waypoints;

    private int _currentWaypointIndex;

    private void Start()
    {
        SetFlip();
    }

    private void Update()
    {
        var currentWaypoint = _waypoints[_currentWaypointIndex];
        if (Vector3.Distance(transform.position, currentWaypoint) < _waypointDistanceThreshhold)
        {
            _currentWaypointIndex = (++_currentWaypointIndex) % _waypoints.Count;
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
        scale.x = currentWaypoint.x > transform.position.x ? -1 : 1;
        transform.localScale = scale;
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < _waypoints.Count; i++)
        {
            Gizmos.DrawSphere(_waypoints[i], 0.35f);
        }
    }
}