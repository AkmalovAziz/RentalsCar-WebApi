using Microsoft.AspNetCore.Http;
using RentCar.Service.Dtos.Cars;
using RentCar.Service.Dtos.Clients;
using RentCar.Service.Validators.Dtos.Cars;
using RentCar.Service.Validators.Dtos.Clients;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.UnitTest.ValidatorTest.Clients;

public class ClientValidatorTest
{
    [Theory]
    [InlineData("AA")]
    [InlineData("A")]
    [InlineData("electronic products, we sell an electronic products to our clients, we sell an electronic products to our clients")]
    public void ShouldReturnInValidFirstname(string firstname)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.jpg");
        ClientCreateDto dto = new ClientCreateDto()
        {
            FirstName = firstname,
            LastName = "aaaaaaaa",
            PhoneNumber = "+998998545977",
            DriverLicense = "AD123456",
            IsMale = true,
            ImagePath = imageFile,
            Description = "we sell an electronic products to our clients"
        };
        var validator = new ClientCreateValidators();
        var result = validator.Validate(dto);
        Assert.False(result.IsValid);
    }

    [Theory]
    [InlineData("AA")]
    [InlineData("A")]
    [InlineData("electronic products, we sell an electronic products to our clients, we sell an electronic products to our clients")]
    public void ShouldReturnInValidLastname(string lastname)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.jpg");
        ClientCreateDto dto = new ClientCreateDto()
        {
            FirstName = "Aziz",
            LastName = lastname,
            PhoneNumber = "+998998545977",
            DriverLicense = "AD123456",
            IsMale = true,
            ImagePath = imageFile,
            Description = "we sell an electronic products to our clients"
        };
        var validator = new ClientCreateValidators();
        var result = validator.Validate(dto);
        Assert.False(result.IsValid);
    }

    [Theory]
    [InlineData("998998545977")]
    [InlineData("+8998545977")]
    [InlineData("8545977")]
    [InlineData("+99899A8545977")]
    [InlineData("99 854 59 77")]
    [InlineData("998545977")]
    [InlineData("99 854-59-77")]

    public void ShouldReturnInValidPhonenumber(string phonenumber)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.jpg");
        ClientCreateDto dto = new ClientCreateDto()
        {
            FirstName = "Aziz",
            LastName = "Akmalov",
            PhoneNumber = phonenumber,
            DriverLicense = "AD123456",
            IsMale = true,
            ImagePath = imageFile,
            Description = "we sell an electronic products to our clients"
        };
        var validator = new ClientCreateValidators();
        var result = validator.Validate(dto);
        Assert.False(result.IsValid);
    }

    [Theory]
    [InlineData("+998998545977")]

    public void ShouldReturnValidPhonenumber(string phonenumber)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.jpg");
        ClientCreateDto dto = new ClientCreateDto()
        {
            FirstName = "Aziz",
            LastName = "Akmalov",
            PhoneNumber = phonenumber,
            DriverLicense = "AD123456",
            IsMale = true,
            ImagePath = imageFile,
            Description = "we sell an electronic products to our clients"
        };
        var validator = new ClientCreateValidators();
        var result = validator.Validate(dto);
        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData("123456v")]
    [InlineData("A123456V")]
    [InlineData("a123456V")]
    [InlineData("123456aa")]
    [InlineData("aa123456")]
    [InlineData("12345678")]
    [InlineData("12g45_78")]
    [InlineData("AA 123456")]
    public void ShouldReturnInValidDriverlicense(string license)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.jpg");
        ClientCreateDto dto = new ClientCreateDto()
        {
            FirstName = "Aziz",
            LastName = "Akmalov",
            PhoneNumber = "+99899854577",
            DriverLicense = license,
            IsMale = true,
            ImagePath = imageFile,
            Description = "we sell an electronic products to our clients"
        };
        var validator = new ClientCreateValidators();
        var result = validator.Validate(dto);
        Assert.False(result.IsValid);
    }

    [Theory]
    [InlineData("AD123456")]
    
    public void ShouldReturnValidDriverlicense(string license)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.jpg");
        ClientCreateDto dto = new ClientCreateDto()
        {
            FirstName = "Aziz",
            LastName = "Akmalov",
            PhoneNumber = "+998998545977",
            DriverLicense = license,
            IsMale = true,
            ImagePath = imageFile,
            Description = "we sell an electronic products to our clients"
        };
        var validator = new ClientCreateValidators();
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
    public void ShouldReturnWrongImageFilesize(double imageSizeMB)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("we sell an electronic products to our clients");
        long imageSizeInBytes = (long)(imageSizeMB * 1024 * 1024);
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, imageSizeInBytes, "data", "file.png");
        ClientCreateDto clientCreateDto = new ClientCreateDto()
        {
            FirstName = "Aziz",
            LastName = "Akmalov",
            PhoneNumber = "+99899854577",
            DriverLicense = "AA123456",
            IsMale = true,
            ImagePath = imageFile,
            Description = "we sell an electronic products to our clients"
        };
        var validator = new ClientCreateValidators();
        var result = validator.Validate(clientCreateDto);
        Assert.False(result.IsValid);
    }

    [Theory]
    [InlineData(2.95)]
    [InlineData(2.5)]
    [InlineData(1)]
    [InlineData(0.5)]
    [InlineData(0.75)]
    public void ShouldReturnValidImageFilesize(double imageSizeMB)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("we sell an electronic products to our clients");
        long imageSizeInBytes = (long)(imageSizeMB * 1024 * 1024);
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, imageSizeInBytes, "data", "file.png");
        ClientCreateDto dto = new ClientCreateDto()
        {
            FirstName = "Aziz",
            LastName = "Akmalov",
            PhoneNumber = "+998998545977",
            DriverLicense = "AA123456",
            IsMale = false,
            ImagePath = imageFile,
            Description = "we sell an electronic products to our clients"
        };
        var validator = new ClientCreateValidators();
        var result = validator.Validate(dto);
        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData("file.png")]
    [InlineData("file.jpg")]
    [InlineData("file.jpeg")]
    [InlineData("file.bmp")]
    [InlineData("file.svg")]
    public void ShouldReturnCorrectImageFilextension(string imagename)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", imagename);
        ClientCreateDto dto = new ClientCreateDto()
        {
            FirstName = "Aziz",
            LastName = "Akmalov",
            PhoneNumber = "+998998545977",
            DriverLicense = "AA123456",
            IsMale = true,
            ImagePath = imageFile,
            Description = "we sell an electronic products to our clients"
        };
        var validator = new ClientCreateValidators();
        var result = validator.Validate(dto);
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
        ClientCreateDto dto = new ClientCreateDto()
        {
            FirstName = "Aziz",
            LastName = "Akmalov",
            PhoneNumber = "+99899854577",
            DriverLicense = "AA123456",
            IsMale = true,
            ImagePath = imageFile,
            Description = "we sell an electronic products to our clients"
        };
        var validator = new ClientCreateValidators();
        var result = validator.Validate(dto);
        Assert.False(result.IsValid);
    }

    [Fact]
    public void ShouldReturnValid()
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.jpg");
        ClientCreateDto dto = new ClientCreateDto()
        {
            FirstName = "Aziz",
            LastName = "Akmalov",
            PhoneNumber = "+998998545977",
            DriverLicense = "AD123456",
            IsMale = true,
            ImagePath = imageFile,
            Description = "we sell an electronic products to our clients"
        };
        var validator = new ClientCreateValidators();
        var result = validator.Validate(dto);
        Assert.True(result.IsValid);
    }
}
