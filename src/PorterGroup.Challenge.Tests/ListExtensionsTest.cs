namespace PorterGroup.Challenge.Tests;

public class ListExtensionsTest
{
    [Fact]
    public void RemoveDuplicates_ShouldRemoveDuplicatedItens_WhenAGivenListOfObjectsHasDuplicatedItens()
    {
        // Arrange
        List<int> itens = new() { 56, 57, 60, 54, 57, 60 };
        List<int> expected = new() { 56, 57, 60, 54 };

        // Act
        var result = itens.RemoveDuplicates();

        // Assert
        result.Should().BeEquivalentTo(expected);
    }
}
