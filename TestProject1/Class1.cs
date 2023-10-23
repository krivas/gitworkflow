using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class RolesMockRepo
    {
        public static Mock<IRolesRepo> GetRepository()
        {
            var roles = GetRoles();

            var mockRepository = new Mock<IRolesRepo>();

            mockRepository.Setup(repo => repo.CreateAsync(It.IsAny<RoleEntity>()))
                .ReturnsAsync((RoleEntity role) =>
                {
                    role.Id = roles.Count + 1;
                    roles.Add(role);
                    return roles.Count;
                });
            mockRepository.Setup(repo => repo.UpdateAsync(It.IsAny<RoleEntity>()))
                .ReturnsAsync((RoleEntity role) =>
                {
                    var existingRole = roles.FirstOrDefault(x => x.Id == role.Id);
                    if (existingRole != null)
                    {
                        existingRole.Name = role.Name;
                        existingRole.Description = role.Description;
                    }
                    return existingRole.Id;
                });
            mockRepository.Setup(repo => repo.GetRole(It.IsAny<int>()))
                .ReturnsAsync((int id) =>
                {
                    var result = roles.FirstOrDefault(x => x.Id == id);
                    return result;
                });
            mockRepository.Setup(repo => repo.DeleteAsync(It.IsAny<int>()))
                .ReturnsAsync((int id) =>
                {
                    var affectedRows = roles.RemoveAll(x => x.Id == id);
                    return affectedRows;
                });
            mockRepository.Setup(repo => repo.GetRolesAsync())
                .ReturnsAsync(() =>
                {
                    return roles.ToList();
                });
            return mockRepository;
        }
        private static List<RoleEntity> GetRoles()
        {
            return new List<RoleEntity>
            {
                new RoleEntity { Id = 1,Name="Admin"}
            };
        }
    }
}
public interface IRolesRepo 
{
    Task<int> DeleteAsync(int id);
    Task<int> CreateAsync(RoleEntity role);
    Task<int> UpdateAsync(RoleEntity role);

    Task<List<RoleEntity>> GetRolesAsync();

    Task<RoleEntity> GetRole(int id);
}
public class RoleEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
