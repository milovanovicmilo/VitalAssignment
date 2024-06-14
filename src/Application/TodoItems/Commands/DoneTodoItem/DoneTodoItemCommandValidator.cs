namespace Assignment.Application.TodoItems.Commands.DoneTodoItem;

public class DoneTodoItemCommandValidator : AbstractValidator<DoneTodoItemCommand>
{
    public DoneTodoItemCommandValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty();
    }
}
