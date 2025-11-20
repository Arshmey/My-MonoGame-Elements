using ComtrolsTest.Elements;
using ControlsTest.Drivers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace ControlsTest.ConstructionElements.Elements
{
    internal class TextBox : AbstractTextElement
    {
        private Action action;
        public event Action Action { add { action = value; } remove { action -= value; } }

        public TextBox(SpriteFont font, Color textColor, string text, Texture2D texture, Vector2 locate, Color elementColor)
            : base(font, textColor, text, texture, locate, elementColor)
        {
            calibrate = new Vector2(24, 4);
            ScaleForText(text, new Vector2(0.71f));
        }

        public override void KeyboardAction(KeyboardDriver keyboard)
        {
            if (keyboard.ForSinglKeyDown(Keys.Tab) && action is not null)
            {
                action.Invoke();
            }
        }

        public override void GetDraw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, locate, null, elementColor, 0f, Vector2.Zero, scale.Length(), 0, 0f);
            spriteBatch.DrawString(font, text, locateText, textColor);
        }
    }
}
