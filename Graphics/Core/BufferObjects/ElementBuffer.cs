using OpenTK.Graphics.OpenGL4;

namespace Serche.Graphics.Core.BufferObjects
{
    class ElementBuffer
    {
        private readonly int _id;
        //private bool _dispose;

        public ElementBuffer(float[] nData)
        {
            GL.GenBuffers(1, out _id);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _id);
            GL.BufferData(BufferTarget.ElementArrayBuffer, nData.Length * sizeof(float), nData, BufferUsageHint.StaticDraw);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);

            //_dispose = false;
        }

        public void Bind()
        {
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _id);
        }

        public void Unbind()
        {
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
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