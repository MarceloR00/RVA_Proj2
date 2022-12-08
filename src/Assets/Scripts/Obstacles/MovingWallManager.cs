using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWallManager : MonoBehaviour
{
    [SerializeField] float min_y;
    [SerializeField] float max_y;
    [SerializeField] float velocity;
    
    int direction = -1;

    void FixedUpdate() {
        MoveWall();
    }

    void MoveWall() {
        UpdatePosition();
        UpdateDirection();
    }

    void UpdatePosition() {
        float new_value_y = transform.position.y + velocity * direction;

        if (new_value_y < min_y) {
            new_value_y = min_y;
        }
        else if (new_value_y > max_y) {
            new_value_y = max_y;
        }

        transform.position = new Vector3(transform.position.x, new_value_y, transform.position.z);
    }

    void UpdateDirection() {
        if (transform.position.y == min_y || transform.position.y == max_y) {
            direction *= -1;
        }
    }
}
