﻿using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using MudBlazor;
using North.Core.Helpers;
using North.Data.Access;
using North.Events.PasteMultimediaEvent;

namespace North.Pages
{
    partial class UploadTest
    {
        private TestModel Model { get; set; } = new TestModel();

        private async Task Paste(PasteMultimediaEventsArgs args)
        {
            var blobs = args.Blobs;
            if (blobs.Length > 1)
            {
                Console.WriteLine($"[Blob destroy] {blobs[0].Url}");
                Console.WriteLine($"[Blob Alive] {blobs[1].Url}");
                await JS.InvokeVoidAsync("destroy", blobs[0].Url);
            }
        }

        private async Task Upload(InputFileChangeEventArgs args)
        {
            try
            {
                using (var image = args.GetMultipleFiles()[0].OpenReadStream(10 * 1024 * 1024))
                {
                    var blobUrl = await JS.UploadToBlob(image, "image/jpg");
                    //await JS.InvokeVoidAsync("copyTextToClipboard", blobUrl);
                    var res = await JS.CopyToClipboard(blobUrl);
                    _snackbar.Add($"[Upload success] {blobUrl}", Severity.Success);
                }
            }
            catch (Exception e)
            {
                _snackbar.Add($"[Upload Failed] {e.Message}", Severity.Error);
            }
        }
    }


    public class TestModel
    {
        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int Age { get; set; } = 0;
        public bool Male { get; set; } = true;

        public TestModel() { }
        public TestModel(string name, string password)
        {
            Name = name;
            Password = password;
        }
    }
}
