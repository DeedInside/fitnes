namespace beckend.Domain.Models.@enum
{
    /// <summary>
    /// прорабатываемые группы мышц
    /// </summary>
    public enum groupMuscle
    {
        legs,
        back,
        hands
    }
    /// <summary>
    /// вид использования упражнения
    /// </summary>
    public enum groupExercises
    {
        /// <summary>
        /// соревновательный
        /// </summary>
        competitive = 1,
        /// <summary>
        /// подготовительный
        /// </summary>
        preparatory = 2,
        /// <summary>
        /// Дополнительный
        /// </summary>
        general = 3
    }
    
}
