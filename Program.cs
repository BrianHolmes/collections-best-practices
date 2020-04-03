using System;
using System.Collections.Generic;
using System.Linq;

namespace collections_best_practices
{
    public class Program
    {
        private static readonly IDataRepository _dataRepository = new DataRepository();

        public static void Main(string[] args)
        {
            GrowableDataExample();
        }

        private static void GrowableDataExample()
        {
            var dataResponse = _dataRepository.GetDataThatWillGrowInSize();
            var dataYouWishToGrow = dataResponse as List<Data> ?? dataResponse.ToList();

            dataYouWishToGrow.Add(new Data("DataThreeGrowing"));
            PrintData(dataYouWishToGrow);
        }

        private static void PrintData(IEnumerable<Data> data)
        {
            foreach (var datum in data)
            {
                Console.WriteLine(datum.Name);
            }
        }
    }

    public class DataRepository : IDataRepository
    {
        public IEnumerable<Data> GetDataThatWillGrowInSize()
        {
            return new List<Data> {new Data("DataOneGrowing"), new Data("DataTwoGrowing")};
        }

        public IEnumerable<Data> GetDataThatWillNotGrowInSize()
        {
            return new[] {new Data("DataOneNotGrowing"), new Data("DataTwoNotGrowing")};
        }
    }

    public interface IDataRepository
    {
        IEnumerable<Data> GetDataThatWillGrowInSize();
        IEnumerable<Data> GetDataThatWillNotGrowInSize();
    }

    public class Data
    {
        public Data(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
