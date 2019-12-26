using UnityEngine;

namespace StanksTwoDCharacterController.Runtime.Characters
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class TopDownCharacterMotor : BaseCharacterMotor
    {
        [SerializeField]
        private bool m_IsFacingRight = false;

        private Rigidbody2D m_Rigidbody2D = null;

        private Vector2 m_Velocity = Vector2.zero;
        private Vector3 m_OriginalScale = Vector3.zero;
        private Vector3 m_NewScale = Vector3.zero;

        #region Methods

        #region Override Methods

        /// <summary>
        /// Set up the motor.
        /// </summary>
        public override void Setup()
        {
            // Grab rigidbody.
            m_Rigidbody2D = GetComponent<Rigidbody2D>();

            // Set rigidbody to Kinematic.
            m_Rigidbody2D.bodyType = RigidbodyType2D.Kinematic;

            // Set rotation constraint.
            m_Rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;

            // Set the original scale.
            m_OriginalScale = transform.localScale;
            m_NewScale = m_OriginalScale;
        }

        /// <summary>
        /// Moves the character.
        /// </summary>
        /// <param name="input">Input.</param>
        /// <param name="rawInput">Raw input.</param>
        public override void Move(Vector2 input, Vector2 rawInput)
        {
            // Set velocity values.
            m_Velocity.x = rawInput.x * MoveSpeed;
            m_Velocity.y = rawInput.y * MoveSpeed;

            // Assign new velocity to rigidbody.
            m_Rigidbody2D.velocity = m_Velocity;
        }

        /// <summary>
        /// Fixes the character's rotation based on input.
        /// </summary>
        /// <param name="input">Input.</param>
        /// <param name="rawInput">Raw input.</param>
        public override void FixRotation(Vector2 input, Vector2 rawInput)
        {
            if(rawInput.x > 0)
            {
                // If the character is originally facing right, set the rotation back to its default state.
                // Otherwise, flip the rotation.
                m_NewScale.x = m_IsFacingRight ? m_OriginalScale.x : m_OriginalScale.x * -1.0f;
            }
            else
            {
                // If the character is originally facing right, flip the rotation.
                // Otherwise, set the rotation back to its default state.
                m_NewScale.x = m_IsFacingRight ? m_OriginalScale.x * -1.0f : m_OriginalScale.x;
            }

            // Set new scale.
            transform.localScale = m_NewScale;
        }

        /// <summary>
        /// Always returns true.
        /// </summary>
        /// <returns>boolean</returns>
        public override bool UseFixedUpdate()
        {
            return true;
        }

        #endregion

        #endregion
    }
}
