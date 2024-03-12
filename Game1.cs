using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameEngine;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Timer _timer;
    private Texture2D _coinAnimation;
    private int _index;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();

        _index = 0;
        _timer = new Timer();
        _timer.Start(ChangeAnimationFrame, 0.1, true);
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

        // TODO: Add your update logic here

        _timer.Update(gameTime.ElapsedGameTime.TotalSeconds);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        
        _spriteBatch.Begin();
        _spriteBatch.Draw(_coinAnimation, new Rectangle(0, 0, 128, 128), new Rectangle(_index * 128, 0, 128, 128), Color.White);
        _spriteBatch.End();

        base.Draw(gameTime);
    }

    private void ChangeAnimationFrame()
    {
        _index = _index > 4 ? 0 : _index + 1;
    }
}
