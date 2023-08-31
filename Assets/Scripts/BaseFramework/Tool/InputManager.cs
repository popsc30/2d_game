using UnityEngine;

public class InputManager : BaseManager<InputManager>
{

    private bool isStart = false;
    public InputManager()
    {
        MonoManager.Instance.AddUpdateListener(MyUpdate);
    }

    public void StartOrEndCheck(bool isOpen)
    {
        isStart = isOpen;
    }

    private void CheckKeyCode(KeyCode key)
    {
        if (Input.GetKeyDown(key))
            EventCenter.Instance.EventTrigger("SomeKeyDown", key);
        if (Input.GetKeyUp(key))
            EventCenter.Instance.EventTrigger("SomeKeyUp", key);
    }

    private void MyUpdate()
    {
        if (!isStart)
            return;
        EventCenter.Instance.EventTrigger("Horizontal", Input.GetAxis("Horizontal"));
        EventCenter.Instance.EventTrigger("Vertical", Input.GetAxis("Vertical"));
        CheckKeyCode(KeyCode.J);
        CheckKeyCode(KeyCode.K);
        CheckKeyCode(KeyCode.L);
        CheckKeyCode(KeyCode.Space);
    }
	
}
