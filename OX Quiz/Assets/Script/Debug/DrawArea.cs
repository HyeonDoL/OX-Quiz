using UnityEngine;

public class DrawArea : MonoBehaviour
{
    [SerializeField]
    private Color drawColor = Color.yellow;

    [SerializeField]
    [Range(-50, 50)]
    private float left, right, top, bottom;

    public float GetLeft() { return left; }
    public float GetRight() { return right; }
    public float GetTop() { return top; }
    public float GetBottom() { return bottom; }

    private void OnDrawGizmos()
    {
        Gizmos.color = drawColor;

        float y = transform.position.y;

        Vector3 leftBottom = new Vector3(left, y, bottom);
        Vector3 rightBottom = new Vector3(right, y, bottom);
        Vector3 leftTop = new Vector3(left, y, top);
        Vector3 rightTop = new Vector3(right, y, top);

        Gizmos.DrawLine(leftBottom, leftTop);
        Gizmos.DrawLine(leftTop, rightTop);
        Gizmos.DrawLine(rightTop, rightBottom);
        Gizmos.DrawLine(rightBottom, leftBottom);
    }
}