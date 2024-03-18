using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameEngine;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Texture2D _bomb;
    private Vector2 _position;
    private double _speed;
    private const double ACCELERATION = 10;
    private bool _isBombDropped;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();

        _graphics.PreferredBackBufferHeight = 800;
        _graphics.ApplyChanges();

        _position = new Vector2(_graphics.PreferredBackBufferWidth / 2.0f, 0.0f);
        _speed = 0.0;
        _isBombDropped = false;
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _bomb = Content.Load<Texture2D>("bomb");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        if (Input.GetKeyDown(Keys.Space))
        {
            _position.Y = 0.0f;
            _speed = 0.0f;
            _isBombDropped = true;
        }

        if (_isBombDropped)
        {
            _speed = _speed + (ACCELERATION * gameTime.ElapsedGameTime.TotalSeconds);
            _position.Y = _position.Y + (float)_speed;
        }

        Input.Update();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        _spriteBatch.Draw(_bomb, _position, Color.White);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
