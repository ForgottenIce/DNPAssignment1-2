namespace Domain.Exceptions;

public class SubPageNotFoundException : Exception {
    public SubPageNotFoundException() {
    }

    public SubPageNotFoundException(string? message) : base(message) {
    }

    public SubPageNotFoundException(string? message, Exception? innerException) : base(message, innerException) {
    }
}