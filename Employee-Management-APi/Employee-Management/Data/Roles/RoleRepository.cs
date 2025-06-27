using Employee_Management.Models.Roles;
using System;

public class RoleRepository : IRoleRepository
{
    private readonly AppDbContext _context;
    public RoleRepository(AppDbContext context)
    {
        _context = context;
    }

    public Role GetById(int roleId)
    {
        return _context.Roles.Find(roleId);
    }
}
