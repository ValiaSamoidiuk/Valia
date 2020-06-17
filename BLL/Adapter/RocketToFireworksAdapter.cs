using BLL.Adapter.Models;
using BLL.Factory.Model;

namespace BLL.Adapter
{
    public class RocketToFireworksAdapter : IFirework
    {
        private readonly IRocket _rocket;

        public RocketToFireworksAdapter(IRocket rocket)
        {
            _rocket = rocket;
        }

        public string DoSomeFun()
        {
            return "U think that firework but it's " + _rocket.Launch();
        }
    }
}