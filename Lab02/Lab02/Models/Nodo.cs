namespace Lab02.Models
{
    public class Nodo<T>
    {
        internal T value { get; set; }
        internal Nodo<T> next { get; set; }
        
        internal Nodo(T v)
        {
            this.value = v;
            this.next = null;
        }
        internal Nodo()
        {
            this.value = default(T);
            next = null;
        }
    }
}
