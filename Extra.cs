using System;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MCLModder;

namespace MCLModder
{
    public class Extra
    {
        public async Task<PermissionStatus> CheckAndRequestReadPermission()
        {
            PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.StorageRead>();

            if (status == PermissionStatus.Granted)
            {
                return status;
            }
            if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
            {
                // Prompt the user to turn on in settings
                // On iOS once a permission has been denied it may not be requested again from the application
                return status;
            }

            if (Permissions.ShouldShowRationale<Permissions.StorageRead>())
            {
                // Prompt the user with additional information as to why the permission is needed
            }

            status = await Permissions.RequestAsync<Permissions.StorageRead>();

            return status;
        }


        public async Task<PermissionStatus> CheckAndRequestWritePermission()
        {
            PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.StorageWrite>();

            if (status == PermissionStatus.Granted)
            {
                return status;
            }
            if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
            {
                // Prompt the user to turn on in settings
                // On iOS once a permission has been denied it may not be requested again from the application
                return status;
            }

            if (Permissions.ShouldShowRationale<Permissions.StorageWrite>())
            {
                // Prompt the user with additional information as to why the permission is needed
            }

            status = await Permissions.RequestAsync<Permissions.StorageWrite>();

            return status;

        }
    }
}
