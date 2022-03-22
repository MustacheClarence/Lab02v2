namespace Lab02.Models
{
    public class ListaEnlazada<T>
    {
        int Contador { get; set; }
        bool Vacio { get; set; }
        public Nodo<T> Top { get; set; }
        public Nodo<T> Bot { get; set; }
        public void Update(int pos) { }
        public void Delete(int pos) { }
        public void Add(T item) {
            var nuevoNodo = new Nodo<T>(item);
            if (Contador == 0)
            {
                Top = nuevoNodo;
                Bot = nuevoNodo;
                Contador = 1;
                Vacio = false;
            }
            else
            {
                Bot.next = nuevoNodo;
                Bot = nuevoNodo;
                Contador++;
            }
        }
        public T Get(int pos) {
            throw new NotImplementedException();
        }
    }
}
