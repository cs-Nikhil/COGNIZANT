using DeepSkilling.Module1.DataStructuresAndAlgorithms.Exercise05TaskManagementSystem.Models;
using TaskItem = DeepSkilling.Module1.DataStructuresAndAlgorithms.Exercise05TaskManagementSystem.Models.Task;

namespace DeepSkilling.Module1.DataStructuresAndAlgorithms.Exercise05TaskManagementSystem.Services;

/// <summary>
/// Manages tasks using a singly linked list.
/// </summary>
public class TaskLinkedListManager
{
    private TaskNode? _head;

    public void AddTask(TaskItem task)
    {
        ArgumentNullException.ThrowIfNull(task);

        var newNode = new TaskNode(task);
        newNode.Next = _head;
        _head = newNode;
    }

    public TaskItem? SearchTask(int taskId)
    {
        TaskNode? current = _head;

        while (current is not null)
        {
            if (current.Data.TaskId == taskId)
            {
                return current.Data;
            }

            current = current.Next;
        }

        return null;
    }

    public IReadOnlyList<TaskItem> TraverseTasks()
    {
        List<TaskItem> tasks = new();
        TaskNode? current = _head;

        while (current is not null)
        {
            tasks.Add(current.Data);
            current = current.Next;
        }

        return tasks;
    }

    public bool DeleteTask(int taskId)
    {
        if (_head is null)
        {
            return false;
        }

        if (_head.Data.TaskId == taskId)
        {
            _head = _head.Next;
            return true;
        }

        TaskNode current = _head;

        while (current.Next is not null)
        {
            if (current.Next.Data.TaskId == taskId)
            {
                current.Next = current.Next.Next;
                return true;
            }

            current = current.Next;
        }

        return false;
    }

    private sealed class TaskNode
    {
        public TaskNode(TaskItem data)
        {
            Data = data;
        }

        public TaskItem Data { get; }

        public TaskNode? Next { get; set; }
    }
}
