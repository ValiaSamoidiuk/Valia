using BLL.Factory.Model;

namespace BLL.Factory
{
    public class RocketFactory
    {
        public RocketFactory()
        {

        }

        public IRocket CreateInstance(string name, int shootRange)
        {
            if (shootRange > 0 && shootRange < 1000)
            {
                return new MiddleRangeRocket(name, shootRange);
            }
            else 
            {
                return new LongRangeRocket(name, shootRange);
            }
        }
    }
}