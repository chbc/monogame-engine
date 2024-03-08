using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameEngine;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private SpriteFont _font;
    private string _timeText;

    private double _time;
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
        _time = 0.0;
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _font = Content.Load<SpriteFont>("impact32");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        _timeText = string.Format("Tempo: {0}", gameTime.ElapsedGameTime.TotalSeconds);
        

        _time = _time + gameTime.ElapsedGameTime.TotalSeconds;


        if (_time > 3.0)
        {
            _time = 0.0;
            if (_bgColor == Color.LightBlue)
            {
                _bgColor = Color.DarkBlue;
            }
            else
            {
                _bgColor = Color.LightBlue;
            }
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(_bgColor);
        
        _spriteBatch.Begin();
        _spriteBatch.DrawString(_font, _timeText, Vector2.Zero, Color.Black);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
