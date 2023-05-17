using Api_parqueadero.Models;
using NPOI.SS.Formula.Functions;

namespace Api_parqueadero.Interface
{
    public interface ICrud<T>
    {
        //controller on secuence crud
        Task Insert(T data);
        Task Update(T data, int Id);
        Task Delete(int Id);
    }
}
