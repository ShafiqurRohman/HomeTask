
namespace XmlValidator.UnitTests
{
    [TestFixture]
    public class XmlValidatorTests
    {
        [Test]
        public void DetermineXml_ValidXml_ReturnTrue()
        {
            // arrange
            string xmlString = "<root><element1></element1><element2></element2></root>";
            //act
            var result = XmlValidatorChecker.DetermineXml(xmlString);
            //assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void DetermineXml_InvalidXml_ReturnFalse()
        {
            // Arrange
            string invalidXml = "<Design><Code>hello world</Code></Design><People>";

            // Act
            bool result = XmlValidatorChecker.DetermineXml(invalidXml);

            // Assert
            Assert.That(result, Is.False);
        }
        [Test]
        public void DetermineXml_NestedValidXml_ReturnTrue()
        {
            // Arrange
            string nestedInvalidXml = "<People><Design><Code>hello world</Code></Design></People>";

            // Act
            bool result = XmlValidatorChecker.DetermineXml(nestedInvalidXml);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void DetermineXml_NestedInvalidXml_ReturnFalse()
        {
            // Arrange
            string nestedInvalidXml = "<People><Design><Code>hello world</People></Code></Design>";

            // Act
            bool result = XmlValidatorChecker.DetermineXml(nestedInvalidXml);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void DetermineXml_AttributeInvalidXml_ReturnFalse()
        {
            // Arrange
            string attributeInvalidXml = "<People age=\"1\">hello world</People>";

            // Act
            bool result = XmlValidatorChecker.DetermineXml(attributeInvalidXml);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void DetermineXml_MalformedXml_ReturnFalse()
        {
            // Arrange
            string malformedXml = "<Design><Code>hello world</Code></Design";

            // Act
            bool result = XmlValidatorChecker.DetermineXml(malformedXml);

            // Assert
            Assert.That(result, Is.False);
        }
    }
}