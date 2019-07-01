using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target; //wat moet de camera volgen
    public float smoothing; //hoe snel beweegt de camera naar de target

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }

    // LateUpdate is called last not every frame, in update kan het zijn dat je update uitvoerd voor je player beweegt
    void LateUpdate()
    {
        if (transform.position != target.position) //als me transform position niet de target position is DAN bewegen we ernaar
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing); //plek die je hebt, waar je naartoe wilt, welke snelheid je moet 
        }   
    }
}
