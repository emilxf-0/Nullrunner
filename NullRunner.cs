using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace NullRunner 
{
    public class NullRunner : Game 
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GameState _gameState;
        private GameScreen _gameScreen;


        private KeyboardState _previousKeyBoardState;

        public NullRunner() 
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
        }

        protected override void Initialize() 
        {
            // TODO: Add your initialization logic here

            _previousKeyBoardState = Keyboard.GetState();

            base.Initialize();
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
            
            _spriteBatch.Begin();
            
            
            DrawRectangle(_gameScreen.RunnerZone, Color.WhiteSmoke);
            DrawRectangle(_gameScreen.GripZone, _gameScreen.RunnerColor);
            
            DrawRectangle(_gameScreen.CorpZone, Color.Black);
            DrawRectangle(_gameScreen.HQZone, _gameScreen.CorpColor);

            _spriteBatch.End();

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
