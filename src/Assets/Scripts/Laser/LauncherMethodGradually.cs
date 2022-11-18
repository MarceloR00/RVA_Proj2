using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherMethodGradually : MonoBehaviour, ILauncherMethod
{
    [SerializeField] private float timePerUnit = 0.2f;

    LineRenderer lineRenderer;

    Vector3 startPoint;
    Vector3 endPoint;

    float totalTime;
    float startTime;

    void Awake() {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void Launch(Vector3 startPoint, Vector3 endPoint, LaserManager laserManager) {
        this.startPoint = startPoint;
        this.endPoint = endPoint;

        StartCoroutine(LaunchCoroutine(laserManager));
    }

    IEnumerator LaunchCoroutine(LaserManager laserManager) {
        Setup();

        while (true) {
            if (GoToNextPoint()) {
                break;
            }

            yield return null;
        }

        laserManager.NotifyTarget();
    }

    void Setup() {
        float distance = Mathf.Sqrt(Mathf.Pow(startPoint.x - endPoint.x, 2) + Mathf.Pow(startPoint.z - endPoint.z, 2));
        totalTime = timePerUnit * distance;

        startTime = Time.time;

        lineRenderer.SetPosition(0, startPoint);
    }

    bool GoToNextPoint() {
        float elapsedTime = Time.time - startTime;
        float factor = elapsedTime / totalTime;

        Vector3 currentEndPoint = Vector3.Lerp(startPoint, endPoint, factor);

        lineRenderer.SetPosition(1, currentEndPoint);
    
        return currentEndPoint == endPoint;
    }
}
