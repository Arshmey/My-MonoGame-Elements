using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ComtrolsTest.Elements
{
    internal abstract class AbstractTextElement : AbstractElement
    {
        private protected SpriteFont font;
        private protected Vector2 locateText;
        private protected Color textColor;
        private protected Vector2 scale;
        private protected Vector2 calibrate;
        public string text;


        public AbstractTextElement(SpriteFont font, Color textColor, string text, Texture2D texture, Vector2 locate, Color elementColor)
            : base(texture, locate, elementColor)
        {
            this.font = font;
            this.textColor = textColor;
            this.text = text;
        }

        private protected void ScaleForText(string textObserve, Vector2 scaleStandart)
        {
            Vector2 measure = font.MeasureString(textObserve);
            if (texture.Width < measure.X || texture.Height < measure.Y)
            {
                scale = measure / new Vector2(texture.Width, texture.Height);
            }
            else { scale = scaleStandart; }

            locateText = locate + (measure / calibrate);
        }
    }
}
