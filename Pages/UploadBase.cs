using Microsoft.AspNetCore.Components;
using Dropbox.Api;
using Dropbox.Api.Files;
using Microsoft.JSInterop;

namespace Dropbox_file_upload.Pages;

public class UploadBase:ComponentBase
{
    static string token = "sl.Bi3jfA-JsEwnTWy9inm9i7Vcvb2YjfvVlALtq993kBJZg6gcNyag6aUEz4Edr-Asmn79F11QBHIGpQZlucxRUO4FSaQSWU7aYcVb7oQWbfbU_RpzyOsTJsgTgc5DdtteKTqszkmPYRld";
    private string uploadStatus;

        [Inject]
        private IJSRuntime JSRuntime { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        private async Task UploadFile()
        {
            var fileInput = await JSRuntime.InvokeAsync<IJSObjectReference>("document.getElementById", "fileInput");
            var fileList = await fileInput.InvokeAsync<IJSObjectReference>("files");

            if (await fileList.InvokeAsync<bool>("length"))
            {
                var file = await fileList.InvokeAsync<IJSObjectReference>("item", 0);
                var fileName = await file.InvokeAsync<string>("name");
                var fileStream = await file.InvokeAsync<IJSObjectReference>("stream");

                // Convert the fileStream to a byte array to be used in the upload
                var data = await JSRuntime.InvokeAsync<byte[]>("readFile", fileStream);

                // Use the Dropbox API to upload the file
                var dropboxAccessToken = token;
                var dropboxClient = new DropboxClient(dropboxAccessToken);

                var dropboxPath = $"/{fileName}";
                var uploadResult = await dropboxClient.Files.UploadAsync(dropboxPath, WriteMode.Overwrite.Instance, body: new MemoryStream(data));

                if (uploadResult != null)
                {
                    uploadStatus = "File uploaded successfully!";
                }
                else
                {
                    uploadStatus = "File upload failed!";
                }

                // Notify the component to re-render after the upload is complete
                StateHasChanged();
            }
        }
    }
