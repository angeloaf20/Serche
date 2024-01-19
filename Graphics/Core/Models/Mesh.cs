using Serche.Graphics.Core.BufferObjects;

namespace Serche.Graphics.Core.Models
{
    class Mesh
    {
        //private BufferManager _bufferManager;

        private Vertex[] _vertices;

        private uint[] _indices;

        public Mesh(Vertex[] vertices, uint[] indices)
        {
            _vertices = vertices;
            _indices = indices;

            //BufferManager.Instance.CreateVertexBuffers();
        }

        private float[] FlattenVertices(Vertex[] verts)
        {
            return new float[] { };
        }
    }
}
