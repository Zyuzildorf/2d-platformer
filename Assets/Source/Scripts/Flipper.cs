using UnityEngine;

public class Flipper : MonoBehaviour
{
    private float _rotateAngle = 180;
    private bool _isRotatedToRight = false;
    private bool _isRotatedToLeft = false;
    
    public void Flip(float direction)
    {
        if (Mathf.Sign(direction) > 0 && _isRotatedToRight == false)
        {
            transform.RotateAround(transform.position, Vector3.up, _rotateAngle);
            _isRotatedToRight = true;
            _isRotatedToLeft = false;
        }
        else if(Mathf.Sign(direction) < 0 && _isRotatedToLeft == false)
        {
            transform.RotateAround(transform.position, Vector3.up, -_rotateAngle);
            _isRotatedToLeft = true;
            _isRotatedToRight = false;
        }
    }
}