using UnityEngine;

public class MovementObjects : MonoBehaviour
{
    private Plane _plane = new Plane(Vector3.down, 0);
    private Transform _object;
    private Vector3 _worldPosition;
    private Ray _ray;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    GetObject();
                    break;

                case TouchPhase.Moved:
                    MoveObject();
                    break;

                case TouchPhase.Ended:
                    LoseObject();
                    break;
            }
        }
    }

    private void GetObject()
    {
        if (Physics.Raycast(_ray, out var hit))
        {
            if (Physics.Raycast(_ray, out hit, 100))
            {
                if (hit.transform.gameObject.CompareTag("Object"))
                {
                    _object = hit.transform;
                }
            }
        }
    }

    private void MoveObject()
    {
        if (_plane.Raycast(_ray, out float distance) && _object != null)
        {
            _worldPosition = _ray.GetPoint(distance);
            _object.position = new Vector3(_worldPosition.x, _object.position.y, _worldPosition.z);
        }
    }

    private void LoseObject()
    {
        _object = null;
    }
}
/*private Transform _object;
private Ray _ray;
private float _speed = 100;

private Vector3 worldPosition;

private Vector3 _screenPosition;
Plane _plane = new Plane(Vector3.down, 0);

private void Start()
{
}

private void Update()
{
    //Touch();

    /*_ray = Camera.main.ScreenPointToRay(Input.mousePosition);

if (Physics.Raycast(_ray, out var hit))
{
if (Physics.Raycast(_ray, out hit, 20))
{
    if (hit.transform.gameObject.CompareTag("Object"))
    {
        _object = hit.transform;
        print(_object);
    }
}
}#1#
    if (Input.GetMouseButtonUp(0))
    {
        _object = null;
    }
}

private void OnMouseDown()
{
    _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    if (Physics.Raycast(_ray, out var hit))
    {
        if (Physics.Raycast(_ray, out hit, 20))
        {
            if (hit.transform.gameObject.CompareTag("Object"))
            {
                _object = hit.transform;
                print(_object);
            }
        }
    }
}

private void OnMouseDrag()
{
    if (Input.GetMouseButton(0))
    {
        _screenPosition = Input.mousePosition;
        if (_plane.Raycast(_ray, out float distance))
        {
            worldPosition = _ray.GetPoint(distance);
            _object.position = new Vector3(worldPosition.x, _object.position.y, worldPosition.z);
        }
    }
}*/
