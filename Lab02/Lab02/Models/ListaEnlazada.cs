namespace Lab02.Models
{
    public class ListaEnlazada<T>
    {
        CustomTimer tiempo = new CustomTimer();
        //Varibles
        int Contador { get; set; }
        bool Vacio { get; set; }
        public Nodo<T> Top { get; set; }
        public Nodo<T> Bot { get; set; }

        //Metodos
        public void Update(int pos, T v) 
        {
            tiempo.Start();
            int cont = 0;
            var temp = new Nodo<T>();            
            temp = Top;            
            while (cont < pos)
            {                
                temp = temp.next;
                cont++;
            }
            temp.value = v;
            tiempo.Stop();
        }
        public void Delete(int pos) 
        {
            tiempo.Start();
            int cont = 0;            
            var temp = new Nodo<T>();
            var ant = new Nodo<T>();
            temp = Top;
            ant = null;
            while (cont < pos)
            {
                ant = temp;
                temp = temp.next;
                cont++;
            }
            ant.next = temp.next;
            tiempo.Stop();
        }
        public void Add(T item) {
            tiempo.Start();
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
            tiempo.Stop();
        }
        public T Get(int pos)
        {
            tiempo.Start();
            int cont = 0;
            var temp = new Nodo<T>();
            temp = Top;
            while (cont < pos)
            {
                temp = temp.next;
                cont++;
            }
            tiempo.Stop();
            return temp.value;
        }

    }
}
