using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_NetFramework.Services.IServices
{
    /// <summary>
    /// DriveItem
    /// </summary>
    public interface IDriveItemsService
    {
        Task<DriveItem> DriveItemAsync(string itemID);
    }
}
