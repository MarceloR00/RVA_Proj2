using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGunRotator : MonoBehaviour
{
    [SerializeField] float rotation_velocity;
    [SerializeField] LevelManager levelManager;

    void Start() {
        // laserManager = GetComponent<LaserManager>();
    }
    
    void FixedUpdate() {
        if (levelManager == null || !levelManager.GetLaserReady()) return;
        
        transform.Rotate(0f, rotation_velocity, 0f);
    }
}
