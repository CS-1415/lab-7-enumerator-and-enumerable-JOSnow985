namespace Lab06.Tests;

public class EmptyTests
{
    DoublyLinkedList<int> testList;

    // Initialize an empty list
    [SetUp]
    public void Setup()
    {
        testList = new();
    }

    [Test]
    public void LengthTest() => Assert.That(testList.Length, Is.EqualTo(0));
    [Test]
    public void SingleAddLastTest()
    {
        testList.AddLast(5);
        Assert.Multiple(() =>
        {
            Assert.That(testList.Length, Is.EqualTo(1));
            Assert.That(testList.First, Is.EqualTo(5));
            Assert.That(testList.Last, Is.EqualTo(5));
        });
    }
    [Test]
    public void SingleAddFirstTest()
    {
        testList.AddFirst(9);
        Assert.Multiple(() =>
        {
            Assert.That(testList.Length, Is.EqualTo(1));
            Assert.That(testList.First, Is.EqualTo(9));
            Assert.That(testList.Last, Is.EqualTo(9));
        });
    }
}