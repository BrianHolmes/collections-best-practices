using System.Collections.Generic;

namespace collections_best_practices
{
    public interface IDataRepository
    {
        IEnumerable<Data> GetListData();
        IEnumerable<Data> GetArrayData();
        IReadOnlyCollection<Data> GetReadonlyListData();
        IReadOnlyCollection<Data> GetReadonlyArrayData();
    }
}
