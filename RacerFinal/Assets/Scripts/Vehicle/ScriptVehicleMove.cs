using UnityEngine;
using System.Collections;

public class ScriptVehicleMove : MonoBehaviour
{
    public ScriptSetup waypoints;
    public ScriptVehicleController carControl;
    public ScriptVehicleStats stats;
    public ScriptPlayerSetup setup;

    public Lane startingLane;
    public Lane currLane;

    [HideInInspector]
    public float burnTime = 0;

    // Use this for initialization
    void Start()
    {
        stats.currSpeed = 0.0001f;
        startingLane = setup.startLane;
        currLane = startingLane;
        StartCoroutine(move());
    }

    IEnumerator move()
    {
        yield return new WaitForSeconds(1f);
        foreach(ScriptWaypoint wp in waypoints.waypoints)
        {
            switch (wp.moveType)
            {
                case MovementTypes.BEZIER_CURVE:
                    if (stats.currSpeed != 0)
                    {
                        if (wp.hasBurnout)
                        {
                            StartCoroutine(burnout());
                        }

                        StartCoroutine(movementBezier(wp.endPoint.transform.position, wp.curvePoint.transform.position, (2f - stats.currSpeed)));

                        //Gets Distances
                        float distToPlayer = Vector3.Distance(wp.startPoint.transform.position, transform.position);
                        float distToEndpoint = Vector3.Distance(wp.startPoint.transform.position, wp.endPoint.transform.position);

                        //Changes Lanes
                        if (Input.GetAxis("Horizontal") != 0)
                        {
                            if (Input.GetAxis("Horizontal") > 0 && currLane != Lane.RIGHT)
                            {
                                currLane = Lane.RIGHT;
                                float newDistToEnd = Vector3.Distance(wp.startPoint.transform.position, wp.endPoint.transform.position);
                                //uses preportions to calculate the distance traveled
                                float newPos = (distToPlayer / newDistToEnd) * distToEndpoint;
                            }

                            if (Input.GetAxis("Horizontal") < 0 && currLane != Lane.LEFT)
                            {
                                currLane = Lane.LEFT;
                                float newDistToEnd = Vector3.Distance(wp.startPoint.transform.position, wp.endPoint.transform.position);
                                //uses preportions to calculate the distance traveled
                                float newPos = (distToPlayer / newDistToEnd) * distToEndpoint;
                            }
                        }

                        yield return new WaitForSeconds(1.5f - stats.currSpeed);
                    }
                    break;
            }
        }
        yield return new WaitForSeconds(2f);

        Application.LoadLevel("MenuMain");
    }

    //@Ref Tiffany Fisher
    IEnumerator movementBezier(Vector3 target, Vector3 curve, float time)
    {
        float startTime = Time.time;
        float endTime = startTime + time;

        Vector3 startCurve = transform.position;
        float elapsedTime = 0f;

        while (Time.time < endTime)
        {
            elapsedTime += Time.deltaTime;
            float curTime = elapsedTime / time;

            transform.position = GetPoint(startCurve, target, curve, curTime);
            yield return null;
        }

        transform.position = target;
    }

    void StraightMovement(int index, float time)
    {
        time = time / stats.currSpeed;

        Vector3 start = transform.position;

        Vector3.Lerp(start, waypoints.waypoints[index].endPoint.transform.position, time);
    }

    IEnumerator burnout()
    {
        float speedDif = carControl.stats.currSpeed - 0.1f;
        burnTime += ((speedDif) / 10) * 13f;

        if (GetComponent<ScriptVehicleUIController>().isDead)
        {
            stats.currSpeed = 0f;
        }
        yield return null;
    }

    //@Ref Tiffany Fisher
    public Vector3 GetPoint(Vector3 start, Vector3 end, Vector3 curve, float t)
    {
        t = Mathf.Clamp01(t);
        float oneMinusT = 1f - t;
        return oneMinusT * oneMinusT * start + 2f * oneMinusT * t * curve + t * t * end;
    }
}
