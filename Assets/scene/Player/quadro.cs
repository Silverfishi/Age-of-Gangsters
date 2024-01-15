using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quadro : MonoBehaviour
{
    public Material lineMaterial; 
    public GameObject selectionPrefab; // Префаб для отображения 3D квадрата
    public float selectionHeight = 2.0f; // Высота 3D квадрата
    public LayerMask interactableLayer; // Слой объектов, с которыми будет взаимодействовать прямоугольник

    private LineRenderer lineRenderer;
    private Vector3 startMousePosition;
    private Vector3 endMousePosition;
    private Camera mainCamera;

    public List<GameObject> selectedObjects = new List<GameObject>();
    
    
    private GameObject currentSelection;

    void Start()
    {
        mainCamera = Camera.main;
        CreateLineRenderer();
    }

    void CreateLineRenderer()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = lineMaterial;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.positionCount = 5;
        lineRenderer.enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startMousePosition = Input.mousePosition;
        }
        if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.LeftControl))
        {
            
            // Бросок луча из точки нажатия мыши
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Проверка столкновения луча с объектом
            if (Physics.Raycast(ray, out hit))
            {
                // Добавление объекта в список
                GameObject hitObject = hit.collider.gameObject;
                
                
                   selectedObjects.Add(hitObject);
            }
        }
        if (Input.GetMouseButton(0))
        {
            endMousePosition = Input.mousePosition;

            // Отрисовываем 2D прямоугольник на экране
            DrawRectangle(startMousePosition, endMousePosition);

            // Пускаем лучи от начальной и конечной точек
            Ray startRay = mainCamera.ScreenPointToRay(startMousePosition);
            Ray endRay = mainCamera.ScreenPointToRay(endMousePosition);

            // Находим плоскость, в которой находятся объекты (например, плоскость земли)
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

            // Находим точки пересечения лучей с плоскостью
            float startRayDistance, endRayDistance;
            if (groundPlane.Raycast(startRay, out startRayDistance) && groundPlane.Raycast(endRay, out endRayDistance))
            {
                Vector3 startPoint = startRay.GetPoint(startRayDistance);
                Vector3 endPoint = endRay.GetPoint(endRayDistance);

                // Отрисовываем 3D прямоугольник в пространстве
                DrawRectangleInSpace(startPoint, endPoint);

             
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            // Выводим информацию о выбранных объектах
            foreach (GameObject selectedObject in selectedObjects)
            {
                Debug.Log("Selected object: " + selectedObject.name);
            }

            // Очищаем список выбранных объектов
            
            GameObject triggerObject = GameObject.FindGameObjectWithTag("Triger");
            trigger list = triggerObject.GetComponent<trigger>();

            // Отключаем отрисовку 2D прямоугольника
            lineRenderer.enabled = false;
            selectedObjects = list.listplayer;
          
            foreach (GameObject o in selectedObjects)
            {
                Debug.Log(o.name);
            }
              Debug.Log("ы");
           Destroy(currentSelection);  

        }
    }

    void DrawRectangle(Vector3 start, Vector3 end)
    {
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, new Vector3(end.x, start.y, start.z));
        lineRenderer.SetPosition(2, end);
        lineRenderer.SetPosition(3, new Vector3(start.x, end.y, start.z));
        lineRenderer.SetPosition(4, start);

        lineRenderer.enabled = true;
    }

    void DrawRectangleInSpace(Vector3 start, Vector3 end)
    {
        if (currentSelection == null)
        {
            // Создаем префаб 3D прямоугольника
            currentSelection = Instantiate(selectionPrefab, Vector3.zero, Quaternion.identity);
        }

        // Располагаем префаб 3D прямоугольника между начальной и конечной точкой
        currentSelection.transform.position = (start + end) / 2f;
        currentSelection.transform.localScale = new Vector3(Mathf.Abs(end.x - start.x), selectionHeight, Mathf.Abs(end.z - start.z));
    }

   
    
}