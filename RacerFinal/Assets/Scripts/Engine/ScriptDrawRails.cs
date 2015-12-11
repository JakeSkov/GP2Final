using UnityEngine;
using System.Collections;

public class ScriptDrawRails : MonoBehaviour
{
    public ScriptSetup drawSetup;

    public Color leftColor = Color.blue;
    public Color middleColor = Color.red;
    public Color rightColor = Color.green;

    private Color laneColor;

    public void OnDrawGizmos()
    {
        Vector3 startPoint = drawSetup.waypoints[0].startPoint.transform.position;
        //Cycles through the array of waypoints drawing a line/curve between each waypoint
        foreach (ScriptWaypoint wp in drawSetup.waypoints)
        {
 
            switch (wp.moveType)
            {
                case MovementTypes.BEZIER_CURVE:
                    Gizmos.color = laneColor;

                    Vector3 curveStart = startPoint;

                    //Creates and displays the gizmo
                    for (int i = 1; i <= 30; i++)
                    {
                        Vector3 lineEnd = GetPoint(curveStart, wp.endPoint.transform.position,
                            wp.curvePoint.transform.position, i / 30f);

                        Gizmos.DrawLine(startPoint, lineEnd);

                        startPoint = lineEnd;
                    }
                    break;
                case MovementTypes.STRAIGHT_LINE:
                    Gizmos.color = laneColor;

                    Vector3 start = startPoint;
                    Vector3 endPoint = wp.endPoint.transform.position;

                    Gizmos.DrawLine(start, endPoint);
                    break;
            }

            switch (wp.lane)
            {
                case Lane.LEFT:
                    laneColor = leftColor;
                    break;

                case Lane.MIDDLE:
                    laneColor = middleColor;
                    break;

                case Lane.RIGHT:
                    laneColor = rightColor;
                    break;
            }
        }
    }

    //@Ref Tiffany Fisher
    public Vector3 GetPoint(Vector3 start, Vector3 end, Vector3 curve, float t)
    {
        t = Mathf.Clamp01(t);
        float oneMinusT = 1f - t;
        return oneMinusT * oneMinusT * start + 2f * oneMinusT * t * curve + t * t * end;
    }
}
