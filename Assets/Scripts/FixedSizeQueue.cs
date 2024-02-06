using System.Collections;
using System.Collections.Generic;

public class FixedSizeQueue<T> : IEnumerable<T>
{
    private Queue<T> queue;
    private int maxSize;

    public FixedSizeQueue(int maxSize)
    {
        this.maxSize = maxSize;
        queue = new Queue<T>(maxSize);
    }

    public void Enqueue(T item)
    {
        if (queue.Count == maxSize)
        {
            queue.Dequeue(); // Supprime le premier élément si la taille maximale est atteinte
        }
        queue.Enqueue(item); // Ajoute le nouvel élément
    }

    public T Dequeue()
    {
        if (queue.Count > 0)
        {
            return queue.Dequeue();
        }
        else
        {
            throw new System.InvalidOperationException("La queue est vide");
        }
    }

    public int Count
    {
        get { return queue.Count; }
    }

    // Implémentation de GetEnumerator pour permettre les itérations avec foreach
    public IEnumerator<T> GetEnumerator()
    {
        return queue.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
