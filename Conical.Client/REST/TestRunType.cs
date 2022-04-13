using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BorsukSoftware.Conical.Client.REST
{
    /// <summary>
    /// Standard implementation of <see cref="ITestRunType"/>
    /// </summary>
    public class TestRunType : ITestRunType
    {
        #region Data Model
        public IApiService ApiService { get; }
        public string Product { get; }
        public string Name { get; }

        public string Description { get; }

        public IReadOnlyList<string> Components { get; private set; }

        #endregion

        public TestRunType(IApiService apiService, string product,
            string name,
            string description,
            IReadOnlyList<string> components)
        {
            if (apiService == null)
                throw new ArgumentNullException(nameof(apiService));

            if (string.IsNullOrEmpty(product))
                throw new ArgumentNullException(nameof(product));

            this.ApiService = apiService;
            this.Product = product;

            this.Name = name;
            this.Description = description;
            this.Components = components;
        }

        #region Components Updating
        public async Task UpdateComponents(System.Collections.Generic.IReadOnlyList<string> components)
        {
            if (components == null)
                components = Array.Empty<string>();

            var newComponentsArray = components.ToArray();
            await this.ApiService.ProductTestRunTypeUpdateComponents(
                this.Product,
                this.Name,
                components.ToArray());

            this.Components = newComponentsArray;
        }

        #endregion

        #region Image Related Functionality

        public async Task SetImage(System.Drawing.Image image)
        {
            if (image == null)
            {
                await this.ApiService.ProductTestRunTypeCustomImageDelete(this.Product, this.Name);
                return;
            }

            var imageBytes = RESTUtils.ImageToByteArray(image, System.Drawing.Imaging.ImageFormat.Png);

            await this.ApiService.ProductTestRunTypeCustomImagePut(
                this.Product,
                this.Name,
                imageBytes,
                "image.png",
                "image/png");
        }

        public async Task<System.Drawing.Image> GetImage()
        {
            var imageDetails = await this.ApiService.ProductTestRunTypeCustomImageDetails(this.Product, this.Name);
            if (imageDetails == null)
                return null;

            using (var imageStream = await this.ApiService.ProductTestRunTypeCustomImageGetStream(this.Product, this.Name))
            {
                var image = System.Drawing.Image.FromStream(imageStream);
                return image;
            }
        }

        #endregion
    }
}
