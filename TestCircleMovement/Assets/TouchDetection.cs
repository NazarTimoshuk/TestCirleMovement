using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchDetection : MonoBehaviour
{
    private Camera mainCamera;

    private Queue<Vector3> queuePosition = new Queue<Vector3>();
    private void Start()
    {
        mainCamera = Camera.main;
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Vector3 touchPosition = touch.position;

                Ray ray = mainCamera.ScreenPointToRay(touchPosition);

                RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
                if (hit.collider != null && !EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                {
                    queuePosition.Enqueue(hit.point);
                }
            }
        }
    }
    public Vector3 DequeuePosition()
    {
        return queuePosition.Dequeue();
    }
    public int GetQueueCount()
    {
        return queuePosition.Count;
    }
}
