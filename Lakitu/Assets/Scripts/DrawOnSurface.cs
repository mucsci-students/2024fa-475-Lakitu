using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawOnSurface : MonoBehaviour
{
    public Material lineMaterial;  // Material for the line
    public float lineWidth = 0.1f; // Width of the drawn line

    private List<Vector3> points = new List<Vector3>();
    private LineRenderer currentLine;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button pressed
        {
            CreateNewLine();
        }
        else if (Input.GetMouseButton(0)) // Holding the left mouse button
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
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f; // Adjust depth if necessary
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);

        // Add only if the point is new enough to avoid redundancy
        if (points.Count == 0 || Vector3.Distance(points[points.Count - 1], worldPosition) > 0.1f)
        {
            points.Add(worldPosition);
            currentLine.positionCount = points.Count;
            currentLine.SetPosition(points.Count - 1, worldPosition);
        }
    }
}
