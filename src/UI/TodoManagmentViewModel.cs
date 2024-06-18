using System.Windows.Input;
using Assignment.Application.TodoItems.Commands.DoneTodoItem;
using Assignment.Application.TodoLists.Queries.GetTodos;
using Assignment.Infrastructure.Cache;
using Caliburn.Micro;
using MediatR;

namespace Assignment.UI;
internal class TodoManagmentViewModel : Screen
{
    private readonly ISender _sender;
    private readonly IWindowManager _windowManager;
    private readonly ICustomCache _customCache;

    private IList<TodoListDto> todoLists;
    public IList<TodoListDto> TodoLists
    {
        get
        {
            return todoLists;
        }
        set
        {
            todoLists = value;
            NotifyOfPropertyChange(() => TodoLists);
        }
    }

    private TodoListDto _selectedTodoList;
    public TodoListDto SelectedTodoList
    {
        get => _selectedTodoList;
        set
        {
            _selectedTodoList = value;
            NotifyOfPropertyChange(() => SelectedTodoList);
        }
    }

    private TodoItemDto _selectedItem;
    public TodoItemDto SelectedItem
    {
        get => _selectedItem;
        set
        {
            _selectedItem = value;
            NotifyOfPropertyChange(() => SelectedItem);

            if (SelectedItem != null)
            {
                _customCache.GetOrCreate(SelectedItem.Id.ToString(), SelectedItem);
            }
        }
    }

    private bool CanAddItems(bool param) => SelectedTodoList != null;

    private bool CanSetItemDone(bool param) => SelectedItem != null && !SelectedItem.Done;

    public ICommand AddTodoListCommand { get; private set; }
    public ICommand AddTodoItemCommand { get; private set; }
    public ICommand DoneTodoItemCommand { get; private set; }

    public TodoManagmentViewModel(ISender sender, IWindowManager windowManager, ICustomCache customCache)
    {
        _sender = sender;
        _windowManager = windowManager;
        _customCache = customCache;
        Initialize();
    }

    private async void Initialize()
    {
        await RefereshTodoLists();

        AddTodoListCommand = new RelayCommand(AddTodoList);
        AddTodoItemCommand = new RelayCommand(AddTodoItem, CanAddItems);
        DoneTodoItemCommand = new RelayCommand(DoneTodoItem, CanSetItemDone);
    }

    private async Task RefereshTodoLists()
    {
        var selectedListId = SelectedTodoList?.Id;

        TodoLists = await _sender.Send(new GetTodosQuery());

        if (selectedListId.HasValue && selectedListId.Value > 0)
        {
            SelectedTodoList = TodoLists.FirstOrDefault(list => list.Id == selectedListId.Value);
        }
    }

    private async void AddTodoList(object obj)
    {
        var todoList = new TodoListViewModel(_sender);
        var dialogResult = await _windowManager.ShowDialogAsync(todoList);
        if(dialogResult.HasValue && dialogResult.Value)
        {
            await RefereshTodoLists();
        }
    }

    private async void AddTodoItem(object obj)
    {
        var todoItem = new TodoItemViewModel(_sender, SelectedTodoList.Id);
        var dialogResult = await _windowManager.ShowDialogAsync(todoItem);
        if(dialogResult.HasValue && dialogResult.Value)
        {
            await RefereshTodoLists();
        }
    }

    private async void DoneTodoItem(object obj)
    {
        await _sender.Send(new DoneTodoItemCommand(SelectedItem.Id));
        _customCache.Set(SelectedItem.Id.ToString(), SelectedItem);
        await RefereshTodoLists();
    }
}
