namespace BLL.Factory.Model
{
    public class LongRangeRocket : IRocket
    {
        private readonly string _name;
        private readonly int _range;

        public LongRangeRocket(string name, int range)
        {
            _name = name;
            _range = range;
        }

        public string Launch()
        {
            return $"{_name} long range rocket launched and reach target in range up to {_range} km";
        }
    }
}