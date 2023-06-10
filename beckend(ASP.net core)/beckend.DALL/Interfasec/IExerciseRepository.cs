using beckend.Domain.Models.Exercises;

namespace beckend.DALL.Interfasec
{
    public interface IExerciseRepository
    {
        /// <summary>
        /// Возвращает все упражнения
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Exercise>> GetAll();
        /// <summary>
        /// возвращает упражнение по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Exercise> GetById(int id);
        /// <summary>
        /// Возвращает упражнение по названию
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Exercise> GetById(string id);
        /// <summary>
        /// Возвращает указанное количество упражнений
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        Task<IEnumerable<Exercise>> GetIntlen(int count);
        /// <summary>
        /// Возвращает список упражнений в диапазоне
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        Task<IEnumerable<Exercise>> GetRange(int start,int end);
    }
}
