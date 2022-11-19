using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupLaserGun : MonoBehaviour, ISetupLaser
{
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform directionPoint;

    public Vector3 GetLaserStartPoint() {
        return startPoint.position;
    }

    public Vector3 GetLaserDirection() {
        return (directionPoint.position - startPoint.position).normalized;
    }
}
