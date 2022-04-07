﻿using Gopher.Models;

namespace Gopher.Services
{
    public interface IProjectService
    {
        Task AddProject(string userID, string title, string description, DateTime date);
        Task<Project?> GetById(int id);
        IEnumerable<Project> GetProjectWithUserId(string id);
        Task UpdateProject(Project project);
        Task Remove(Project project);
    }
}