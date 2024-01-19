using OpenTK.Graphics.OpenGL4;

namespace Serche.Graphics.Core.BufferObjects
{
    class VertexBuffer
    {
        private readonly int _id;
        private bool dispose;

        public VertexBuffer(List<T> nData, int nSize)
        {
            GL.GenBuffers(1, out _id);
            GL.BindBuffer(BufferTarget.ArrayBuffer, _id);
            GL.BufferData(BufferTarget.ArrayBuffer, nSize, nData.ToArray(), BufferUsageHint.StaticDraw);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            dispose = false;
        }

        public void Bind()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, _id);
        }

        public void Unbind()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

        public int ID => _id;

        ~VertexBuffer()
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
                GL.DeleteBuffer(_id);
                dispose = true;
            }
        }
    }
}