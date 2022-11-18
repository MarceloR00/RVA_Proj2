using UnityEngine;

public interface ILaserReceiver {
    void ReceiveLaser(Vector3 hitPoint, Vector3 laserDirection);
}