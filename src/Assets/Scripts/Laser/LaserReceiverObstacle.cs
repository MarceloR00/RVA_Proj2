using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserReceiverObstacle : MonoBehaviour, ILaserReceiver
{
    public void ReceiveLaser(Vector3 hitPoint, Vector3 laserDirection) {
        Debug.Log("Obstacle Received Laser");
    }
}
