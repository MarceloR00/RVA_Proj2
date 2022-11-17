using UnityEngine;

public interface ISetupLaser {
    Vector3 GetLaserStartPoint();
    Vector3 GetLaserDirection();
    Vector3 GetLaserEndPoint(Vector3 startPoint, Vector3 laserDiretion);
}