using NUnit.Framework;
using NewtraxChallenge.ViewModels;
using NewtraxChallenge.Models;
using Moq;
using System.Collections.Generic;
using NewtraxChallenge.Services;

namespace NewtraxChallenge.Tests.ViewModels
{
    [TestFixture]
    public class WorkerListViewModelTests
    {
        private WorkerListViewModel _viewModel;
        private Mock<DatabaseAccess> _mockDatabaseAccess;

        [SetUp]
        public void Setup()
        {
            // Initialize the mock database access
            _mockDatabaseAccess = new Mock<DatabaseAccess>();

            // Setup mock behavior to return a list of workers
            List<Worker> workers = new List<Worker>
            {
                new Worker { Id = 1, Name = "Worker 1" },
                new Worker { Id = 2, Name = "Worker 2" },
                new Worker { Id = 3, Name = "Worker 3" }
            };
            _mockDatabaseAccess.Setup(d => d.GetWorkers()).Returns(workers);

            // Create an instance of the view model with the mock database access
            _viewModel = new WorkerListViewModel();
        }

        [Test]
        public void LoadWorkers_ShouldRetrieveWorkersFromDatabase()
        {
            // Act
            _viewModel.LoadWorkers();

            // Assert
            Assert.AreEqual(3, _viewModel.Workers.Count);
            Assert.AreEqual("Worker 1", _viewModel.Workers[0].Name);
            Assert.AreEqual("Worker 2", _viewModel.Workers[1].Name);
            Assert.AreEqual("Worker 3", _viewModel.Workers[2].Name);
        }

        [Test]
        public void RefreshWorkers_ShouldClearAndReloadWorkers()
        {
            // Arrange
            _viewModel.Workers.Add(new Worker { Id = 4, Name = "Worker 4" });

            // Act
            _viewModel.RefreshWorkers();

            // Assert
            Assert.AreEqual(3, _viewModel.Workers.Count);
        }
    }
}
