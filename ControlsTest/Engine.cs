using ComtrolsTest.ConstructionElements.Elements;
using ControlsTest.ConstructionElements.Elements;
using ControlsTest.Drivers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Concurrent;

using System.IO;

namespace ComtrolsTest
{
    public class Engine : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Rectangle screen;
        private MouseDriver mouse;
        private KeyboardDriver keyboard;

        private ConcurrentDictionary<string, SpriteFont> fonts;
        private ConcurrentDictionary<string, Texture2D> textures;

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

            fonts = new ConcurrentDictionary<string, SpriteFont>();
            textures = new ConcurrentDictionary<string, Texture2D>();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            LoadFiles();
            bNewGame = new Button(GetFont("FontSmall"), Color.White, "New Game", GetTexture("Button"),
                new Vector2(16, 256), Color.White);
            textBox = new TextBox(GetFont("FontSmall"), Color.White, "Text Test in Box Hahahaha", GetTexture("DialogBar"),
                new Vector2(0, screen.Height - textures["DialogBar"].Height), Color.White);
            paper = new TextBox(GetFont("FontSmall"), Color.Black, "It's a paper", GetTexture("Paper"),
                new Vector2(256, 32), Color.White);

            bNewGame.Action += () => { Environment.Exit(0); };
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

        private void LoadFiles()
        {
            foreach (string path in Directory.GetDirectories(Content.RootDirectory))
            {
                string foldername = new DirectoryInfo(path).Name;

                foreach (string filePath in Directory.GetFiles(Path.Combine(Content.RootDirectory, foldername)))
                {
                    string fileName = Path.GetFileNameWithoutExtension(filePath);

                    var file = Content.Load<object>(Path.Combine(foldername, fileName));

                    switch (file)
                    {
                        case SpriteFont:
                            fonts.TryAdd(fileName, file as SpriteFont);
                            break;
                        case Texture2D:
                            textures.TryAdd(fileName, file as Texture2D);
                            break;
                    }
                }
            }
        }

        public SpriteFont GetFont(string nameFont)
        {
            return fonts[nameFont];
        }

        public Texture2D GetTexture(string nameTexture)
        {
            return textures[nameTexture];
        }
    }
}
