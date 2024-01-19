namespace Serche.Graphics.Core.BufferObjects
{
    class BufferManager
    {
        List<VertexArray> _vertexArrays;
        List<VertexBuffer> _vertexBuffers;
        List<ElementBuffer> _elementBuffers;

        private static BufferManager? instance = null;
        private static readonly object padlock = new object();

        public BufferManager() { }

        /// <summary>
        /// https://csharpindepth.com/articles/singleton
        /// Creates BufferManager singleton
        /// </summary>
        public static BufferManager Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new BufferManager();
                    }
                    return instance;
                }
            }
        }

        public void CreateVertexBuffers(float[] data)
        {
            VertexBuffer vbo = new VertexBuffer(data);
            _vertexBuffers.Add(vbo);
        }

        public void CreateVertexArray(int index, int size, bool normalized, int stride, int offset)
        {
            VertexArray vao = new VertexArray(index, size, normalized, stride, offset);
            _vertexArrays.Add(vao);
        }

        public List<VertexBuffer> VertexBuffers => _vertexBuffers;
        public List<VertexArray> VertexArrays => _vertexArrays;
        public List<ElementBuffer> ElementBuffers => _elementBuffers;

    }
}
