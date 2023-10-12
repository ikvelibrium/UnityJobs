using UnityEngine;
using UnityEngine.Jobs;
using Unity.Jobs;
public struct Spiner : IJobParallelForTransform
{
    public float Speed;

    public void Execute(int index, TransformAccess transform)
    {
        float radius = Vector3.Distance(new Vector3(0, 5.5f, 0), transform.position);
        float angle = Mathf.Atan2(transform.position.z, transform.position.x) + Speed;
        transform.position = new Vector3(radius * Mathf.Cos(angle), 5.5f, radius * Mathf.Sin(angle));
    }

   
}
