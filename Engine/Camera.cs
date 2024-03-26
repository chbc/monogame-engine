using Microsoft.Xna.Framework;

public static class Camera
{
    public static void Update(Vector2 playerOffset, ref Vector2 scenePosition)
    {
        scenePosition = scenePosition - playerOffset;
    }
}
