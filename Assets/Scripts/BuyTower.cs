using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuyTower : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase towerTile;
    public float circleRadius = 3f;
    public Color circleColor = Color.red;

    private List<GameObject> circles = new List<GameObject>();

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cellPos = tilemap.WorldToCell(mouseWorldPos);
            tilemap.SetTile(cellPos, towerTile);
            DrawCircle(tilemap.GetCellCenterWorld(cellPos));
        }
    }

    void DrawCircle(Vector3 center)
    {
        GameObject circleObj = new GameObject("Circle");
        LineRenderer circleRenderer = circleObj.AddComponent<LineRenderer>();
        circleRenderer.positionCount = 101;
        circleRenderer.startWidth = 0.1f;
        circleRenderer.endWidth = 0.1f;
        circleRenderer.loop = true;
        circleRenderer.useWorldSpace = false;
        circleRenderer.material = new Material(Shader.Find("Sprites/Default"));
        circleRenderer.startColor = circleColor;
        circleRenderer.endColor = circleColor;

        circles.Add(circleObj);

        Vector3[] points = new Vector3[101];
        float angleStep = 360f / 101;
        for (int i = 0; i <= 100; i++)
        {
            float angle = i * angleStep;
            float x = center.x + circleRadius * Mathf.Cos(Mathf.Deg2Rad * angle);
            float y = center.y + circleRadius * Mathf.Sin(Mathf.Deg2Rad * angle);
            points[i] = new Vector3(x, y, center.z);
        }
        circleRenderer.SetPositions(points);
    }
}
