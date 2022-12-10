using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{   
    [SerializeField] GameObject wall;
    [SerializeField] float velocity;
    [SerializeField] Transform min_position;
    [SerializeField] Transform max_position;
    
    int direction = -1;

    void FixedUpdate() {
        MoveWall();
    }

    void MoveWall() {
        UpdatePosition();
        UpdateDirection();
    }

    void UpdatePosition() {
        wall.transform.Translate(new Vector3(0, velocity * direction, 0));
    }

    void UpdateDirection() {
        if (wall.transform.position.y <= min_position.position.y || wall.transform.position.y >= max_position.position.y) {
            direction *= -1;
        }
    }
}
