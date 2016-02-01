using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Implementation of an ordered priority queue with the use of a SortedDictionary.
/// Lowest priority entries will be at the front of the queue.
/// </summary>
/// <typeparam name="TEntry">The type of the entry.</typeparam>
public class PriorityQueue<TEntry> : IPriorityQueue<TEntry>
{
    #region Private Properties

    private readonly SortedDictionary<int, Queue<TEntry>> storageDictionary;

    #endregion

    #region Constructor

    /// <summary>
    /// Initializes a new instance of the <see cref="PriorityQueue{TEntry}"/> class.
    /// </summary>
    public PriorityQueue()
    {
        storageDictionary = new SortedDictionary<int, Queue<TEntry>>();
    } 

    #endregion

    /// <summary>
    /// Counts the number of entries in the queue.
    /// </summary>
    /// <returns></returns>
    public int Count()
    {
        return storageDictionary.Count;
    }

    /// <summary>
    /// Determines whether this instance is empty.
    /// </summary>
    /// <returns></returns>
    public bool IsEmpty()
    {
        return Count() == 0;
    }

    /// <summary>
    /// Peeks the front of the queue, returning the first item contained by order of priority without removing it.
    /// </summary>
    /// <returns></returns>
    public TEntry Peek()
    {
        if (IsEmpty()) return default(TEntry);

        var storageQueue = storageDictionary.Values.FirstOrDefault();
        return storageQueue != default(Queue<TEntry>) ? storageQueue.Peek() : default(TEntry);
    }

    /// <summary>
    /// Enqueues the specified entry with the specified priority.
    /// </summary>
    /// <param name="entry">The entry.</param>
    /// <param name="priority">The priority.</param>
    public void Enqueue(TEntry entry, int priority)
    {
        if (!storageDictionary.ContainsKey(priority))
        {
            storageDictionary.Add(priority, new Queue<TEntry>());
        }

        storageDictionary[priority].Enqueue(entry);
    }

    /// <summary>
    /// Returns the first item contained by order of priority and removes it from the queue.
    /// </summary>
    /// <returns></returns>
    public TEntry Dequeue()
    {
        if (IsEmpty()) return default(TEntry);

        var storageQueue = storageDictionary.Values.FirstOrDefault();
        return storageQueue != default(Queue<TEntry>) ? storageQueue.Dequeue() : default(TEntry);
    }

    /// <summary>
    /// Clears the queue.
    /// </summary>
    public void Clear()
    {
        storageDictionary.Clear();
    }
}
