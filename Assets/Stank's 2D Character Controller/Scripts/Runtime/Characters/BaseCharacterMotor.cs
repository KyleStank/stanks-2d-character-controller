using UnityEngine;

namespace StanksTwoDCharacterController.Runtime.Characters
{
    /// <summary>
    /// Base character motor class.
    /// </summary>
    [RequireComponent(typeof(CharacterInput))]
    public abstract class BaseCharacterMotor : MonoBehaviour
    {
        [SerializeField]
        private float m_MoveSpeed = 5.0f;

        private CharacterInput m_CharacterInput = null;

        #region Properties

        /// <summary>
        /// Returns the motor movement speed.
        /// </summary>
        public float MoveSpeed { get { return m_MoveSpeed; } }

        #endregion

        #region Methods

        #region Unity Methods

        private void OnEnable()
        {
            // Subscribe to events.
            m_CharacterInput.OnInputEvent += FixRotation;
        }

        private void OnDisable()
        {
            // Unsubscribe from events.
            m_CharacterInput.OnInputEvent -= FixRotation;
        }

        private void Awake()
        {
            // Get required references.
            m_CharacterInput = GetComponent<CharacterInput>();

            // Setup!
            Setup();
        }

        private void Update()
        {
            // If the motor doesn't want to run in FixedUpdate, run it here.
            if(!UseFixedUpdate())
            {
                // Move the character!
                Move(m_CharacterInput.Input, m_CharacterInput.RawInput);
            }
        }

        private void FixedUpdate()
        {
            // If the motor doesn't want to run in Update, run it here.
            if(UseFixedUpdate())
            {
                // Move the character!
                Move(m_CharacterInput.Input, m_CharacterInput.RawInput);
            }
        }

        #endregion

        #region Abstract Methods

        /// <summary>
        /// Sets up the character motor.
        /// </summary>
        public abstract void Setup();

        /// <summary>
        /// Moves the character.
        /// </summary>
        /// <param name="input">Input.</param>
        /// <param name="rawInput">Raw input.</param>
        public abstract void Move(Vector2 input, Vector2 rawInput);

        /// <summary>
        /// Fixes the motor's rotation.
        /// </summary>
        /// <param name="input">Input.</param>
        /// <param name="rawInput">Raw input.</param>
        public abstract void FixRotation(Vector2 input, Vector2 rawInput);

        /// <summary>
        /// Returns true if the motor should run in the FixedUpdate() method. Otherwise, returns false.
        /// </summary>
        /// <returns>boolean</returns>
        public abstract bool UseFixedUpdate();

        #endregion

        #endregion
    }
}
