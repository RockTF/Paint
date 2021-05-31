

namespace NewPaitnt.Implementation
{
    public class Service
    {
        private static Service _service;

        private Service()
        {

        }

        public static Service Initialize()
        {
            if (_service == null)
            {
                _service = new Service();
            }
            return _service;
        }

    }
}
