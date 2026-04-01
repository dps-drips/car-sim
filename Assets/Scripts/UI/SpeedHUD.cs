using UnityEngine;
using UnityEngine.UI;

public class SpeedHUD : MonoBehaviour
{
    public Text speedText;
    public Text rpmText;
    public Text gearText;
    public Text telemetryText;

    private float speed;
    private float rpm;
    private int gear;

    void Update()
    {
        // Here, you would typically get the values from your car's physics
        speed = GetSpeed();  // Replace with actual method to get speed
        rpm = GetRPM();      // Replace with actual method to get RPM
        gear = GetGear();    // Replace with actual method to get gear

        UpdateHUD();
    }

    void UpdateHUD()
    {
        speedText.text = "Speed: " + speed.ToString("F1") + " km/h";
        rpmText.text = "RPM: " + rpm.ToString();
        gearText.text = "Gear: " + gear.ToString();
        telemetryText.text = "Telemetry: Speed: " + speed.ToString("F1") + " km/h, RPM: " + rpm.ToString() + ", Gear: " + gear.ToString();
    }

    // Stub methods for getting data
    float GetSpeed()
    {
        return Random.Range(0f, 200f); // Replace with actual speed data acquisition
    }

    float GetRPM()
    {
        return Random.Range(0f, 7000f); // Replace with actual RPM data acquisition
    }

    int GetGear()
    {
        return Random.Range(1, 6); // Replace with actual gear data acquisition
    }
}