using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameEngine;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Color _bgColor;
    private double _time;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();

        _bgColor = Color.Black;
        _time = 0.0;
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        _time = _time + gameTime.ElapsedGameTime.TotalSeconds;
        if (_time > 2.0)
        {
            _time = 0.0;
            if (_bgColor == Color.White)
            {
                _bgColor = Color.Black;
            }
            else
            {
                _bgColor = Color.White;
            }
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(_bgColor);

        base.Draw(gameTime);
    }
}
