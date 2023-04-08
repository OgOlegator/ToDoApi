namespace ToDoApiV2.Modules
{
    public interface IModule
    {
        /// <summary>
        /// Регистрация сервисов в DI-контейнере для модуля
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        IServiceCollection RegisterModule(IServiceCollection builder);

        /// <summary>
        /// Регистрация Endpoints для модуля
        /// </summary>
        /// <param name="endpoints"></param>
        /// <returns></returns>
        IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints);
    }
}
