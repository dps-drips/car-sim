using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Configurable sensitivities
    [Header("Input Sensitivity")]  
    [SerializeField] private float steeringSensitivity = 1.0f;  
    [SerializeField] private float throttleSensitivity = 1.0f;  
    [SerializeField] private float brakeSensitivity = 1.0f;
    [SerializeField] private float gearSensitivity = 1.0f;

    public float GetSteering()
    {
        return Input.GetAxis("Horizontal") * steeringSensitivity;
    }

    public float GetThrottle()
    {
        return Input.GetAxis("Vertical") > 0 ? Input.GetAxis("Vertical") * throttleSensitivity : 0;
    }

    public float GetBrake()
    {
        return Input.GetAxis("Vertical") < 0 ? -Input.GetAxis("Vertical") * brakeSensitivity : 0;
    }

    public int GetGear()
    {
        // Placeholder for gear logic
        // This could be linked to additional inputs or logic for gear shifting
        return 1; // Default to 1st gear
    }
}