using System.Collections.Generic;
using UnityEngine;


public class FixedPoint : MonoBehaviour
{
    [SerializeField] FreeBall ballMovement;
    [SerializeField] List<FixedPoint> ConnectedPoint;

    private void Awake()
    {
        ballMovement.SetFixedPoint(this);
    }

    public List<FixedPoint> GetConnectors()
    {
        return ConnectedPoint;
    }
    public void SetConnectors(List<FixedPoint> fixedPoints)
    {
        ConnectedPoint = fixedPoints;
    }
    public FreeBall GetFreeBall()
    {
        return ballMovement;
    }
    public void UpdatePointAndBall(FreeBall freeBall)
    {
        ballMovement = freeBall;
        ballMovement.SetFixedPoint(this);
    }

    
}
