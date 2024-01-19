using OpenTK.Graphics.OpenGL4;

namespace Serche.Graphics.Core.Shaders
{
    class Shader : IDisposable
    {
        public readonly int vertexShader, fragmentShader, shaderProgram;
        private bool dispose;
        private readonly string vertexShaderSource, fragmentShaderSource;

        public Shader(string vertPath, string fragPath)
        {
            vertexShaderSource = File.ReadAllText(vertPath);
            fragmentShaderSource = File.ReadAllText(fragPath);

            vertexShader = InitShader(ShaderType.VertexShader, vertexShaderSource);
            fragmentShader = InitShader(ShaderType.FragmentShader, fragmentShaderSource);

            shaderProgram = InitProgram(vertexShader, fragmentShader);
        }

        private int InitShader(ShaderType type, string source)
        {
            int shader = GL.CreateShader(type);
            GL.ShaderSource(shader, source);
            GL.CompileShader(shader);

            GL.GetShader(fragmentShader, ShaderParameter.CompileStatus, out int success);
            if (success == 0)
            {
                string infoLog = GL.GetShaderInfoLog(success);
                Console.WriteLine(infoLog);
            }

            return shader;
        }

        private static int InitProgram(int vertexShader, int fragmentShader)
        {
            int program = GL.CreateProgram();

            GL.AttachShader(program, vertexShader);
            GL.AttachShader(program, fragmentShader);

            GL.LinkProgram(program);

            GL.GetProgram(program, GetProgramParameterName.LinkStatus, out int success);
            if (success == 0)
            {
                string infoLog = GL.GetProgramInfoLog(program);
                Console.WriteLine(infoLog);
            }
            return program;
        }

        public void Use()
        {
            GL.UseProgram(shaderProgram);
        }

        public int GetAttribLocation(string attribName)
        {
            return GL.GetAttribLocation(shaderProgram, attribName);
        }

        public void Unbind()
        {
            GL.BindVertexArray(0);
        }

        ~Shader()
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
                GL.DetachShader(shaderProgram, vertexShader);
                GL.DetachShader(shaderProgram, fragmentShader);
                GL.DeleteShader(vertexShader);
                GL.DeleteShader(fragmentShader);
                GL.DeleteProgram(shaderProgram);
                dispose = true;
            }
        }
    }
}
