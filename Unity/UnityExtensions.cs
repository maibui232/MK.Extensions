namespace MK.Extensions
{
    using UnityEngine;

    public static class UnityExtensions
    {
        public static void DontDestroyOnLoad(this Object gameObject)
        {
            Object.DontDestroyOnLoad(gameObject);
        }

        public static Sprite ToSprite(this Texture2D texture, float pivotX = 0.5f, float pivotY = 0.5f)
        {
            return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(pivotX, pivotY));
        }
    }
}