using System.Collections.Generic;

namespace ELibrary.Application.Contracts.Common
{
    public class ValidationResult // TODO: Interface and correct implementation
    {
        private readonly ICollection<string> _results = new List<string>();

        public ValidationResult()
        {
        }

        public ValidationResult(ICollection<string> results)
        {
            _results = results;
        }

        public void Populate(string result)
        {
            _results.Add(result);
        }

    }
}