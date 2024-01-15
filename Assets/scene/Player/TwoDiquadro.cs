using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TwoDiquadro : MonoBehaviour
{
    public Image Frameimage;
    private Vector2 _frameStart;
    private Vector2 _frameEnd;
    private Vector3 initialPosition;
    private float currentZoomDistance;
    public float zoomSpeed = 5f;
    public float panSpeed = 0.1f;  // Скорость перемещения при удержании колеса мыши
    public float panUpDownSpeed = 0.1f;  // Скорость вертикального перемещения
    public float panForwardBackwardSpeed = 0.1f;  // Скорость перемещения вперед/назад
    public float minYPosition = 2f;  
    public float maxYPosition = 10f;
    public Transform position;

    void Start()
    {
        SetCameraParent();
        SaveInitialPosition();
    }

    void SetCameraParent()
    {
        Camera mainCamera = Camera.main;

        if (mainCamera != null)
        {
            transform.parent = position;
        }
        else
        {
            Debug.LogError("Main camera not found!");
        }
    }

    void SaveInitialPosition()
    {
        initialPosition = transform.parent.position;
        currentZoomDistance = Vector3.Distance(transform.position, transform.parent.position);
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            _frameStart = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Frameimage.enabled = true;
            _frameEnd = Input.mousePosition;
            Vector2 min = Vector2.Min(_frameEnd, _frameStart);
            Vector2 max = Vector2.Max(_frameEnd, _frameStart);
            Frameimage.rectTransform.anchoredPosition = min;
            Vector2 size = max - min;
            Frameimage.rectTransform.sizeDelta = size;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Frameimage.enabled = false;
        }

        float scrollWheelInput = Input.GetAxis("Mouse ScrollWheel");

        if (Mathf.Abs(scrollWheelInput) > 0.01f)
        {
            ZoomCamera(scrollWheelInput);
        }

        if (Input.GetMouseButton(2))  // Проверяем, что нажата средняя кнопка мыши (колесо)
        
        {
            float panInputX = Input.GetAxis("Mouse X") * panSpeed;
            float panInputZ = Input.GetAxis("Mouse Y") * panForwardBackwardSpeed;  // Изменено на panInputZ
            PanCamera(panInputX, 0, panInputZ);
        }

        // Добавляем перемещение вперед/назад при нажатии клавиш вверх и вниз
        float forwardBackwardInput = Input.GetAxis("Vertical") * panUpDownSpeed;
        PanForwardBackward(forwardBackwardInput);
    }

    void PanCamera(float panInputX, float panInputY, float panInputZ)
    {
        if (transform.parent == null)
        {
            Debug.LogError("Parent object is not set for the camera.");
            return;
        }

        Vector3 panDirection = transform.parent.TransformDirection(new Vector3(panInputX, panInputY, panInputZ));
        transform.parent.position += panDirection;
    }

    void PanForwardBackward(float forwardBackwardInput)
    {
        if (transform.parent == null)
        {
            Debug.LogError("Parent object is not set for the camera.");
            return;
        }

        Vector3 forwardBackwardDirection = transform.parent.TransformDirection(new Vector3(0, 0, forwardBackwardInput));
        transform.parent.position += forwardBackwardDirection;
    }

    void ZoomCamera(float scrollInput)
    {
        SaveInitialPosition();
        if (transform.parent == null)
        {
            Debug.LogError("Parent object is not set for the camera.");
            return;
        }

        float newYPosition = Mathf.Clamp(transform.parent.position.y - scrollInput * zoomSpeed, minYPosition, maxYPosition);

        // Обновляем текущее расстояние от камеры до цели
        currentZoomDistance = Vector3.Distance(transform.position, transform.parent.position);

        transform.parent.position = new Vector3(initialPosition.x, newYPosition, initialPosition.z);
    }
}