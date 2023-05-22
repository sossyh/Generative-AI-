using Taskmanagement.Application.Persistence;
using Taskmanagement.Domain;

namespace Taskmanagement.Persistence.Repositories;

public class ChecklistRepository : GenericRepository<Checklist>, ICheckilstRepository
{
    private readonly TaskmanagementDbContext _dbContext;
    public CommentRepository(TaskmanagementDbContext context) : base(context)
    {
        _dbContext = context;
    }
}
