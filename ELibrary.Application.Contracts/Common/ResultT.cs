using System;
using System.Collections.Generic;

namespace ELibrary.Application.Contracts.Common
{
    public class Result<T> : Result
    {
        private readonly T _value;

        protected internal Result(bool isSuccess, T value, Error error)
            : base(isSuccess, error)
        {
            _value = value;
        }

        protected internal Result(bool isSuccess, T value, List<Error> errors)
            : base(isSuccess, errors)
        {
            _value = value;
        }

        public T Value => IsSuccess
            ? _value!
            : throw new InvalidOperationException("The result is faulted therefore the value cannot be accessed");


        public static Result<T> FailWithError<T>(Error error)
        {
            return new Result<T>(false, default, error);
        }

        public static Result<T> FailWithErrors<T>(List<Error> errors)
        {
            return new Result<T>(false, default, errors);
        }

        public static Result<T> Success<T>(T response)
        {
            return new Result<T>(true, response, Error.None);
        }

        public static implicit operator Result<T>(T? value)
        {
            return Success(value);
            // cast response to Result
        }

        public static implicit operator Result<T>(Error error)
        {
            return FailWithError<T>(error);
            // cast error to Result 
        }
    }
}