using ControlsTest.Drivers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ComtrolsTest.Elements
{
    internal abstract class AbstractElement
    {

        private protected Texture2D texture;
        private protected Vector2 locate;
        private protected Color elementColor;
        private protected bool IsFocused;

        public AbstractElement(Texture2D texture, Vector2 locate, Color elementColor)
        {
            this.texture = texture;
            this.locate = locate;
            this.elementColor = elementColor;
            IsFocused = false;
        }

        public Rectangle GetRect() => texture.Bounds;

        public Vector2 GetLocate() => locate;

        public Rectangle fullRectangle => new Rectangle(locate.ToPoint(), texture.Bounds.Size);

        public Vector2 GetCenter()
        {
            return new Vector2(locate.X + (texture.Width / 2), locate.Y + (texture.Height / 2));
        }

        public virtual void FocusAndAction(MouseDriver mouse) { }
        public virtual void KeyboardAction(KeyboardDriver keyboard) { }

        public bool IsCollision(Rectangle rectOther)
        {
            bool collisionX = fullRectangle.X < rectOther.X + rectOther.Width
                && fullRectangle.X + fullRectangle.Width > rectOther.X;

            bool collisionY = fullRectangle.Y < rectOther.Y + rectOther.Height
                && fullRectangle.Y + fullRectangle.Height > rectOther.Y;

            return collisionX && collisionY;
        }

        public abstract void GetDraw(SpriteBatch spriteBatch);


    }
}
