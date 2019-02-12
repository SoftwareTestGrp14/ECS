namespace ECS.Refac
{
    public class Application
    {
        public static void Main(string[] args)
        {
            IHeater heater=new Heater();
            ITempSensor tempSensor=new TempSensor();
            var ecs = new ECS(28, tempSensor, heater);

            ecs.Regulate();

            ecs.SetThreshold(20);

            ecs.Regulate();
        }
    }
}
