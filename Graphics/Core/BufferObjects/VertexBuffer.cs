using OpenTK.Graphics.OpenGL4;

namespace Serche.Graphics.Core.BufferObjects
{
    class VertexBuffer
    {
        private readonly int _id;
        //private bool _dispose;

        public VertexBuffer(float[] nData)
        {
            GL.GenBuffers(1, out _id);
            Bind();            
            GL.BufferData(BufferTarget.ArrayBuffer, nData.Length * sizeof(float), nData, BufferUsageHint.StaticDraw);
            Unbind();
            //_dispose = false;
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

        /*
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
            if (!_dispose)
            {
                GL.DeleteBuffer(_id);
                _dispose = true;
            }
        }
        */
    }
}