// DropboxService.cs
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

public class DropboxService
{
    private readonly HttpClient httpClient;
    private readonly string accessToken;

    public DropboxService(HttpClient httpClient, string accessToken)
    {
        this.httpClient = httpClient;
        this.accessToken = accessToken;
        this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
    }

    public async Task UploadFile(string filePath, byte[] fileData)
    {
        try
        {
            var content = new ByteArrayContent(fileData);
            var response = await httpClient.PostAsync($"https://content.dropboxapi.com/2/files/upload", content);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            // Handle errors here
            throw ex;
        }
    }
}
