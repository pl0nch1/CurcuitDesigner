
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.U2D;

[ExecuteAlways]
public class Wire : MonoBehaviour
{
    [SerializeField]
    private Collider2D connectorB;

    private SplineContainer spline;
    private void Start()
    {
        spline = GetComponent<SplineContainer>();
    }

    void Update()
    {
        if (connectorB) {
            IEnumerator<BezierKnot> enumerator = spline.Spline.Knots.GetEnumerator();
            enumerator.MoveNext();
            enumerator.MoveNext();
            Vector3 knotBPosition = connectorB.transform.position - transform.position;
            BezierKnot knotB = new(knotBPosition, enumerator.Current.TangentIn, enumerator.Current.TangentOut, enumerator.Current.Rotation);
            spline.Spline.SetKnot(1, knotB);
        }
    }
}
