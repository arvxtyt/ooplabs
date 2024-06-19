using System.Runtime.Serialization;

namespace BusinessLogicLayer.Services
{
    [Serializable]
    internal class RecordNotExists : Exception
    {
        private long id;

        public RecordNotExists()
        {
        }

        public RecordNotExists(long id)
        {
            this.id = id;
        }

        public RecordNotExists(string? message) : base(message)
        {
        }

        public RecordNotExists(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected RecordNotExists(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}