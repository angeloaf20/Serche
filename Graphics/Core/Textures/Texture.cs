using OpenTK.Graphics.OpenGL4;
using StbImageSharp;

namespace Serche.Rendering.Core.Textures
{
    class Texture : IDisposable
    {
        private int _textureHandle;
        private bool _disposed = false;

        public Texture(string texPath)
        {
            LoadTexture(texPath);
        }

        public void Bind()
        {
            GL.BindTexture(TextureTarget.Texture2D, _textureHandle);
        }

        public void Unbind()
        {
            GL.BindTexture(TextureTarget.Texture2D, 0);
        }

        private void LoadTexture(string texPath)
        {
            GL.GenTextures(1, out _textureHandle);

            Bind();

            StbImage.stbi_set_flip_vertically_on_load(1);

            ImageResult img = ImageResult.FromStream(File.OpenRead(texPath), ColorComponents.RedGreenBlueAlpha);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, img.Width, img.Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, img.Data);

            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            Unbind();
        }

        public void Use(TextureUnit unit)
        {
            GL.ActiveTexture(unit);
            GL.BindTexture(TextureTarget.Texture2D, _textureHandle);
        }

        ~Texture()
        {
            if (!_disposed)
                Console.WriteLine("GPU Resource leak! Did you forget to call Dispose()?");
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
