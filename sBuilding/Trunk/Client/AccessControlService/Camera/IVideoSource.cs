using System;
using System.Drawing;

namespace AccessControlService.Camera
{
    internal interface IVideoSource : IDisposable
    { 
        /// <summary>
        /// Chụp hình
        /// </summary>
        /// <returns></returns>
        Image TakeSnapshot();
    }
}