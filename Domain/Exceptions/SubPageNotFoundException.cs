namespace Domain.Exceptions;

public class SubPageNotFoundException : Exception {
    public SubPageNotFoundException() : base("SubPage was not found"){
    }

    public SubPageNotFoundException(string? message) : base(message) {
    }

    public SubPageNotFoundException(string? message, Exception? innerException) : base(message, innerException) {
    }
}