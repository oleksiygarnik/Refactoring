using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.Complex.Requirements
{
    public interface IRequirement<TValue>
    {
        ErrorInfo Error { get; }
        ExecutionResult IsExecuted(TValue value);
    }
}
