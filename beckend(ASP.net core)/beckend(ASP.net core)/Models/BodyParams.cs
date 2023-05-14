namespace beckend_ASP.net_core_.Models
{
    /// <summary>
    /// Характеристики тела (вынес отдельно для дальнейшего распишерия и дерганья отлельно)
    /// расширяется
    /// </summary>
    public class BodyParams
    {
        private double height = 0.0;
        private double weight = 0.0;

        public BodyParams(double height, double weight)
        {
            Height = height;
            Weight = weight;
        }

        public double Height { get { return height; } set { height = value; } }
        public double Weight { get { return weight; } set { weight = value; } }

    }
}
