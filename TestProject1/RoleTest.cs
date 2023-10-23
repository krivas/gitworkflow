
using Moq;


namespace TestProject1
{
    public class RolesRepoTest
    {
        private readonly Mock<IRolesRepo> _mockRolesRepo;

        public RolesRepoTest()
        {
            _mockRolesRepo = RolesMockRepo.GetRepository();
        }


       [Test]
        public async Task CreateGetUpdateDeleteRole_Should_Work_Correctly()
        {
            var repository = _mockRolesRepo.Object;
            // Arrange
            var role = new RoleEntity
            {
                Name = "Staff",
                Description = "Default",
            };

            // Create
            int createdId = await repository.CreateAsync(role);
            Assert.AreEqual(2, createdId);

            // Get
            var retrievedRoles = await repository.GetRolesAsync();
            Assert.IsNotEmpty(retrievedRoles);

            var roleAdded = retrievedRoles.FirstOrDefault(x => x.Id == 2);
            Assert.NotNull(roleAdded);

            Assert.AreEqual(roleAdded.Id, 2);
            Assert.AreEqual(roleAdded.Name, role.Name);
            Assert.AreEqual(roleAdded.Description, role.Description);

            var roleUpdate = new RoleEntity
            {
                Id = 2,
                Name = "Trainee",
                Description = "Default reader",
            };

            int updateCount = await repository.UpdateAsync(roleUpdate);
            Assert.AreNotEqual(0, updateCount);

            var retrievedClaimUpdated = await repository.GetRole(2);
            Assert.NotNull(retrievedClaimUpdated);

            Assert.AreEqual(roleUpdate.Name, retrievedClaimUpdated.Name);
            Assert.AreEqual(roleUpdate.Description, retrievedClaimUpdated.Description);

            int affectedRows = await repository.DeleteAsync(2);
            Assert.AreEqual(1, affectedRows);

        }
    }
}
