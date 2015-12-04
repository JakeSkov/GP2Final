using UnityEngine;
using System.Collections;

public class ScriptDrawRails : MonoBehaviour 
{
    public ScriptSetup drawSetup = new ScriptSetup();

    public Color leftColor = Color.blue;
    public Color middleColor = Color.red;
    public Color rightColor = Color.green;

    private Color laneColor;

    public void OnDrawGizmos()
    {

        //Cycles through the array of waypoints drawing a line/curve between each waypoint
        for (int i = 0; i < drawSetup.waypoints.Length; i++)
        {
            switch (drawSetup.waypoints[i].moveType)
            { 
                case MovementTypes.BEZIER_CURVE:
                    TestLane(i);
                    DrawCurve(i);
                    break;
                case MovementTypes.STRAIGHT_LINE:
                    TestLane(i);
                    DrawStraight(i);
                    break;
            }
        }
    }

    //Sets up the line colors for each of the lanes
    public void TestLane(int index)
    {
        switch (drawSetup.waypoints[index].lane)
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

    //Draws the Bezier Curve
    public void DrawCurve(int index)
    {
        Gizmos.color = laneColor;

        Vector3 startPoint = drawSetup.waypoints[index].startPoint.transform.position;
        Vector3 endPoint = drawSetup.waypoints[index].endPoint.transform.position;
        Vector3 curvePoint = drawSetup.waypoints[index].curvePoint.transform.position;

        //Creates and displays the gizmo
        for (int i = 1; i <= 10; i++)
        {
            Vector3 lineEnd = GetPoint(startPoint, endPoint, curvePoint, 10);
            Gizmos.DrawLine(startPoint, lineEnd);
            startPoint = lineEnd;
        }
    }

    //@Ref Tiffany Fisher
    public Vector3 GetPoint(Vector3 start, Vector3 end, Vector3 curve, float t)
    {
        t = Mathf.Clamp01(t);
        float oneMinusT = 1f - t;
        return oneMinusT * oneMinusT * start + 2f * oneMinusT * t * curve + t * t * end;
    }

    //Draws Straight Lines
    public void DrawStraight(int index)
    {
        Gizmos.color = laneColor;

        Vector3 startPoint = drawSetup.waypoints[index].startPoint.transform.position;
        Vector3 endPoint = drawSetup.waypoints[index].endPoint.transform.position;

        Gizmos.DrawLine(startPoint, endPoint );
    }
}
