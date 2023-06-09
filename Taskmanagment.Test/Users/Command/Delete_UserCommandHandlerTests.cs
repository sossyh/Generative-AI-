using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Taskmanagement.Application.Persistence;
using Taskmanagement.Application.Exceptions;
using Taskmanagement.Application.Features.User.CQRS.Commands;
using Taskmanagement.Application.Features.User.CQRS.Handlers;
using Taskmanagement.Application.Profiles;
using Taskmanagement.Tests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace Taskmanagement.Tests.User.Command
{
    public class Delete_UserCommandHandlerTests
    {
        private IMapper _mapper;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private Delete_UserCommandHandler _handler;

        public Delete_UserCommandHandlerTests()
        {
            _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();

            _mapper = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            }).CreateMapper();

            _handler = new Delete_UserCommandHandler(_mockUnitOfWork.Object, _mapper);
        }

        [Fact]
        public async Task DeleteUserValid()
        {
            // Arrange
            var user = new Domain.User
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "johndoe@example.com",
                Password = "password"
            };

            _mockUnitOfWork.Setup(x => x._UserRepository.Get(user.Id)).ReturnsAsync(user);

            // Act
            await _handler.Handle(new Delete_UserCommand() { Id = user.Id }, CancellationToken.None);

            // Assert
            _mockUnitOfWork.Verify(x => x._UserRepository.Delete(user), Times.Once);
            _mockUnitOfWork.Verify(x => x.Save(), Times.Once);
        }

        [Fact]
        public async Task DeleteUserInvalid()
        {
            // Arrange
            _mockUnitOfWork.Setup(x => x._UserRepository.Get(999)).ReturnsAsync((Domain.User)null);

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(() =>
                _handler.Handle(new Delete_UserCommand() { Id = 999 }, CancellationToken.None));
        }
    }
}
