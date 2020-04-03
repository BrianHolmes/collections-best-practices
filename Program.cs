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
            // IN GENERAL
            //
            // if the collection will grow, use list
            // if it won't, use array
            // or even better use IReadOnlyCollection

            // data you want to be able to modify
            DataToGrow_List_Example();
            DataToGrow_Array_Example();

            // data you don't need to modify
            DataNotToGrow_Example();
            DataNotToGrow_EnumeratedMultipleTimes_Example();

            // even better example of data you don't need to modify
            ReadOnlyData_List_EnumeratedMultipleTimes_Example();
            ReadOnlyData_Array_EnumeratedMultipleTimes_Example();
        }

        private static void DataToGrow_List_Example()
        {
            var dataResponse = _dataRepository.GetListData();
            var dataToGrow = dataResponse as List<Data> ?? dataResponse.ToList();

            // this works because you cast the data to a list
            dataToGrow.Add(new Data("dataThree"));

            PrintData(dataToGrow);
        }

        private static void DataToGrow_Array_Example()
        {
            var dataResponse = _dataRepository.GetArrayData();
            var dataToGrow = dataResponse as List<Data> ?? dataResponse.ToList();

            // this works because you cast the data to a list - even though the data was sourced as an array
            dataToGrow.Add(new Data("dataThree"));

            PrintData(dataToGrow);
        }

        private static void DataNotToGrow_Example()
        {
            var dataResponse = _dataRepository.GetArrayData();

            // no casting needed as you simply pass the interface on to the next function

            PrintData(dataResponse);
        }

        private static void DataNotToGrow_EnumeratedMultipleTimes_Example()
        {
            var dataResponse = _dataRepository.GetArrayData();
            var dataNotToGrow = dataResponse as Data[] ?? dataResponse.ToArray();

            // first enumeration - cast would not be necessary if this was the only operation on the data
            foreach(var datum in dataResponse) { ; }

            // second enumeration - if you hadn't cast the data to array then this would enumerate a second time
            foreach(var datum in dataResponse) { ; }

            // and a third time
            PrintData(dataNotToGrow);
        }

        private static void ReadOnlyData_List_EnumeratedMultipleTimes_Example()
        {
            var listDataResponse = _dataRepository.GetReadonlyListData();

            // can be referenced multiple times without casting since it is of type IReadOnlyCollection
            foreach(var datum in listDataResponse) { ; }
            foreach(var datum in listDataResponse) { ; }

            PrintData(listDataResponse);
        }

        private static void ReadOnlyData_Array_EnumeratedMultipleTimes_Example()
        {
            var arrayDataResponse = _dataRepository.GetReadonlyArrayData();

            // can be referenced multiple times without casting since it is of type IReadOnlyCollection
            // regardless of underlying data type - in this case array data handles exactly the same as list data
            foreach(var datum in arrayDataResponse) { ; }
            foreach(var datum in arrayDataResponse) { ; }

            PrintData(arrayDataResponse);
        }

        private static void PrintData(IEnumerable<Data> data)
        {
            // no casting needed as there is only a single enumeration of elements

            Console.WriteLine();

            foreach (var datum in data)
            {
                Console.WriteLine(datum.Name);
            }
        }
    }
}
