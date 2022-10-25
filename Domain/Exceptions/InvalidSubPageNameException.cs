namespace Domain.Exceptions {
    public class InvalidSubPageNameException : Exception {
        public InvalidSubPageNameException() {
        }

        public InvalidSubPageNameException(string message) {
        }

        public InvalidSubPageNameException(string? message, Exception? innerException) : base(message, innerException) {
        }
    }
}
