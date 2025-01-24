using UnityEngine;

public class Movement : MonoBehaviour
{
    public float radius = 5f; // Radio del c�rculo
    public float moveSpeed = 5f; // Velocidad de movimiento angular (grados por segundo)

    private Rigidbody _rb;
    private float currentAngle = 0f; // �ngulo actual en grados

    private void Start()
    {
        // Obt�n el Rigidbody
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        currentAngle += GetInput() * moveSpeed * Time.deltaTime;

        // Mant�n el �ngulo dentro de 0-360 grados
        currentAngle %= 360f;

        // Convierte el �ngulo a radianes
        float radians = currentAngle * Mathf.Deg2Rad;

        // Calcula la nueva posici�n en el c�rculo en el plano X-Y
        float x = Mathf.Cos(radians) * radius;
        float y = Mathf.Sin(radians) * radius;

        // Calcula la nueva posici�n en 3D y aplica al Rigidbody
        Vector3 newPosition = new Vector3(x, y, transform.position.z); // Mantener la componente Z original
        _rb.MovePosition(newPosition);
    }

    private int GetInput ()
    {
        int input = 0;

        if (Input.GetKey(KeyCode.A))
            input--;

        if (Input.GetKey(KeyCode.D))
            input++;

        return input;
    }

}
