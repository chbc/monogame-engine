using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Player
{
    private Texture2D[] _images;
    private int _index;
    private Rectangle _position;
    private const float SPEED = 200;
    private const int IMAGE_WIDTH = 130;
    private const int IMAGE_HEIGHT = 130;
    private Timer _timer;
    private Rectangle _movementBounds;

    public void LoadContent(ContentManager content)
    {
        _images = new Texture2D[6]
        {
            content.Load<Texture2D>("helicopter/helicopter1"), content.Load<Texture2D>("helicopter/helicopter2"),
            content.Load<Texture2D>("helicopter/helicopter3"), content.Load<Texture2D>("helicopter/helicopter4"),
            content.Load<Texture2D>("helicopter/helicopter5"), content.Load<Texture2D>("helicopter/helicopter6")
        };
    }

    public void Initialize()
    {
        _index = 0;
        _position = new Rectangle
        (
            (Globals.SCREEN_WIDTH - IMAGE_WIDTH)/2, Globals.SCREEN_HEIGHT - (IMAGE_HEIGHT * 2),
            IMAGE_WIDTH, IMAGE_HEIGHT
        );
        _timer = new Timer();
        _timer.Start(IncrementIndex, 0.075f, true);
        _movementBounds = new Rectangle
        (
            Globals.SCREEN_WIDTH/8, Globals.SCREEN_HEIGHT/4,
            (Globals.SCREEN_WIDTH/4) * 3, (Globals.SCREEN_HEIGHT/4) * 3
        );
    }

    public Point Update(float deltaTime)
    {
        Vector2 direction = Vector2.Zero;

        if (Input.GetKey(Keys.W))
        {
            direction.Y = -1.0f;
        }
        if (Input.GetKey(Keys.S))
        {
            direction.Y = 1.0f;
        }
        if (Input.GetKey(Keys.A))
        {
            direction.X = -1.0f;
        }
        if (Input.GetKey(Keys.D))
        {
            direction.X = 1.0f;
        }

        Point result = Point.Zero;

        if (direction != Vector2.Zero)
        {
            direction.Normalize();
            result.X = (int)(direction.X * SPEED * deltaTime);
            result.Y = (int)(direction.Y * SPEED * deltaTime);

            Rectangle newPosition = _position;
            newPosition.X += result.X;
            newPosition.Y += result.Y;

            if (newPosition.X > _movementBounds.X && newPosition.Right < _movementBounds.Right)
            {
                _position.X = newPosition.X;
                result.X = 0;
            }
            if (newPosition.Y > _movementBounds.Y && newPosition.Bottom < _movementBounds.Bottom)
            {
                _position.Y = newPosition.Y;
                result.Y = 0;
            }
        }

        _timer.Update(deltaTime);

        return result;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_images[_index], _position, Color.White);
    }

    private void IncrementIndex()
    {
        _index++;
        if (_index > 5)
        {
            _index = 0;
        }
    }
}
