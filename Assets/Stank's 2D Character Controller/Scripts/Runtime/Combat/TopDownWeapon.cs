using UnityEngine;

using StankUtilities.Runtime.Utilities;

namespace StanksTwoDCharacterController.Runtime.Combat
{
    public class TopDownWeapon : BaseWeapon
    {
        [SerializeField]
        [Range(0.0f, 1.0f)]
        private float m_AxisThreshold = 0.2f;

        private Vector3 m_Angle = Vector3.zero;

        #region Methods

        #region Override Methods

        /// <summary>
        /// Ensures that the weapon points towards the mouse cusor and/or direction of axis.
        /// </summary>
        public override void HandleRotation()
        {
            // Retrieve axis input.
            float horizontalAim = Input.GetAxis("HorizontalAim");
            float verticalAim = Input.GetAxis("VerticalAim");

            // If the axises are used at all, calculate the angle.
            if(Mathf.Abs(horizontalAim) > m_AxisThreshold || Mathf.Abs(verticalAim) > m_AxisThreshold)
            {
                // Get the angle based on the horizontal aim.
                m_Angle.z = Mathf.Acos(horizontalAim) * Mathf.Rad2Deg;

                // If we are aiming up, subtract ninety degrees.
                if(verticalAim >= 0.0f)
                {
                    m_Angle.z -= 90.0f;
                }
                else // Otherwise, add ninety degrees and multiply the result by -1.
                {
                    m_Angle.z = -(m_Angle.z + 90.0f);
                }
            }
            else // Otherwise, use the mouse position.
            {
                // Convert cursor position into a world point.
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));

                // Calculate angle for weapon to look at cursor.
                m_Angle = MathUtility.GetLookAtAngle(transform.position, mousePos, transform.forward);
            }

            // Rotate the weapon.
            transform.localEulerAngles = m_Angle;
        }

        public override void Use()
        {
            Debug.Log("Use!");
        }

        #endregion

        #endregion
    }
}
