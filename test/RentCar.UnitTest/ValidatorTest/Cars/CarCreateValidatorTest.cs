using Microsoft.AspNetCore.Http;
using RentCar.Service.Dtos.Cars;
using RentCar.Service.Validators.Dtos.Cars;
using System.Text;

namespace RentCar.UnitTest.ValidatorTest.Cars;

public class CarCreateValidatorTest
{
    [Theory]
    [InlineData("AA")]
    [InlineData("A")]
    [InlineData("electronic products, we sell an electronic products to our clients, we sell an electronic products to our clients")]
    public void ShouldReturnInValidName(string name)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.jpg");
        CarsCreateDto dto = new CarsCreateDto()
        {
            Name = name,
            Model = "chevrole",
            PriceOfDate = 12,
            Status = Domain.Enums.CarStatus.InGaraj,
            Description = "we sell an electronic products to our clients",
            ImagePath = imageFile
        };
        var validator = new CarCreateValidators();
        var result = validator.Validate(dto);
        Assert.False(result.IsValid);
    }

    [Fact]
    public void ShouldReturnValidName()
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.jpg");
        CarsCreateDto dto = new CarsCreateDto()
        {
            Name = "electronic products",
            Model = "chevrole",
            PriceOfDate = 12,
            Status = Domain.Enums.CarStatus.InGaraj,
            Description = "we sell an electronic products to our clients",
            ImagePath = imageFile
        };
        var validator = new CarCreateValidators();
        var result = validator.Validate(dto);
        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData(3.1)]
    [InlineData(3.01)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(7)]
    public void ShouldReturnWrongImageFileSize(double imageSizeMB)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("we sell an electronic products to our clients");
        long imageSizeInBytes = (long)(imageSizeMB * 1024 * 1024);
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, imageSizeInBytes, "data", "file.png");
        CarsCreateDto CarsCreateDto = new CarsCreateDto()
        {
            Name = "electronic products",
            Model = "chevrole",
            PriceOfDate = 12,
            Status = Domain.Enums.CarStatus.InGaraj,
            Description = "we sell an electronic products to our clients",
            ImagePath = imageFile
        };
        var validator = new CarCreateValidators();
        var result = validator.Validate(CarsCreateDto);
        Assert.False(result.IsValid);
    }

    [Theory]
    [InlineData(2.95)]
    [InlineData(2.5)]
    [InlineData(1)]
    [InlineData(0.5)]
    [InlineData(0.75)]
    public void ShouldReturnValidImageFileSize(double imageSizeMB)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("we sell an electronic products to our clients");
        long imageSizeInBytes = (long)(imageSizeMB * 1024 * 1024);
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, imageSizeInBytes, "data", "file.png");
        CarsCreateDto CarsCreateDto = new CarsCreateDto()
        {
            Name = "electronic products",
            Model = "chevrole",
            PriceOfDate = 12,
            Status = Domain.Enums.CarStatus.InGaraj,
            Description = "we sell an electronic products to our clients",
            ImagePath = imageFile
        };
        var validator = new CarCreateValidators();
        var result = validator.Validate(CarsCreateDto);
        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData("file.png")]
    [InlineData("file.jpg")]
    [InlineData("file.jpeg")]
    [InlineData("file.bmp")]
    [InlineData("file.svg")]
    public void ShouldReturnCorrectImageFileExtension(string imagename)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", imagename);
        CarsCreateDto CarsCreateDto = new CarsCreateDto()
        {
            Name = "electronic products",
            Model = "chevrole",
            PriceOfDate = 12,
            Status = Domain.Enums.CarStatus.InGaraj,
            Description = "we sell an electronic products to our clients",
            ImagePath = imageFile
        };
        var validator = new CarCreateValidators();
        var result = validator.Validate(CarsCreateDto);
        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData("file.zip")]
    [InlineData("file.mp3")]
    [InlineData("file.html")]
    [InlineData("file.gif")]
    [InlineData("file.txt")]
    [InlineData("file.HEIC")]
    [InlineData("file.mp4")]
    [InlineData("file.avi")]
    [InlineData("file.mvk")]
    [InlineData("file.vaw")]
    [InlineData("file.webp")]
    [InlineData("file.pdf")]
    [InlineData("file.doc")]
    [InlineData("file.docx")]
    [InlineData("file.xls")]
    [InlineData("file.exe")]
    [InlineData("file.dll")]
    public void ShouldReturnWrongImageFileExtension(string imagename)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", imagename);
        CarsCreateDto CarsCreateDto = new CarsCreateDto()
        {
            Name = "electronic products",
            Model = "chevrole",
            PriceOfDate = 12,
            Status = Domain.Enums.CarStatus.InGaraj,
            Description = "we sell an electronic products to our clients",
            ImagePath = imageFile
        };
        var validator = new CarCreateValidators();
        var result = validator.Validate(CarsCreateDto);
        Assert.False(result.IsValid);
    }

    [Theory]
    [InlineData("B")]
    [InlineData("BB")]
    [InlineData("Bbvhsbdhjsdbvhbdshbvhdsbvhjdsbjvbdsvjdshjbsdhvbhjdsbvjhdsbjhsdj")]
    public void ShouldReturnWrongModel(string model)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.png");
        CarsCreateDto CarsCreateDto = new CarsCreateDto()
        {
            Name = "electronic products",
            Model = model,
            PriceOfDate = 12,
            Status = Domain.Enums.CarStatus.InGaraj,
            Description = "we sell an electronic products to our clients",
            ImagePath = imageFile
        };
        var validator = new CarCreateValidators();
        var result = validator.Validate(CarsCreateDto);
        Assert.False(result.IsValid);
    }

    [Theory]
    [InlineData("a")]
    [InlineData("aa")]
    [InlineData("avf")]
    [InlineData("avfd")]
    [InlineData("addsa")]
    [InlineData("akhdgh")]
    [InlineData("akshhsh")]
    [InlineData("aksbsbsh")]
    [InlineData("aaaaaaaaa")]
    [InlineData("aaaaaaaaaa")]
    [InlineData("aaaaaaaaaaa")]
    [InlineData("aaaaaaaaaaaa")]
    [InlineData("aaaaaaaaaaaaa")]
    [InlineData("aaaaaaaaaaaaaa")]
    [InlineData("aaaaaaaaaaaaaaa")]
    [InlineData("aaaaaaaaaaaaaaaa")]
    [InlineData("aaaaaaaaaaaaaaaaa")]
    [InlineData("aaaaaaaaaaaaaaaaaa")]
    [InlineData("aaaaaaaaaaaaaaaaaaa")]


    public void ShouldReturnWrongDescription(string description)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.bmp");
        CarsCreateDto CarsCreateDto = new CarsCreateDto()
        {
            Name = "electronic products",
            Model = "Mazda",
            PriceOfDate = 12,
            Status = Domain.Enums.CarStatus.InGaraj,
            Description = description,
            ImagePath = imageFile
        };
        var validator = new CarCreateValidators();
        var result = validator.Validate(CarsCreateDto);
        Assert.False(result.IsValid);
    }
}
