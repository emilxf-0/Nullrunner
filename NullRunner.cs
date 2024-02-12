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
        
        private KeyboardState _previousKeyBoardState;

        public NullRunner() 
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
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

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
