using UnityEngine;

public class MovingCube : MonoBehaviour
{
    [SerializeField] private float _movingSpeed;
    [SerializeField] private MovingCubeKeys _keys;

    private void Update()
    {
        var direction = Vector3.zero;

        if (Input.GetKey(_keys.LeftKey)) direction += Vector3.left;

        if (Input.GetKey(_keys.RightKey)) direction += Vector3.right;

        if (Input.GetKey(_keys.UpKey)) direction += Vector3.forward;

        if (Input.GetKey(_keys.DownKey)) direction += Vector3.back;

        var delta = direction * _movingSpeed * Time.deltaTime;
        transform.position += delta;
    }
}