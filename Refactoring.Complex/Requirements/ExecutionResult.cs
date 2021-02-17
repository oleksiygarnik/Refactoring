using System;
using System.Collections.Generic;
using System.Linq;

namespace Refactoring.Complex.Requirements
{
    public class ExecutionResult<TValue> : ExecutionResult
    {
        public TValue Value { get; set; }

        public ExecutionResult(TValue value)
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value));

            Value = value;
        }
    }

    public class ExecutionResult
    {
        public bool Success => !Errors.Any();
        public IList<ErrorInfo> Errors { get; private set; }

        public ExecutionResult()
        {
            Errors = new List<ErrorInfo>();
        }

        public ExecutionResult(ErrorInfo errorInfo)
        {
            Errors = new List<ErrorInfo> { errorInfo };
        }

        public virtual void AddError(ErrorInfo error) 
        {
            if (error is null)
                throw new ArgumentNullException(nameof(error));

            Errors.Add(error);
        }

        public static implicit operator bool(ExecutionResult result) => result.Success;
       
    }
}
