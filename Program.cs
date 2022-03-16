using System;
using System.Collections;
using System.Collections.Generic;

UniqueList<string> wordList = new UniqueList<string>();
wordList.Add("bagel");
wordList.Add("bread");
wordList.Add("pita");
wordList.Add("muffin");
wordList.Add("bread");
Console.WriteLine(wordList.Count);
wordList.Remove("pita");
Console.WriteLine(wordList.Contains("bagel"));
Console.WriteLine(wordList.Contains("pita"));
foreach(var item in wordList) {
    Console.WriteLine(item);
}
wordList.Clear();

public class UniqueList<T> : ICollection<T>
{
    List<T> Test = new List<T>();
    public int Count { get; set;}
    public bool IsReadOnly { get; }
    public void Clear() {
        Test.Clear();
        Count = 0;
    }
    public bool Remove(T item) {
        return Test.Remove(item);
        Count--;
    }
    public void CopyTo(T[] array, int arrayIndex) {
        T[] TestArray = Test.ToArray();
        T[] NewArray = new T[TestArray.Length];
        TestArray.CopyTo(NewArray, 0);
    }
    public bool Contains(T item) {
        return Test.Contains(item);
    }
    public void Add(T item) {
        if (Contains(item) == false) {
            Test.Add(item);
            Count++;
        }
    }
    public IEnumerator<T> GetEnumerator() {
        IEnumerator<T> enumerator = Test.GetEnumerator();
        while (enumerator.MoveNext())
          yield return enumerator.Current;
    }
    IEnumerator IEnumerable.GetEnumerator() {
        IEnumerator<T> enumerator = Test.GetEnumerator();
        while (enumerator.MoveNext())
          yield return enumerator.Current;
    }
}