using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.Rendering
{
    /// <summary>
    /// Utility Free Camera component.
    /// </summary>
    [ExecuteAlways]
    public class FreeCamera : MonoBehaviour
    {
        /// <summary>
        /// Rotation speed when using the mouse.
        /// </summary>
        public float m_LookSpeedMouse = 10.0f;

        private static string kMouseX = "Mouse X";
        private static string kMouseY = "Mouse Y";

        void Update()
        {
            float inputRotateAxisX = 0.0f;
            float inputRotateAxisY = 0.0f;
            if (Input.GetButton("Fire1"))
            {
                inputRotateAxisX = Input.GetAxis(kMouseX) * m_LookSpeedMouse;
                inputRotateAxisY = Input.GetAxis(kMouseY) * m_LookSpeedMouse;
            }

            bool moved = inputRotateAxisX != 0.0f || inputRotateAxisY != 0.0f;
            if (moved)
            {
                float rotationX = transform.localEulerAngles.x;
                float newRotationY = transform.localEulerAngles.y + inputRotateAxisX;

                // Weird clamping code due to weird Euler angle mapping...
                float newRotationX = (rotationX - inputRotateAxisY);
                if (rotationX <= 90.0f && newRotationX >= 0.0f)
                    newRotationX = Mathf.Clamp(newRotationX, 0.0f, 90.0f);
                if (rotationX >= 270.0f)
                    newRotationX = Mathf.Clamp(newRotationX, 270.0f, 360.0f);

                transform.localRotation = Quaternion.Euler(newRotationX, newRotationY, transform.localEulerAngles.z);
            }
        }
    }
}
