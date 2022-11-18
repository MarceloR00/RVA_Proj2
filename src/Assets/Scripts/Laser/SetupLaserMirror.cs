using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupLaserMirror : MonoBehaviour, ISetupLaser
{
    private Vector3 startPoint;
    private Vector3 direction;

    public void SetLaserStartPoint(Vector3 startPoint) {
        this.startPoint = startPoint;
    }

    public void SetLaserDirection(Vector3 direction) {
        this.direction = direction;
    }

    public Vector3 GetLaserStartPoint() {
        return startPoint;
    }

    public Vector3 GetLaserDirection() {
        return direction;
    }
}
