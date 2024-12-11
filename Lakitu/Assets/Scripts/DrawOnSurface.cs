using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DrawOnSurfaceWithRange : MonoBehaviour
{
    public Material lineMaterial;        // Material for the line
    public float lineWidth = 0.1f;       // Width of the drawn line
    public LayerMask drawingSurface;     // Layer to restrict drawing to a specific surface
    public Transform player;             // Reference point for range (e.g., player)
    public float drawingRange = 5f;      // Maximum drawing range from the player

    private List<Vector3> points = new List<Vector3>();
    private LineRenderer currentLine;
    private Camera mainCamera;

    public bool CanDraw { get; set; } = true;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (!CanDraw)
        {
            return;
        }

        // Ignore drawing if the mouse is over a UI element
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (Input.GetMouseButtonDown(0)) // Start drawing
        {
            CreateNewLine();
        }
        else if (Input.GetMouseButton(0)) // Continue drawing
        {
            AddPointToLine();
        }
    }

    void CreateNewLine()
    {
        GameObject lineObject = new GameObject("Line");
        currentLine = lineObject.AddComponent<LineRenderer>();
        currentLine.material = lineMaterial;
        currentLine.startWidth = lineWidth;
        currentLine.endWidth = lineWidth;
        currentLine.positionCount = 0;
        points.Clear();
    }

    void AddPointToLine()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        // Ignore the UI layer if set on LayerMask
        int layerMask = ~LayerMask.GetMask("UI");

        if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, drawingSurface & layerMask))
        {
            Vector3 hitPoint = hitInfo.point;

            // Check if the hit point is within the drawing range
            if (Vector3.Distance(player.position, hitPoint) <= drawingRange)
            {
                // Only add point if it's sufficiently far from the last point
                if (points.Count == 0 || Vector3.Distance(points[points.Count - 1], hitPoint) > 0.1f)
                {
                    points.Add(hitPoint);
                    currentLine.positionCount = points.Count;
                    currentLine.SetPosition(points.Count - 1, hitPoint);
                }
            }
        }
    }
}
