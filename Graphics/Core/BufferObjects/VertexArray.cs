using OpenTK.Graphics.OpenGL4;

namespace Serche.Graphics.Core.BufferObjects
{
    class VertexArray
    {
        private readonly int _handle;
        //private bool _dispose;

        public VertexArray(int index, int size, bool normalized, int stride, int offset)
        {
            GL.GenVertexArrays(1, out _handle);
            Bind();
            LinkAttrib(index, size, normalized, stride, offset);
            Unbind();
            //_dispose = false;
        }

        public void LinkAttrib(int index, int size, bool normalized, int stride, int offset)
        {
            GL.VertexAttribPointer(index, size, VertexAttribPointerType.Float, normalized, stride, offset);
            GL.EnableVertexAttribArray(index);
        }

        public void Bind()
        {
            GL.BindVertexArray(_handle);
        }

        public void Unbind()
        {
            GL.BindVertexArray(0);
        }

        /* 
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
            if (!_dispose)
            {
                GL.DeleteVertexArray(_handle);
                _dispose = true;
            }
        }
        */
    }
}
