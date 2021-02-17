using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.Simple.Abstract
{
    public interface ICombinationFactory<TCombination, TValue>
    {
        List<TCombination> CreateCombinations(List<TValue> values);
    }
}
