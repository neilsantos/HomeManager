using Dominio.Entidades;

namespace Dominio.Interfaces;
public interface IRepositorio<T> where T : EntidadeBase
{
    IEnumerable<T> Ler();
    T Adicionar(T item);
    void Atualizar(T item);
    void Remover(T item);
    int Count();
}
