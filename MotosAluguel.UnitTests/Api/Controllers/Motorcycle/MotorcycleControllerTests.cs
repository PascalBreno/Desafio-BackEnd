using AutoFixture.Xunit2;
using Microsoft.AspNetCore.Mvc;
using MotosAluguel.Api.Controllers.MotorCycles;
using MotosAluguel.Application.Commands.Motorcycles;
using MotosAluguel.Application.Commons.Response.Motorcycles;
using MotosAluguel.Application.Interfaces.Orchestrators.Motorcycles;
using MotosAluguel.Domain.Validators.Base;
using NSubstitute;
using Xunit;

namespace MotosAluguel.UnitTests.Api.Controllers.Motorcycle;

public class MotorcycleControllerTests
{
    private readonly IMotorcycleInsertOrchestrator _insertOrchestrator;
    private readonly IMotorcycleDeleteOrchestrator _deleteOrchestrator;
    private readonly IMotorcycleUpdateOrchestrator _updateOrchestrator;

    private readonly MotorCycleController _sut;

    public MotorcycleControllerTests()
    {
        _insertOrchestrator = Substitute.For<IMotorcycleInsertOrchestrator>();
        _deleteOrchestrator = Substitute.For<IMotorcycleDeleteOrchestrator>();
        _updateOrchestrator = Substitute.For<IMotorcycleUpdateOrchestrator>();

        _sut = new MotorCycleController(_insertOrchestrator, _deleteOrchestrator, _updateOrchestrator);
    }

    [Theory]
    [AutoData]
    public async Task InsertMotorCycle_ShouldReturnCreated_WhenSuccess(
        MotorcycleInsertCommand command)
    {
        // Arrange
        var operationResult = OperationResult.Ok();

        _insertOrchestrator.RunAsync(command)
            .Returns(operationResult);

        // Act
        var result = await _sut.InsertMotorCycle(command);

        // Assert
        Assert.IsType<CreatedResult>(result);
        await _insertOrchestrator.Received(1).RunAsync(command);
    }

    [Theory]
    [AutoData]
    public async Task InsertMotorCycle_ShouldReturnBadRequest_WhenFail(
        MotorcycleInsertCommand command)
    {
        // Arrange
        var operationResult = OperationResult.Fail("unit Test");

        _insertOrchestrator.RunAsync(command)
            .Returns(operationResult);

        // Act
        var result = await _sut.InsertMotorCycle(command);

        // Assert
        var objectResult = result as ObjectResult;
        Assert.Equal(400, objectResult?.StatusCode);

        await _insertOrchestrator.Received(1).RunAsync(command);
    }

    [Theory]
    [AutoData]
    public async Task DeleteMotorCycle_ShouldReturnOk_WhenSuccess(string id)
    {
        // Arrange
        var operationResult = OperationResult.Ok();

        _deleteOrchestrator.RunAsync(id).Returns(operationResult);

        // Act
        var result = await _sut.DeleteMotorCycleById(id);

        // Assert
        Assert.IsType<OkResult>(result);
        await _deleteOrchestrator.Received(1).RunAsync(id);
    }

    [Theory]
    [AutoData]
    public async Task DeleteMotorCycle_ShouldReturnBadRequest_WhenFail(string id)
    {
        // Arrange
        var operationResult = OperationResult.Fail("unit Test");

        _deleteOrchestrator.RunAsync(id).Returns(operationResult);

        // Act
        var result = await _sut.DeleteMotorCycleById(id);

        // Assert
        var objectResult = result as ObjectResult;
        Assert.Equal(400, objectResult?.StatusCode);

        await _deleteOrchestrator.Received(1).RunAsync(id);
    }
}
