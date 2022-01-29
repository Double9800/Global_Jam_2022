using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRotation : MonoBehaviour
{
    //Movement values to tweak in the inspector
    public float gravity = -20;
    public LayerMask collisionMask;
    private BoxCollider2D boxCollider;
    private Vector2 velocity;
    private bool below;
    //The different origin points of the ray
    private Vector2 center, centerRight, centerLeft;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void LateUpdate()
    {
        float movementInput = Input.GetAxisRaw("Horizontal");
        velocity.y += gravity * Time.deltaTime;
        MoveCharacter(velocity * Time.deltaTime);

    }
    //Get the bounds of the box collider, and set the ray origin points accordingly
    private void UpdateRaycastOrigins()
    {
        Bounds bounds = boxCollider.bounds;

        center = new Vector2(bounds.center.x, bounds.center.y);
        centerLeft = new Vector2(bounds.min.x, bounds.center.y);
        centerRight = new Vector2(bounds.max.x, bounds.center.y);
    }

    private void MoveCharacter(Vector2 velocity)
    {
        UpdateRaycastOrigins();
        bool wasGrounded = below;
        below = false;
    
        CollideVertically(ref velocity, wasGrounded);
        CollideVerticallyDirection(ref velocity, wasGrounded);
        //transform.Translate(velocity);
    }

    private void CollideVertically(ref Vector2 deltaMovement, bool wasGrounded)
    {
        float directionY = Mathf.Sign(deltaMovement.y);
        ;// float rayLength = (wasGrounded) ? 5 : Mathf.Abs(deltaMovement.y) + boxCollider.size.y * .5f;
        float rayLength = 4f;

        Vector2 rayOrigin = (Mathf.Sign(deltaMovement.x) == -1) ? centerLeft : centerRight;
        rayOrigin.x += deltaMovement.x;
        //Unity says the y coordinates of both of these points are the same
        //print(center);
        //print(centerLeft);
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, transform.up * directionY, rayLength, collisionMask);
        Debug.DrawRay(rayOrigin, transform.up * directionY * rayLength, Color.red);

        if (hit)
        {
            float collisionAngle = Vector2.Angle(hit.normal, Vector2.up);
            float currentRotation = transform.eulerAngles.z;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, collisionAngle));

            deltaMovement.y = (hit.distance - boxCollider.size.y * .5f) * directionY;
            velocity.y = 0; //This stops the character from accumulating gravity when grounded
            below = true;
        }
    }
    private void CollideVerticallyDirection(ref Vector2 deltaMovement, bool wasGrounded)
    {
        float directionY = Mathf.Sign(deltaMovement.y);
        ;// float rayLength = (wasGrounded) ? 5 : Mathf.Abs(deltaMovement.y) + boxCollider.size.y * .5f;
        float rayLength = 4f;

        Vector2 rayOrigin = (Mathf.Sign(deltaMovement.x) == 1) ? centerLeft : centerRight;
        rayOrigin.x += deltaMovement.x;
        //Unity says the y coordinates of both of these points are the same
        //print(center);
        //print(centerLeft);
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, transform.up * directionY, rayLength, collisionMask);
        Debug.DrawRay(rayOrigin, transform.up * directionY * rayLength, Color.red);

        if (hit)
        {
            float collisionAngle = Vector2.Angle(hit.normal, Vector2.up);
            float currentRotation = transform.eulerAngles.z;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, -collisionAngle));

            deltaMovement.y = (hit.distance - boxCollider.size.y * .5f) * directionY;
            velocity.y = 0; //This stops the character from accumulating gravity when grounded
            below = true;
        }
    }
}
