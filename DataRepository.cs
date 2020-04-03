using System.Collections.Generic;

namespace collections_best_practices
{
    public class DataRepository : IDataRepository
    {
        private readonly Data dataOne = new Data(nameof(dataOne));
        private readonly Data dataTwo = new Data(nameof(dataTwo));

        public IEnumerable<Data> GetListData()
        {
            return new List<Data> {dataOne, dataTwo};
        }

        public IEnumerable<Data> GetArrayData()
        {
            return new[] {dataOne, dataTwo};
        }

        public IReadOnlyCollection<Data> GetReadonlyListData()
        {
            return new List<Data> {dataOne, dataTwo};
        }

        public IReadOnlyCollection<Data> GetReadonlyArrayData()
        {
            return new[] {dataOne, dataTwo};
        }
    }
}
