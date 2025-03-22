using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    
    public bool OnSpacebarPressed { get; private set; }
    public float Direction { get; private set; }
    
    private void Update()
    {
        CheckKeyboardinput();
        CheckSpaceBarInput();
    }

    private void CheckKeyboardinput()
    {
        Direction = Input.GetAxis(Horizontal);
    }

    private void CheckSpaceBarInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnSpacebarPressed = true;
        }
        else
        {
            OnSpacebarPressed = false;
        }
    }
}