using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ControlsTest.Drivers
{
    internal class MouseDriver
    {

        private MouseState previosMouseState;
        private MouseState mouseState = new MouseState();
        private Rectangle rectMouse;


        public void UpdateState(GameWindow gameWindow)
        {
            previosMouseState = mouseState;
            mouseState = Mouse.GetState(gameWindow);

            rectMouse = new Rectangle(mouseState.Position, new Point(1, 1));
        }

        public Rectangle GetCursor()
        {
            return rectMouse;
        }

        public bool LeftClick()
        {
            if (mouseState.LeftButton == ButtonState.Pressed && previosMouseState.LeftButton == ButtonState.Pressed)
            {
                return true;
            }

            return false;
        }

    }
}
