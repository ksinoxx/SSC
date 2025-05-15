using System.Text.Encodings.Web;
using System.Text.Json;
using QRCoder;
using SixLabors.ImageSharp;


namespace SSC.Services;
    public class QRCodeService
    {
    private readonly JsonSerializerOptions serOptions = new()
    {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        WriteIndented = true
    };

    public Image CreateQRcode()
    {

        var qrGenerator = new QRCodeGenerator();
        var qrCodeData = qrGenerator.CreateQrCode(jsonString, QRCodeGenerator.ECCLevel.L);
        var qrCode = new QRCode(qrCodeData);
        var qrCodeImage = qrCode.GetGraphic(20);

        return qrCodeImage;
    }
}

