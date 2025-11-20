using ComtrolsTest.ConstructionElements.Elements;
using ControlsTest.ConstructionElements.Elements;
using ControlsTest.Drivers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace ComtrolsTest
{
    public class Engine : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Rectangle screen;
        private MouseDriver mouse;
        private KeyboardDriver keyboard;

        private Button bNewGame;
        private TextBox textBox;
        private TextBox paper;

        public Engine()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            screen = Window.ClientBounds;
            mouse = new MouseDriver();
            keyboard = new KeyboardDriver();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            SpriteFont font = Content.Load<SpriteFont>("Font");
            SpriteFont fontSmall = Content.Load<SpriteFont>("FontSmall");
            Texture2D btnTexture = Content.Load<Texture2D>("Button");
            Texture2D txtBoxTexture = Content.Load<Texture2D>("DialogBar");
            Texture2D paperTexture = Content.Load<Texture2D>("Paper");
            bNewGame = new Button(font, Color.White, "New Game", btnTexture, new Vector2(16, 256), Color.White);
            textBox = new TextBox(font, Color.White, "Text Test in Box Hahahaha", txtBoxTexture,
                new Vector2(0, screen.Height - txtBoxTexture.Height), Color.White);
            paper = new TextBox(font, Color.Black, "It's a paper", paperTexture, new Vector2(256, 32), Color.White);

            textBox.Action += () => { textBox.text = "LMAO"; };
        }

        protected override void Update(GameTime gameTime)
        {
            keyboard.CheckKeyboard();
            mouse.UpdateState(Window);

            bNewGame.FocusAndAction(mouse);
            textBox.KeyboardAction(keyboard);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            bNewGame.GetDraw(spriteBatch);
            textBox.GetDraw(spriteBatch);
            paper.GetDraw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
