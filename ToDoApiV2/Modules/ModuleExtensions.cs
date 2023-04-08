namespace ToDoApiV2.Modules
{
    /// <summary>
    /// Регистрация всех модулей
    /// </summary>
    public static class ModuleExtensions
    {
        // this could also be added into the DI container
        private static readonly List<IModule> _registeredModules = new List<IModule>();

        /// <summary>
        /// Регистрация сервисов модулей в DI-контейнере
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterModules(this IServiceCollection services)
        {
            var modules = DiscoverModules();
            foreach (var module in modules)
            {
                module.RegisterModule(services);
                _registeredModules.Add(module);
            }

            return services;
        }

        /// <summary>
        /// Регистрация Endpoints модулей
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static WebApplication MapEndpoints(this WebApplication app)
        {
            foreach (var module in _registeredModules)
            {
                module.MapEndpoints(app);
            }
            return app;
        }

        /// <summary>
        /// Поиск модулей в приложении с помощью рефлексии
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<IModule> DiscoverModules()
        {
            return typeof(IModule).Assembly
                .GetTypes()
                .Where(p => p.IsClass && p.IsAssignableTo(typeof(IModule)))
                .Select(Activator.CreateInstance)
                .Cast<IModule>();
        }
    }
}
