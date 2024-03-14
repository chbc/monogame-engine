using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameEngine;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Texture2D _coinAnimation;
    private Rectangle[] _frames;
    private int _index;
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

        _frames = new Rectangle[6]
        {
            new Rectangle(0, 0, 128, 128), new Rectangle(128, 0, 128, 128), new Rectangle(256, 0, 128, 128), 
            new Rectangle(384, 0, 128, 128), new Rectangle(512, 0, 128, 128), new Rectangle(640, 0, 128, 128)
        };
        _index = 0;
        _time = 0.0;
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _coinAnimation = Content.Load<Texture2D>("coin_animation");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        _time = _time + gameTime.ElapsedGameTime.TotalSeconds;
        if (_time > 0.1)
        {
            _time = 0.0;
            _index++;
            if (_index > 5)
            {
                _index = 0;
            }
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        
        _spriteBatch.Begin();
        _spriteBatch.Draw(_coinAnimation, new Rectangle(0, 0, 128, 128), _frames[_index], Color.White);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
