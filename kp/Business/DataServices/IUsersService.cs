using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using kp.Business.Abstraction;
using kp.DataServies.Entities;
using Refit;

namespace kp.Business.DataServices
{
    public interface IUserService
    {
        [Post("")]
        Task<User> Add(User entity);

        [Put("")]
        Task<User> Update(User entity);

        [Delete("")]
        Task Remove(Guid id);

        [Get("")]
        Task<IEnumerable<User>> GetAll();

        [Get("/{id}")]
        Task<User> GetById(Guid id);

        [Post("/{userId}/roles/{roleId}")]
        Task<User> AddRole(Guid userId, Guid roleId);

        [Delete("/{userId}/roles/{roleId}")]
        Task<User> RemoveRole(Guid userId, Guid roleId);
    }
}