using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupLaserGun : MonoBehaviour, ISetupLaser
{
    [SerializeField] private Transform startPoint;

    public Vector3 GetLaserStartPoint() {
        return startPoint.position;
    }

    public Vector3 GetLaserDirection() {
        return transform.right;
    }

    public Vector3 GetLaserEndPoint(Vector3 startPoint, Vector3 laserDiretion) {
        RaycastHit hit;

        if (Physics.Raycast(startPoint, laserDiretion, out hit)) {
            return hit.point;
        }

        return laserDiretion * 1000;
    }
}
