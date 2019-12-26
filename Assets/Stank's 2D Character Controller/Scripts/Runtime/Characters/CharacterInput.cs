using UnityEngine;
using UnityEngine.Events;

namespace StanksTwoDCharacterController.Runtime.Characters
{
    /// <summary>
    /// Handles retrieving input from the user for user with the character motor.
    /// </summary>
    public class CharacterInput : MonoBehaviour
    {
        [SerializeField]
        private string m_HorizontalAxisName = "Horizontal";
        [SerializeField]
        private string m_VerticalAxisName = "Vertical";

        private Vector2 m_Input = Vector2.zero;
        private Vector2 m_RawInput = Vector2.zero;

        #region Properties

        /// <summary>
        /// Returns the input.
        /// </summary>
        public Vector2 Input { get { return m_Input; } }

        /// <summary>
        /// Returns the raw input.
        /// </summary>
        public Vector2 RawInput { get { return m_RawInput; } }

        #endregion

        #region Delegates

        /// <summary>
        /// Delegate responsible for providing a way to access both input and raw input.
        /// </summary>
        /// <param name="input">Input.</param>
        /// <param name="rawInput">Raw input.</param>
        public delegate void InputHandler(Vector2 input, Vector2 rawInput);

        #endregion

        #region Events

        /// <summary>
        /// Invoked when input occurs.
        /// </summary>
        public event InputHandler OnInputEvent;

        #endregion

        #region Methods

        #region Unity Methods

        protected void Update()
        {
            // Get the horizontal input.
            m_Input.x = UnityEngine.Input.GetAxis(m_HorizontalAxisName);
            m_RawInput.x = UnityEngine.Input.GetAxisRaw(m_HorizontalAxisName);

            // Get the vertical input.
            m_Input.y = UnityEngine.Input.GetAxis(m_VerticalAxisName);
            m_RawInput.y = UnityEngine.Input.GetAxisRaw(m_VerticalAxisName);

            // Attempt to invoke OnMoveEvent.
            if(UnityEngine.Input.GetButton(m_HorizontalAxisName) || UnityEngine.Input.GetButton(m_VerticalAxisName))
            {
                // Invoke event!
                OnInputEvent(m_Input, m_RawInput);
            }
        }

        #endregion

        #endregion
    }
}
