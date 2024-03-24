using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameEngine;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Timer _timer;
    private Color _bgColor;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();

        _bgColor = Color.LightBlue;
        _timer = new Timer();

        _timer.Start(ChangeBG, 2.0f, true);
    }

    protected override void LoadContent()
    {
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        _timer.Update((float)gameTime.ElapsedGameTime.TotalSeconds);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(_bgColor);

        base.Draw(gameTime);
    }

    private void ChangeBG()
    {
        if (_bgColor == Color.LightBlue)
        {
            _bgColor = Color.DarkBlue;
        }
        else
        {
            _bgColor = Color.LightBlue;
        }
    }
}
