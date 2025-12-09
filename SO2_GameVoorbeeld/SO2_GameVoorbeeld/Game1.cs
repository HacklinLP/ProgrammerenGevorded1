using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SO2_GameVoorbeeld.Extensions;
using System.Runtime.CompilerServices;

namespace SO2_GameVoorbeeld;

public class Game1 : Game
{

    private enum GameStates
    {
        StartScreen, Playing, Paused, GameOver
    }

    private GameStates _gameState;


    private const int PLAYER_STEP = 3;
    private const int BACKGROUND_STEP = 2;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Texture2D _player;
    private Texture2D _background;
    private Vector2 _playerPosition;
    private Vector2 _backgroundPosition;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _graphics.PreferredBackBufferWidth = 1080;
        _graphics.PreferredBackBufferHeight = 720;

        _graphics.ApplyChanges();


        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _player = Content.Load<Texture2D>("surfing-pikachu");
        _background = Content.Load<Texture2D>("water");


        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {

        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        if (_gameState == GameStates.StartScreen)
        {
            _gameState = GameStates.StartScreen;
            _playerPosition = new Vector2(0, 0);
            _backgroundPosition = new Vector2(0, -700);
        }
        else if (_gameState == GameStates.Playing)
        {

            if (Keyboard.GetState().IsKeyDown(Keys.D)) // Right
                _playerPosition.X += PLAYER_STEP;

            if (Keyboard.GetState().IsKeyDown(Keys.Q)) // Left
                _playerPosition.X -= PLAYER_STEP;

            if (Keyboard.GetState().IsKeyDown(Keys.S)) // Down
                _playerPosition.Y += PLAYER_STEP;

            if (Keyboard.GetState().IsKeyDown(Keys.Z)) // Up
                _playerPosition.Y -= PLAYER_STEP;
            // TODO: Add your update logic here

            _backgroundPosition.X -= BACKGROUND_STEP;

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                _gameState = GameStates.Paused;

        }
        else if (_gameState == GameStates.Paused)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                _gameState = GameStates.Playing;
        }
        else if (_gameState == GameStates.GameOver)
        {

            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                _gameState = GameStates.StartScreen;
        }
            base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        _spriteBatch.Draw(_background, _backgroundPosition);
        _spriteBatch.Draw(_player, _playerPosition);

        _spriteBatch.End();

        base.Draw(gameTime);
    }

}
