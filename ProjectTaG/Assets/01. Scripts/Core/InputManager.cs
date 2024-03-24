using System.Collections.Generic;
using UnityEngine.InputSystem;

public static class InputManager
{
	public static Controls controls { get; private set; }
    private static Dictionary<InputType, InputActionMap> inputList;
    private static InputType currentInputType;

    static InputManager()
    {
        controls = new Controls();
        inputList = new Dictionary<InputType, InputActionMap>();
    }

    public static void RegistInput(InputSO inputSO, InputActionMap actionMap)
    {
        inputList[inputSO.inputType] = actionMap;
        actionMap.Disable();
    }

    public static void ChangeInput(InputType inputType)
    {
        if(inputList.ContainsKey(currentInputType))
            inputList[currentInputType]?.Disable();
        currentInputType = inputType;
        if (inputList.ContainsKey(currentInputType))
            inputList[currentInputType]?.Enable();
    }
}
