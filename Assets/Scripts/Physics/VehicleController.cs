using UnityEngine;

public class VehicleController : MonoBehaviour {
    // Vehicle parameters
    public float weight = 1500f; // kg
    public float enginePower = 200f; // HP
    public float dragCoefficient = 0.3f;
    public float tireGrip = 1.0f; // Coefficient of friction

    // Suspension parameters
    public float suspensionTravel = 0.2f; // meters
    public float suspensionStiffness = 50000f; // N/m

    private Rigidbody rb;
    private float currentSpeed;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        HandleMovement();
        HandleSuspension();
    }

    void HandleMovement() {
        float throttle = Input.GetAxis("Vertical"); // Accelerate/Decelerate
        float steering = Input.GetAxis("Horizontal"); // Steer left/right

        // Calculate forces
        float engineForce = (enginePower * 745.7f) / (currentSpeed + 1); // Convert HP to N
        engineForce = throttle > 0 ? engineForce * throttle : -engineForce * (1 - throttle);

        // Apply engine force
        rb.AddForce(transform.forward * engineForce);

        // Update current speed
        currentSpeed = rb.velocity.magnitude;

        // Apply drag force
        Vector3 dragForce = -rb.velocity.normalized * dragCoefficient * currentSpeed * currentSpeed;
        rb.AddForce(dragForce);

        // Steering
        if (steering != 0) {
            rb.AddTorque(transform.up * steering * 10f);
        }
    }

    void HandleSuspension() {
        // Simple suspension simulation (to be expanded)
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, suspensionTravel)) {
            float compression = suspensionTravel - hit.distance;
            float springForce = compression * suspensionStiffness;
            rb.AddForceAtPosition(-transform.up * springForce, hit.point);
        }
    }
}