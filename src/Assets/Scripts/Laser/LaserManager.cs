using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserManager : MonoBehaviour
{
    bool start = false;

    public GameObject laser;
    public Transform startPoint;
    public Transform directionPoint;
    Vector3 direction;

    LineRenderer lineRenderer;
    List<Vector3> laserIndices;
    Plane laserPlane;

    GameObject target = null;

    void Start() {
        lineRenderer = laser.GetComponent<LineRenderer>();
        laserIndices = new List<Vector3>();
    }

    void Update() {
        LaunchLaser();
    }

    public void TurnOnLaserGun() {
        start = true;
        LaunchLaser();
    }

    public void TurnOffLaserGun() {
        start = false;
        RemoveLaser();
    }

    void LaunchLaser() {
        laserPlane = new Plane(transform.up, startPoint.position);

        direction = laserPlane.ClosestPointOnPlane(directionPoint.position) - laserPlane.ClosestPointOnPlane(startPoint.position);
        
        UpdateLaser();
    }

    void UpdateLaser() {
        if (!start) return;

        target = null;

        RemoveLaser();
        ComputeLaserIndices(startPoint.position, direction);
        UpdateLaserIndices();

        NotifyTarget();
    }

    void RemoveLaser() {
        lineRenderer.positionCount = 0;
        laserIndices.Clear();
    }

    void UpdateLaserIndices() {
        lineRenderer.positionCount = laserIndices.Count;
        for (int i = 0; i < laserIndices.Count; i++) {
            lineRenderer.SetPosition(i, laserIndices[i]);
        }
    }

    void ComputeLaserIndices(Vector3 startPoint, Vector3 direction) {
        laserIndices.Add(startPoint);

        RaycastHit hit;
        if (Physics.Raycast(startPoint, direction, out hit)) {
            CollidedWithObject(hit, direction);
        }
        else {
            NotCollidedWithObject(startPoint, direction);
        }
    }

    void CollidedWithObject(RaycastHit hit, Vector3 direction) {
        if (hit.collider.gameObject.tag == "Mirror") {
            CollidedWithMirror(hit, direction);
        }
        else {
            if (hit.collider.gameObject.tag == "Target") {
                target = hit.collider.gameObject;
            }

            laserIndices.Add(hit.point);
        }

    }

    void CollidedWithMirror(RaycastHit hit, Vector3 direction) {
        Vector3 nextStartPoint = hit.point;
        Vector3 nextStartDirection = laserPlane.ClosestPointOnPlane(nextStartPoint + Vector3.Reflect(direction, hit.normal)) - nextStartPoint;

        ComputeLaserIndices(nextStartPoint, nextStartDirection);
    }

    void NotCollidedWithObject(Vector3 pos, Vector3 direction) {
        laserIndices.Add(pos + direction * 100);
    }

    void NotifyTarget() {
        if (target == null) return;

        TargetManager targetManager = target.transform.parent.GetComponent<TargetManager>();
        if (targetManager != null) {
            targetManager.LaserHit();
        }
    }
}
