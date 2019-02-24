using System;
namespace Searthtone.Exceptions
{
    public class FaceNullException : Exception
    {
        public FaceNullException() : base("Face Null")
        {
        }

        public FaceNullException(string message) : base(message)
        {
        }
    }
}
