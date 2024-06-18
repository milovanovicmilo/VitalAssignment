using Assignment.Application.Common.Interfaces;
using Assignment.Application.TodoItems.Commands.CreateTodoItem;
using Assignment.Application.TodoLists.Commands.CreateTodoList;
using Caliburn.Micro;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Assignment.UI;

public static class DependencyInjection
{
    public static IServiceCollection AddUIServices(this IServiceCollection services)
    {
        return services.AddTransient<IUser, CurrentUser>()
            .AddTransient<IWindowManager, WindowManager>()
            .AddTransient<MainViewModel>()
            .AddTransient<TodoManagmentViewModel>()
            .AddTransient<WeatherForecastViewModel>()
            .AddTransient<IValidator<CreateTodoListCommand>, CreateTodoListCommandValidator>()
            .AddTransient<IValidator<CreateTodoItemCommand>, CreateTodoItemCommandValidator>();
    }
}
