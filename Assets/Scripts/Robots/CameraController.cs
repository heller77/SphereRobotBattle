using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Robots
{
    public class CameraController : MonoBehaviour
    {
        private Vector2 rotate_value;

        public void CameraRotate(InputAction.CallbackContext context)
        {
            var rotate_value = context.ReadValue<Vector2>();
            this.rotate_value = rotate_value;
            Debug.Log(rotate_value);
        }

        private void Update()
        {
            var noweulerangle = transform.eulerAngles;
            transform.eulerAngles = new Vector3(noweulerangle.x - rotate_value.y, noweulerangle.y + rotate_value.x,
                noweulerangle.z);
        }
    }
}