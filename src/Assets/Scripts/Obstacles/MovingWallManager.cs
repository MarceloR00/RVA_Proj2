using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWallManager : MonoBehaviour
{   
    [SerializeField] float velocity;
    [SerializeField] float max_offset;
    float min_y;
    float max_y;
    
    int direction = -1;

    void Start() {
        max_y = transform.position.y;
        min_y = transform.position.y - (transform.localScale.y * max_offset);
    }

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

        // transform.position = new Vector3(transform.position.x, new_value_y, transform.position.z);
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    void UpdateDirection() {
        if (transform.position.y == min_y || transform.position.y == max_y) {
            direction *= -1;
        }
    }
}
