using System.Collections.Generic;

namespace ELibrary.Application.Contracts.Common
{
    public class Result
    {
        private static readonly Error MissingErrors = Error.None; // + Missing first?

        // + Is Validation Result (?) 
        private readonly List<Error> _errors;


        protected Result(bool isSuccess, Error error)
        {
            /*
            if (isSuccess && error != Error.None)
            {
                throw new InvalidOperationException();
            }

            if (!isSuccess && error == Error.None)
            {
                throw new InvalidOperationException();
            }
            */

            IsSuccess = isSuccess;
            _errors = new List<Error> {error};
        }

        protected Result(bool isSuccess, List<Error> errors)
        {
            _errors = errors;
            IsSuccess = isSuccess;
        }

        public bool IsSuccess { get; }

        public Error FirstError
        {
            get
            {
                if (IsSuccess) return MissingErrors;

                return _errors[0];
            }
        }

        public List<Error> Errors => IsFailure ? _errors! : new List<Error> {MissingErrors};
        public bool IsFailure => !IsSuccess;


        public static Result Fail(Error error)
        {
            return new Result(false, error);
        }

        public static Result Fail(List<Error> errors)
        {
            return new Result(false, errors);
        }


        public static Result Success()
        {
            return new Result(true, Error.None);
        }
    }
}