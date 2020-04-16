using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{

    [SerializeField]
    Vector2 MovementArea;

    Camera Camera;

    void Start()
    {
        Camera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
        void Update()
        {
            var targetPosition = (Vector2)Camera.ScreenToWorldPoint(Input.mousePosition);

            targetPosition.x = Mathf.Clamp(targetPosition.x, -MovementArea.x, MovementArea.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, -MovementArea.y, MovementArea.y);

            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5f);
        }
   
}
