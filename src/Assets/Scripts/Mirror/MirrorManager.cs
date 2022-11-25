using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorManager : MonoBehaviour
{
    IMirrorObserver mirrorObserver;

    void Start() {
        GameObject laserGun = GameObject.Find("LaserGun");
        if (laserGun != null) {
            mirrorObserver = laserGun.GetComponent<IMirrorObserver>();
            return;
        }

        Debug.Log("Couldn't find Laser Gun!");
    }

    void Update() {
        VerifyMirrorTransformChanged();
    }

    void VerifyMirrorTransformChanged() {
        if (transform.hasChanged) {
            mirrorObserver.MirrorTransformChanged();
            transform.hasChanged = false;
        }
    }
}
