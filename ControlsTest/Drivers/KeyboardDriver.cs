using Microsoft.Xna.Framework.Input;

namespace ControlsTest.Drivers
{
    internal class KeyboardDriver
    {

        private KeyboardState previosStateKeyboard;
        private KeyboardState stateKeyboard;

        public void CheckKeyboard()
        {
            previosStateKeyboard = stateKeyboard;
            stateKeyboard = Keyboard.GetState();
        }

        public bool IsKeyDown(Keys key) => stateKeyboard.IsKeyDown(key);

        public bool ForSinglKeyDown(Keys key)
        {
            if (stateKeyboard.IsKeyDown(key) && !previosStateKeyboard.IsKeyDown(key))
            {
                return true;
            }
            return false;
        }

    }
}
