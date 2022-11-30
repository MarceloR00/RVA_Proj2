using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserManager : MonoBehaviour, IMirrorObserver
{
    bool start = false;

    public GameObject laser;
    public Transform startPoint;
    public Transform directionPoint;
    Vector3 direction;

    LineRenderer lineRenderer;
    List<Vector3> laserIndices;

    void Start() {
        lineRenderer = laser.GetComponent<LineRenderer>();
        laserIndices = new List<Vector3>();
    }

    public void LaunchLaser() {
        start = true;
        direction = (directionPoint.position - startPoint.position).normalized;
        
        UpdateLaser();
    }

    public void MirrorTransformChanged() {
        UpdateLaser();
    }

    void UpdateLaser() {
        if (!start) return;

        RemoveLaser();
        ComputeLaserIndices(startPoint.position, direction);
        UpdateLaserIndices();
    }

    public void RemoveLaser() {
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
            NotCollidedWithObject(direction);
        }
    }

    void CollidedWithObject(RaycastHit hit, Vector3 direction) {
        if (hit.collider.gameObject.tag == "Mirror") {
            CollidedWithMirror(hit, direction);
        }
        else {
            laserIndices.Add(hit.point);
        }

    }

    void CollidedWithMirror(RaycastHit hit, Vector3 direction) {
        Vector3 nextStartPoint = hit.point;
        Vector3 nextStartDirection = Vector3.Reflect(direction, hit.normal);

        ComputeLaserIndices(nextStartPoint, nextStartDirection);
    }

    void NotCollidedWithObject(Vector3 direction) {
        laserIndices.Add(direction * 100);
    }
}
