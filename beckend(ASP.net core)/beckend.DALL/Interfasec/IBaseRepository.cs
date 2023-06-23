
namespace beckend.DALL.Interfasec
{
    public interface IBaseRepository<T>
    {
        /// <summary>
        /// Вернуть все элементы из таблицы
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAll();
        /// <summary>
        /// Возвращает элемент по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetById(int id);
        /// <summary>
        /// Добавить запись в таблицу
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        Task<bool> AddRecord(T record);
        /// <summary>
        /// Изменить запись в таблице
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        Task<bool> UpdateRecordById(int Id);
    }
}
