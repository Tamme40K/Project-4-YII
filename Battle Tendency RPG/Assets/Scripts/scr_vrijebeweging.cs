using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_vrijebeweging : MonoBehaviour
{
    public Transform player;
    public float speed = 5.0f;
    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;

    public Transform circle;
    public Transform outerCircle;

    public double minX = 0.0;
    public double maxX = 400.0;
    public double minY = 0.0;
    public double maxY = 400.0;

    //public Rect touchArea = new Rect(x, -4, 4, 4); //Rect(xMin, 0, 200, 200

    // Update is called once per frame
    void Update()
    {
        pointA = new Vector3(-7, -3, Camera.main.transform.position.z);

        if (Input.GetMouseButton(0)) 
        {
            touchStart = true;
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        else
        {
            touchStart = false;
        }
    }
    private void FixedUpdate()
    {
        if (touchStart && (
            Input.mousePosition.x < maxX &&
            Input.mousePosition.x > minX &&
            Input.mousePosition.y < maxY &&
            Input.mousePosition.y > minY))
        {
            Vector2 offset = pointB - pointA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            moveCharacter(direction);

            circle.transform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y);
        } else {
            circle.transform.position = pointA;
        }
    }
    void moveCharacter(Vector2 direction)
    {
        player.Translate(direction * speed * Time.deltaTime);
    }
}