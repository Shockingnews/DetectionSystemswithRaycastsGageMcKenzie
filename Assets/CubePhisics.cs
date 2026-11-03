using UnityEngine;

public class CubePhisics : MonoBehaviour, IMyIntract
{
    Rigidbody _rb;

    [SerializeField]
    float force;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }



    public void MyIntract()
    {
        if (_rb == null) return;
        _rb.AddForce(Vector3.up * force);

    }
}
