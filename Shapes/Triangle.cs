/* using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using Serche.Graphics.Core.BufferObjects;
using Serche.Graphics.Core.Shaders;
using System.Runtime.CompilerServices;

namespace Serche.Shapes
{
    class Triangle
    {
        private readonly VertexBuffer<float> VertexBufferObject;
        private readonly VertexArray VertexArrayObject;
        private readonly Matrix4 model;


        private float[] positions =
            {
                -0.5f, -0.5f, 0.0f, 1.0f, 0.0f, 0.0f,//Bottom-left vertex
                 0.5f, -0.5f, 0.0f, 0.0f, 1.0f, 0.0f,//Bottom-right vertex
                 0.0f,  0.5f, 0.0f, 0.0f, 0.0f, 1.0f,  //Top vertex
            };

        private List<Vector3> vertices = new List<Vector3>();

        private List<Vector3> colors = new List<Vector3>();


        private Shader shader;

        public Triangle()
        {

            vertices = new List<Vector3>()
            { 
                new Vector3(positions[0], positions[1], positions[2]),
                new Vector3(positions[6], positions[7], positions[8]),
                new Vector3(positions[12], positions[13], positions[14]),
            };

            colors = new List<Vector3>()
            {
                new Vector3(positions[3], positions[4], positions[5]),
                new Vector3(positions[9], positions[10], positions[11]),
                new Vector3(positions[15], positions[16], positions[17]),
            };

            List<float> interleavedData = new List<float>();

            // Interleave position and color data
            for (int i = 0; i < vertices.Count; i++)
            {
                interleavedData.AddRange(new float[] {
                    vertices[i].X, vertices[i].Y, vertices[i].Z,
                    colors[i].X, colors[i].Y, colors[i].Z
                });

            }


            VertexBufferObject = new VertexBuffer<float>(interleavedData, interleavedData.Count * Unsafe.SizeOf<float>());    

            VertexArrayObject = new VertexArray();
            
            shader = new Shader("ShaderSource/vertShader.glsl", "ShaderSource/fragShader.glsl");

        }

        public List<Vector3> Vertices => vertices;
        //public List<int> Indices => _indices;
        //public List<Texture> Textures => _textures;

        public void InitData()
        {
            
            VertexArrayObject.Bind();
            VertexArrayObject.LinkAttrib(VertexBufferObject, 0, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 0);
            VertexArrayObject.LinkAttrib(VertexBufferObject, 1, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 3 * sizeof(float));
            VertexArrayObject.Unbind();
            
            shader.Use();
        }

        public void Draw()
        {
            shader.Use();
            Matrix4 model = Matrix4.Zero;



            VertexArrayObject.Bind();
            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
        }

        public void Delete()
        {
            shader.Dispose();

        }
    }
}
*/