using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float MovementSpeed = 5f;

    public Rigidbody2D rigidbody2D;
    public Weapon weapon;
    private Vector2 inputVector;
    private Vector2 mousePosition;

    private void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 aimDirection = (mousePosition - rigidbody2D.position).normalized;
            weapon.Fire(aimDirection);
        }
        Vector2 weaponRotate = (mousePosition - rigidbody2D.position).normalized;
        float angle = Mathf.Atan2(weaponRotate.y, weaponRotate.x) * Mathf.Rad2Deg;
        weapon.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        inputVector = new Vector2(moveX, moveY).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(inputVector.x * MovementSpeed, inputVector.y * MovementSpeed);

        /* Vector2 aimPosition = mousePosition - rigidbody2D.position;
         float aimAngle = Mathf.Atan2(aimPosition.y, aimPosition.x) * Mathf.Rad2Deg - 90f;*/
    }
}