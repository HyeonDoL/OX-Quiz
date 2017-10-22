using UnityEngine;

public class DrawBox : MonoBehaviour
{
    [SerializeField]
    private bool isWireFrame = true;

    [SerializeField]
    private Color boxColor = Color.yellow;

    private void OnDrawGizmos()
    {
        Gizmos.color = boxColor;

        if(isWireFrame)
            Gizmos.DrawWireCube(this.transform.position, this.transform.localScale);

        else
            Gizmos.DrawCube(this.transform.position, this.transform.localScale);
    }
}