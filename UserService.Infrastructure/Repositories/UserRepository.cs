using UserService.Application.Common.Interfaces;
using UserService.Domain.Entities.Users;
using UserService.Infrastructure.Common.Persistence;

namespace UserService.Infrastructure.Repositories;

public class UserRepository(UserServiceDbContext context) : Repository<User>(context), IUserRepository;

