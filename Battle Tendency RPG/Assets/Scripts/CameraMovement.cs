using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target; //wat moet de camera volgen
    public float smoothing; //hoe snel beweegt de camera naar de target
    public Vector2 maxPosition; //min en maxPosition voor max camera range zodat niet out of bound kan zien
    public Vector2 minPosition; 

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

            //clamp zodat hij niet verder kan gaan dan aangegeven values, en de min en maxposition geef je aan in Unity
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing); //plek die je hebt, waar je naartoe wilt, welke snelheid je moet gaan





        }
        
    }


}
