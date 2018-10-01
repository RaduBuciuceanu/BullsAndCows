using Autofac;
using BullsAndCows.Presentation.Console.IoC;

namespace BullsAndCows.Presentation.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new LifetimeScopeBuilder();

            using (ILifetimeScope scope = builder.WithModules().Build())
            {
                var application = scope.Resolve<Application>();
                application.Execute();
            }
        }
    }
}