
// using Microsoft.Extensions.Options;
// using Dropbox.Api;
// using Dropbox_file_upload;
// using Microsoft.AspNetCore.Components.Forms;
// using Dropbox.Api.Files;
// using Microsoft.AspNetCore.Components;

// public partial class Upload:ComponentBase
// {
//     public readonly DropboxClient dropboxClient;
//     public readonly DropboxSettings dropboxSettings;

//     public Upload(IOptions<DropboxSettings> dropboxOptions, DropboxClient dropboxClient)
//     {
//         this.dropboxClient = dropboxClient;
//         this.dropboxSettings = dropboxOptions.Value;
//     }

//     public async Task OnFileSelected(InputFileChangeEventArgs e)
//     {
//         var file = e.File;

//         // Upload the file to Dropbox
//         using (var stream = file.OpenReadStream())
//         {
//             var uploadResult = await dropboxClient.Files.UploadAsync(
//                 $"/{file.Name}", WriteMode.Overwrite.Instance, body: stream);
//             // Optionally, you can handle the upload result here
//         }
//     }
//     public void addNumber(){
//         int num = 23;
//         num ++;
//     }
// }