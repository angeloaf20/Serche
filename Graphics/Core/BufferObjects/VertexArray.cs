using OpenTK.Graphics.OpenGL4;

namespace Serche.Graphics.Core.BufferObjects
{
    class VertexArray : IDisposable
    {
        private readonly int handle;
        private bool dispose;

        public VertexArray()
        {
            GL.GenVertexArrays(1, out handle);
            dispose = false;
        }

        public void LinkAttrib(VertexBuffer VB, int index, int size, VertexAttribPointerType type, bool normalized, int stride, int offset)
        {
            VB.Bind();
            GL.VertexAttribPointer(index, size, type, normalized, stride, offset);
            GL.EnableVertexAttribArray(index);
            VB.Unbind();
        }

        public void Bind()
        {
            GL.BindVertexArray(handle);
        }

        public void Unbind()
        {
            GL.BindVertexArray(0);
        }

        ~VertexArray()
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
                GL.DeleteVertexArray(handle);
                dispose = true;
            }
        }
    }
}
