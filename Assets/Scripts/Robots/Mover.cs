using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Robots
{
    [RequireComponent(typeof(CharacterController))]
    public class Mover : MonoBehaviour
    {
        private CharacterController characterController;
        private Vector3 motion;

        [SerializeField] private float walkspeed;

        Vector3 gravity = Vector3.down;

        private void Start()
        {
            this.characterController = this.GetComponent<CharacterController>();
        }


        public void Move(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<Vector2>();
            motion = new Vector3(value.x, 0, value.y) * walkspeed;
            Debug.Log(motion);
        }

        private void Update()
        {
            var camera_forward = Camera.main.transform.forward;
            var camera_right = Camera.main.transform.right;
            var move = camera_forward * motion.z + camera_right * motion.x;
            Debug.Log(move + " : " + motion);
            characterController.Move(move * Time.deltaTime + gravity * (Time.deltaTime));
        }
    }
}