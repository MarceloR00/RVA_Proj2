using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherMethodGradually : MonoBehaviour, ILauncherMethod
{
    [SerializeField] private float timePerUnit = 0.2f;

    LineRenderer lineRenderer;

    void Start() {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void Launch(Vector3 startPoint, Vector3 endPoint) {
        StartCoroutine(LaunchCoroutine(startPoint, endPoint));
    }

    IEnumerator LaunchCoroutine(Vector3 startPoint, Vector3 endPoint) {
        lineRenderer.SetPosition(0, startPoint);

        float distance = Mathf.Sqrt(Mathf.Pow(startPoint.x - endPoint.x, 2) + Mathf.Pow(startPoint.z - endPoint.z, 2));
        float totalTime = timePerUnit * distance;

        float startTime = Time.time;

        while (true) {
            float elapsedTime = Time.time - startTime;
            float factor = elapsedTime / totalTime;

            Vector3 currentEndPoint = Vector3.Lerp(startPoint, endPoint, factor);

            lineRenderer.SetPosition(1, currentEndPoint);

            if (currentEndPoint == endPoint) {
                break;
            }

            yield return null;
        }
    }
}