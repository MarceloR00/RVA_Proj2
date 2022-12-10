using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    [SerializeField] Transform[] positions;
    [SerializeField] Transform start_position;
    [SerializeField] float velocity;
    [SerializeField] Animator animator;

    int current_position_index = 0;
    float time_took_between_points;
    float current_start_time_between_points;

    bool blocked = true;
    bool dead = false;

    // REMOVE
    void Start(){
        Reset();
    }

    public void Reset() {
        transform.position = start_position.position;
        current_position_index = 0;

        ComputeTimeBetweenPoints();

        blocked = false;
    }

    public void Dead() {
        dead = true;
    }

    void FixedUpdate() {
        if (blocked || dead) return;

        if (ReachedTargetPosition()) {
            StartCoroutine(Rotate());
        }
        else {
            Move();
        }
    }

    void Move() {
        
        float current_time_between_points = Time.time - current_start_time_between_points;
        float ratio = current_time_between_points / time_took_between_points;
        transform.position = Vector3.Lerp(transform.position, positions[current_position_index].position, ratio);

        animator.SetBool("Walk Forward", true);
    }

    void SetupNextMovement() {
        NextPositionIndex();
        ComputeTimeBetweenPoints();
        current_start_time_between_points = Time.time;
    }

    void NextPositionIndex() {
        current_position_index = (current_position_index + 1) % positions.Length;
    }

    void ComputeTimeBetweenPoints() {
        float distance_between_points = Vector3.Distance(transform.position, positions[current_position_index].position);
        time_took_between_points = distance_between_points * velocity;
    }

    bool ReachedTargetPosition() {
        return Vector3.Distance(transform.position, positions[current_position_index].position) < 0.5;
    }

    IEnumerator Rotate() {
        blocked = true;
        
        animator.SetBool("Walk Forward", false);
        
        animator.SetTrigger("Jump");

        yield return new WaitForSeconds(0.2f);

        if (dead) {
            yield break;
        }

        float duration = 0.42f;
        Quaternion startRotation = transform.rotation ;
        Quaternion endRotation = Quaternion.Euler( new Vector3(0, -180, 0) ) * startRotation ;
        for( float t = 0 ; t < duration ; t+= Time.deltaTime )
        {
            if (dead) {
                yield break;
            }

            transform.rotation = Quaternion.Lerp( startRotation, endRotation, t / duration ) ;
            yield return null;
        }
        transform.rotation = endRotation;
        
        yield return new WaitForSeconds(0.5f);

        if (dead) {
            yield break;
        }

        SetupNextMovement();
        
        blocked = false;

        yield return null;
    }
}
