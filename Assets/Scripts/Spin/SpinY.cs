using UnityEngine;

public class SpinY : MonoBehaviour
{
    public float rotationSpeed;

    public GameObject pivotObject;

   
    void Update()
    {
        transform.RotateAround(pivotObject.transform.position, new Vector3(1, -1, 1), rotationSpeed * Time.deltaTime);
    }
}
