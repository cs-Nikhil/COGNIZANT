namespace DeepSkilling.Module1.DataStructuresAndAlgorithms.Exercise05TaskManagementSystem.Models;

/// <summary>
/// Represents a task in the task management system.
/// </summary>
public class Task
{
    public int TaskId { get; set; }

    public string TaskName { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"ID: {TaskId}, Name: {TaskName}, Status: {Status}";
    }
}
