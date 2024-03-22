using ListaBlazorApp.Models;
using System.Collections;

namespace ListaBlazorApp.Services
{
    public class ListaEnlazadaSimple : IEnumerable
    {
        public Nodo PrimerNodo { get; set; }
        public Nodo UltimoNodo { get; set; }

        public ListaEnlazadaSimple()
        {
            PrimerNodo = null;
            UltimoNodo = null;
        }

        public bool ListaVacia()
        {
            return PrimerNodo == null;
        }

        public string AgregarNodoAlFinal(Nodo nuevoNodo)
        {
            if (ListaVacia())
            {
                PrimerNodo = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
            else
            {
                UltimoNodo.Referencia = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }

            return "Se ha agregado el nodo al final";
        }        
        
        public string AgregarNodoAlInicio(Nodo nuevoNodo)
        {
            if (ListaVacia())
            {
                PrimerNodo = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
            else
            {
                nuevoNodo.Referencia = PrimerNodo;
                PrimerNodo = nuevoNodo;

            }

            return "Se ha agregado el nodo al inicio";
        }
        public string AgregarNodoAntesDeX(Nodo nuevoNodo, object datoX)
        {
            if (PrimerNodo == null)
            {
                return "La lista está vacía, no se puede agregar antes de X.";
            }

            if (PrimerNodo.Informacion.Equals(datoX))
            {
                nuevoNodo.Referencia = PrimerNodo;
                PrimerNodo = nuevoNodo;
                return "Se ha agregado el nodo antes de X.";
            }

            Nodo nodoActual = PrimerNodo;
            while (nodoActual.Referencia != null)
            {
                if (nodoActual.Referencia.Informacion.Equals(datoX))
                {
                    nuevoNodo.Referencia = nodoActual.Referencia;
                    nodoActual.Referencia = nuevoNodo;
                    return "Se ha agregado el nodo antes de X.";
                }
                nodoActual = nodoActual.Referencia;
            }

            return "No se encontró el dato X en la lista.";
        }

        public string AgregarNodoDespuesDeX(Nodo nuevoNodo, object datoX)
        {
            Nodo nodoActual = PrimerNodo;
            while (nodoActual != null)
            {
                if (nodoActual.Informacion.Equals(datoX))
                {
                    nuevoNodo.Referencia = nodoActual.Referencia;
                    nodoActual.Referencia = nuevoNodo;
                    if (nodoActual == UltimoNodo)
                        UltimoNodo = nuevoNodo;
                    return "Se ha agregado el nodo después de X.";
                }
                nodoActual = nodoActual.Referencia;
            }

            return "No se encontró el dato X en la lista.";
        }
        public string AgregarNodoEnPosicion(Nodo nuevoNodo, int posicion)
        {
            if (posicion < 0)
                return "La posición debe ser un número positivo.";

            int contador = 0;
            Nodo nodoActual = PrimerNodo;
            Nodo nodoAnterior = null;

            // Recorrer la lista para encontrar la posición deseada
            while (nodoActual != null && contador < posicion-1)
            {
                nodoAnterior = nodoActual;
                nodoActual = nodoActual.Referencia;
                contador++;
            }

            
            if (contador < posicion-1)
                return "La posición especificada está más allá del final de la lista.";

        
            if (nodoAnterior == null) 
            {
                nuevoNodo.Referencia = PrimerNodo;
                PrimerNodo = nuevoNodo;
            }
            else
            {
                nuevoNodo.Referencia = nodoActual;
                nodoAnterior.Referencia = nuevoNodo;
            }

            return "Se ha agregado el nodo en la posición especificada.";
        }
        public string AgregarNodoAntesDePosicion(Nodo nuevoNodo, int posicion)
        {
            if (posicion <= 1) // Si la posición es 1 o menos, se agrega al inicio
            {
                return AgregarNodoAlInicio(nuevoNodo);
            }

            Nodo nodoActual = PrimerNodo;
            int contador = 1;

            while (contador < posicion - 1 && nodoActual != null)
            {
                nodoActual = nodoActual.Referencia;
                contador++;
            }

            if (nodoActual == null)
            {
                return "La posición especificada está más allá del final de la lista.";
            }

            nuevoNodo.Referencia = nodoActual.Referencia;
            nodoActual.Referencia = nuevoNodo;

            return "Se ha agregado el nodo antes de la posición especificada.";
        }
        public string AgregarNodoDespuesDePosicion(Nodo nuevoNodo, int posicion)
        {
            Nodo nodoActual = PrimerNodo;
            int contador = 1;

            while (contador < posicion && nodoActual != null)
            {
                nodoActual = nodoActual.Referencia;
                contador++;
            }

            if (nodoActual == null)
            {
                return "La posición especificada está más allá del final de la lista.";
            }

            nuevoNodo.Referencia = nodoActual.Referencia;
            nodoActual.Referencia = nuevoNodo;

            if (nodoActual == UltimoNodo)
            {
                UltimoNodo = nuevoNodo;
            }

            return "Se ha agregado el nodo después de la posición especificada.";
        }

        public string BuscarElemento(object dato)
        {
            Nodo nodoActual = PrimerNodo;

            while (nodoActual != null)
            {
                if (nodoActual.Informacion.Equals(dato))
                {
                    return $"El elemento {dato} ha sido encontrado en la lista.";
                }
                nodoActual = nodoActual.Referencia;
            }

            return $"El elemento {dato} no ha sido encontrado en la lista.";
        }
        public string RecorridoRecursivo(Nodo nodoActual)
        {
            // Caso base: si el nodo actual es nulo, terminamos la recursión
            if (nodoActual == null)
            {
                return string.Empty;
            }
            else
            {
                // Procesar o mostrar el elemento actual (en este caso, simplemente se devuelve como un string)
                string elementoActual = nodoActual.ToString();

                // Llamar recursivamente al método para el siguiente nodo
                string elementosRestantes = RecorridoRecursivo(nodoActual.Referencia);

                // Concatenar el elemento actual con los elementos restantes y devolverlo
                return elementoActual + " -> " + elementosRestantes;
            }
        }





        public IEnumerator GetEnumerator()
        {
            Nodo nodoAuxiliar = PrimerNodo;

            while (nodoAuxiliar != null)
            {
                yield return nodoAuxiliar;
                nodoAuxiliar = nodoAuxiliar.Referencia;
            }
        }
    }
}
