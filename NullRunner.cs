using System;
using System.Diagnostics;
using Gum.DataTypes;
using Gum.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameGum.GueDeriving;
using RenderingLibrary;
using System.Linq;
using Gum.Wireframe;
using GumRuntime;

namespace NullRunner 
{
    public class NullRunner : Game 
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GameState _gameState;
        private GameScreen _gameScreen;
        private UiManager _uiManager;
        private KeyboardState _previousKeyBoardState;

        public NullRunner() 
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
        }

        protected override void Initialize() 
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            SystemManagers.Default = new SystemManagers(); 
            _uiManager = new UiManager();
            SystemManagers.Default.Initialize(_graphics.GraphicsDevice, fullInstantiation: true);
            _previousKeyBoardState = Keyboard.GetState();
            _uiManager.Init();
        }

        protected override void LoadContent()
        {
            _gameState = new GameState();
            _gameScreen = new GameScreen();
            _gameState.DrawStartingHands(5);

            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime) 
        {
            SystemManagers.Default?.Activity(gameTime.ElapsedGameTime.TotalSeconds);
            _uiManager.Update();


            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Debug.WriteLine("bye bye");
                Exit();
            }

            KeyboardState state = Keyboard.GetState();
            
            // draw a card from the corp deck when pressing the C key
            if (Keyboard.GetState().IsKeyDown(Keys.C) && _previousKeyBoardState.IsKeyUp(Keys.C))
            {

                Card card = _gameState.CorpDeck.DrawCard();
                if (card != null)
                {
                    _gameState.CorpHand.Add(card);
                    //print the card name to the console
                    Debug.WriteLine(card.Name);
                }
                else { }

            }
            
            _previousKeyBoardState = state;

            // draw a card from the runner deck
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                Card card = _gameState.RunnerDeck.DrawCard();
                if (card != null)
                {
                    _gameState.RunnerHand.Add(card);
                    //print the card name to the console
                    Debug.WriteLine(card.Name);
                }
                else
                {
                    Debug.WriteLine("Fuck");
                }
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) 
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            SystemManagers.Default?.Draw();
            //_spriteBatch.Begin();


            ////DrawRectangle(_gameScreen.RunnerZone, Color.WhiteSmoke);
            //DrawRectangle(_gameScreen.GripZone, _gameScreen.RunnerColor);
            //DrawRectangle(_gameScreen.HeapZone, _gameScreen.RunnerColor);

            //DrawRectangle(_gameScreen.CorpZone, Color.Black);
            //DrawRectangle(_gameScreen.HQZone, _gameScreen.CorpColor);

            //_spriteBatch.End();

            base.Draw(gameTime);
        }

        private void DrawRectangle(Rectangle rectangle, Color color)
        {
            Texture2D pixelTexture = new Texture2D(GraphicsDevice, 1, 1);
            pixelTexture.SetData(new[] {Color.White});

            _spriteBatch.Draw(pixelTexture, new Vector2(rectangle.X, rectangle.Y), rectangle, color);
        }
    }
}
