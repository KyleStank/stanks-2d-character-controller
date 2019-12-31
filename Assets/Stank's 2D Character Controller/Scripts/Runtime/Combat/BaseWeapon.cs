using UnityEngine;

using StanksTwoDCharacterController.Runtime.Characters;

namespace StanksTwoDCharacterController.Runtime.Combat
{
    /// <summary>
    /// Base weapon class.
    /// </summary>
    public abstract class BaseWeapon : MonoBehaviour
    {
        private CharacterInput m_CharacterInput = null;

        #region Methods

        #region Unity Methods

        private void Awake()
        {
            // Find the character input.
            m_CharacterInput = GetComponentInParent<CharacterInput>();
        }

        private void Update()
        {
            HandleRotation();
        }

        #endregion

        #region Abstract Methods

        /// <summary>
        /// Handles the weapon's rotation.
        /// </summary>
        public abstract void HandleRotation();

        #endregion

        #endregion
    }
}
