using FluentAssertions;
using NetArchTest.Rules;
using static System.Net.Mime.MediaTypeNames;

namespace HRHiringSystem.Architecture.Tests;

public class CleanArchitectureTests
{
    private const string DomainNamespace = "HRHiringSystem.Domain";
    private const string ApplicationNamespace = "HRHiringSystem.Application";
    private const string InfrastructureNamespace = "HRHiringSystem.Infrastructure";
    private const string PresentationNamespace = "HRHiringSystem.Presentation";
    private const string PersistenceNamespace = "HRHiringSystem.Persistence";
    private const string WebApiNamespace = "HRHiringSystem.WebApi";


    [Fact]
    public void Domain_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        var domainAssembly = typeof(Domain.AssemblyReference).Assembly;
        var otherProjects = new[]
        {
            ApplicationNamespace,
            InfrastructureNamespace,
            PresentationNamespace,
            PersistenceNamespace,
            WebApiNamespace
        };

        //Act
        var testResult = Types
            .InAssembly(domainAssembly)
            .ShouldNot()
            .HaveDependencyOnAll(otherProjects)
            .GetResult();

        //Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Application_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        var applicationAssembly = typeof(Application.AssemblyReference).Assembly;
        var otherProjects = new[]
        {
            InfrastructureNamespace,
            PresentationNamespace,
            PersistenceNamespace,
            WebApiNamespace
        };

        // Act
        var testResult = Types
            .InAssembly(applicationAssembly)
            .ShouldNot()
            .HaveDependencyOnAll(otherProjects)
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Infrastructure_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        var infrastructureAssembly = typeof(Infrastructure.AssemblyReference).Assembly;
        var otherProjects = new[]
        {
            PresentationNamespace,
            PersistenceNamespace,
            WebApiNamespace
        };

        // Act
        var testResult = Types
            .InAssembly(infrastructureAssembly)
            .ShouldNot()
            .HaveDependencyOnAll(otherProjects)
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Presentation_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        var presentationAssembly = typeof(Presentation.AssemblyReference).Assembly;
        var otherProjects = new[]
        {
            InfrastructureNamespace,
            PersistenceNamespace,
            WebApiNamespace
        };

        // Act
        var testResult = Types
            .InAssembly(presentationAssembly)
            .ShouldNot()
            .HaveDependencyOnAll(otherProjects)
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Persistence_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        var persistenceAssembly = typeof(Persistence.AssemblyReference).Assembly;
        var otherProjects = new[]
        {
            InfrastructureNamespace,
            PresentationNamespace,
            WebApiNamespace
        };

        // Act
        var testResult = Types
            .InAssembly(persistenceAssembly)
            .ShouldNot()
            .HaveDependencyOnAll(otherProjects)
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }
}