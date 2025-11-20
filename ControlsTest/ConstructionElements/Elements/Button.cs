using ComtrolsTest.Elements;
using ControlsTest.Drivers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace ComtrolsTest.ConstructionElements.Elements
{
    internal class Button : AbstractTextElement
    {
        private Action action;
        public event Action Action { add { action = value; } remove { action -= value; } }

        public Button(SpriteFont font, Color textColor, string text, Texture2D texture, Vector2 locate, Color elementColor)
            : base(font, textColor, text, texture, locate, elementColor)
        {
            calibrate = new Vector2(7, 4);
            ScaleForText(text, new Vector2(0.6f));
        }

        public override void FocusAndAction(MouseDriver mouse)
        {
            if (IsCollision(mouse.GetCursor()) && !IsFocused)
            {
                IsFocused = true;
            }
            else if (!IsCollision(mouse.GetCursor()) && IsFocused)
            {
                IsFocused = false;
            }

            if (IsFocused && mouse.LeftClick() && action is not null)
            {
                action.Invoke();
            }
        }

        public override bool IsCollision(Rectangle rectOther)
        {
            bool collisionX = fullRectangle.X < rectOther.X + rectOther.Width
                && fullRectangle.X + (fullRectangle.Width * scale.Length()) > rectOther.X;

            bool collisionY = fullRectangle.Y < rectOther.Y + rectOther.Height
                && fullRectangle.Y + (fullRectangle.Height * scale.Length()) > rectOther.Y;

            return collisionX && collisionY;
        }

        public override void GetDraw(SpriteBatch spriteBatch)
        {
            if (!IsFocused)
            {
                spriteBatch.Draw(texture, locate, null, elementColor, 0f, Vector2.Zero, scale.Length(), 0, 0f);
                spriteBatch.DrawString(font, text, locateText, textColor);
            }
            else
            {
                spriteBatch.Draw(texture, locate, null, new Color(elementColor.ToVector3() / 2), 0f, Vector2.Zero, scale.Length(), 0, 0f);
                spriteBatch.DrawString(font, text, locateText, textColor);
            }
        }
    }
}
