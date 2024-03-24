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
            (Globals.SCREEN_WIDTH - IMAGE_WIDTH)/2, Globals.SCREEN_HEIGHT - IMAGE_HEIGHT,
            IMAGE_WIDTH, IMAGE_HEIGHT
        );
    }

    public void Update(float deltaTime)
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

        if (direction != Vector2.Zero)
        {
            direction.Normalize();
            _position.X = _position.X + (int)(direction.X * SPEED * deltaTime);
            _position.Y = _position.Y + (int)(direction.Y * SPEED * deltaTime);
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_images[_index], _position, Color.White);
    }
}
