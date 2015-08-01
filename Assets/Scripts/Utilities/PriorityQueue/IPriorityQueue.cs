using System.Collections.Generic;

/// <summary>
/// Interface for a generic priority queue.
/// </summary>
/// <typeparam name="TEntry">The type of the entry in the queue.</typeparam>
public interface IPriorityQueue<TEntry>
{
    /// <summary>
    /// Counts the number of entries in the queue.
    /// </summary>
    /// <returns></returns>
    int Count();

    /// <summary>
    /// Determines whether this instance is empty.
    /// </summary>
    /// <returns></returns>
    bool IsEmpty();

    /// <summary>
    /// Peeks the front of the queue, returning the first item contained by order of priority without removing it.
    /// </summary>
    /// <returns></returns>
    TEntry Peek();

    /// <summary>
    /// Enqueues the specified entry with the specified priority.
    /// </summary>
    /// <param name="entry">The entry.</param>
    /// <param name="priority">The priority.</param>
    void Enqueue(TEntry entry, int priority);

    /// <summary>
    /// Returns the first item contained by order of priority and removes it from the queue.
    /// </summary>
    /// <returns></returns>
    TEntry Dequeue();

    /// <summary>
    /// Clears the queue.
    /// </summary>
    void Clear();
}
