using System;
using ELibrary.Domain.Errors;

namespace ELibrary.Application.Contracts.Common
{
    public class Error : IEquatable<Error>
    {
        public static readonly Error None = new(string.Empty, string.Empty, ErrorTypes.Conflict);

        public static readonly Error NullValue = new("Error.NullValue", "The specified result value is null",
            ErrorTypes.NotFound);

        public Error(string code, string message, ErrorTypes errorType)
        {
            Code = code;
            Message = message;
            ErrorType = errorType;
        }

        public string Code { get; }
        public ErrorTypes ErrorType { get; }

        public string Message { get; }

        public bool Equals(Error? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Code == other.Code && Message == other.Message;
        }

        public static implicit operator string(Error error)
        {
            return error.Code;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Error) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Code, Message);
        }
    }
}