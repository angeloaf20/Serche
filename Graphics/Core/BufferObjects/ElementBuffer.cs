using OpenTK.Graphics.OpenGL4;

namespace Serche.Rendering.Core.BufferObjects
{
    class ElementBuffer<T> : IDisposable where T : struct
    {
        private readonly int ID;
        private bool dispose;

        public ElementBuffer(List<T> nData, int nSize)
        {
            GL.GenBuffers(1, out ID);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ID);
            GL.BufferData(BufferTarget.ElementArrayBuffer, nSize, nData.ToArray(), BufferUsageHint.StaticDraw);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);

            dispose = false;
        }

        public void Bind()
        {
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ID);
        }

        public void Unbind()
        {
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
        }

        ~ElementBuffer()
        {
            Console.WriteLine("Resource leak! Did you forget to call Dispose()?");
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!dispose)
            {
                GL.DeleteBuffer(ID);
                dispose = true;
            }
        }
    }
}