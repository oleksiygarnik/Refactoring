using Refactoring.Complex.Requirements;
using System;
using System.Collections.Generic;

namespace Refactoring.Complex.Builder
{
    public abstract class BaseBuilder<TResult> 
    {
        protected List<IRequirement<TResult>> _requirements;
        protected BaseBuilder()
        {
            _requirements = new List<IRequirement<TResult>>();
        }

        public BaseBuilder<TResult> SetRequirement(IRequirement<TResult> requirement)
        {
            if (requirement is null)
                throw new ArgumentNullException(nameof(requirement));

            _requirements.Add(requirement);

            return this;
        }

        public BaseBuilder<TResult> SetRequirements(IEnumerable<IRequirement<TResult>> requirements)
        {
            if (requirements is null)
                throw new ArgumentNullException(nameof(requirements));

            _requirements.AddRange(requirements);

            return this;
        }

        public abstract ExecutionResult<TResult> Build();
    }
}
