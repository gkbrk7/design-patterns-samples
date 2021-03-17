using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiton
{
    // Singleton ın tersi yani singleton ın çoğullaştırılmış ve geliştirilmiş versiyonudur. Multiton da ise belli şartlara göre instance lar üretilip ona göre işlemler yapılır. Mesela her bir class a sadece bir instance verilmesi durumu gibi
    class Program
    {
        static void Main(string[] args)
        {
            Camera camera = Camera.GetCamera("NIKON");
            Camera camera1 = Camera.GetCamera("NIKON");
            Camera camera2 = Camera.GetCamera("CANON");
            Camera camera3 = Camera.GetCamera("CANON");

            Console.WriteLine(camera.Id);
            Console.WriteLine(camera1.Id);
            Console.WriteLine(camera2.Id);
            Console.WriteLine(camera3.Id);
        }
    }

    class Camera
    {
        static Dictionary<string, Camera> _cameras = new Dictionary<string, Camera>();
        static object _lock = new object();
        public Guid Id { get; set; }
        private Camera()
        {
            Id = Guid.NewGuid();
        }

        public static Camera GetCamera(string brand)
        {
            lock (_lock)
            {
                if (!_cameras.ContainsKey(brand))
                {
                    _cameras.Add(brand, new Camera());
                }
                return _cameras[brand];
            }
        }
    }
}
