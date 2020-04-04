# CollectionsBestPractices
Some thoughts on how to best work with collections in C#

## Creating Data
- Create data as `List<T>` only if you need to perform list optimized operations _in the same scope_ (like adding)
- Create data as `T[]` otherwise

## Returning Data
- Return data as `IEnumerable<T>` if the data _will_ or _should_ be modified later
- Return data as `IReadOnlyCollection<T>` if the data _will not_ or _should not_ be modified later

## Referencing and Enumerating
- If referencing `IEnumerable<T>` more than once in the same scope _or_ you need to modify the collection, cast to one of the types below to avoid costly and/or unsafe multiple enumerations
    - `List<T>` if you need list optimized operations (like adding)
    - `T[]` otherwise

## Casting Examples
    IEnumerable<T> data = _source.GetData();

    List<T> enumeratedData = data as List<T> ?? data.ToList();
    T[] enumeratedData = data as T[] ?? data.ToArray();