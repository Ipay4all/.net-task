using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VPM.Common
{
    public class AzureBlobHelper
    {

        private static string BlobStorageConnectionString = Common.AppConfiguration.BlobStorageConnectionString;
        private static string BlobstorageContainers = Common.AppConfiguration.BlobstorageContainers;
        static CloudStorageAccount storageAAccountConnection
        {

            get
            {

                string storageconnection = BlobStorageConnectionString;
                return CloudStorageAccount.Parse(storageconnection);
            }
        }

        //Getting Blob Connection string  
        static CloudBlobClient _blobClient
        {
            get
            {
                return storageAAccountConnection.CreateCloudBlobClient();
            }
        }


        static CloudBlobContainer _blobcontainer
        {
            get
            {
                string storagecontainer = BlobstorageContainers;
                return _blobClient.GetContainerReference(storagecontainer);

            }
            set { }
        }

        public AzureBlobHelper()
        {
            _blobcontainer.CreateIfNotExistsAsync();

        }

        public static async Task<string> SaveDataToAzureBlob(byte[] buffer, string filename, string foldername = "", string contenttype = "")
        {
            if (!string.IsNullOrWhiteSpace(foldername))
            {
                _blobcontainer = null;
                var myClient = storageAAccountConnection.CreateCloudBlobClient();
                _blobcontainer = myClient.GetContainerReference(foldername);
                await _blobcontainer.CreateIfNotExistsAsync();
            }
            CloudBlockBlob _blockblob = _blobcontainer.GetBlockBlobReference(filename);
            if (!string.IsNullOrWhiteSpace(contenttype))
                _blockblob.Properties.ContentType = contenttype;
            await _blockblob.UploadFromByteArrayAsync(buffer, 0, buffer.Length);
            return _blockblob.Uri.AbsoluteUri.ToString();
        }
    }
}
