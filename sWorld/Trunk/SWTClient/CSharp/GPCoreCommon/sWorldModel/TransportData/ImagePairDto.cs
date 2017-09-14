using CommonHelper.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sWorldModel.TransportData
{
    [DataContract]
    public class ImagePairDto
    {
        #region Private properties

        private byte[] faceImageBytes = null, plateImageBytes = null;
        private Image faceImage = null, plateImage = null;
        private bool isFaceImageChanged = false, isPlateImageChanged = false;

        #endregion

        #region Public properties

        [DataMember]
        public byte[] FaceImageBytes
        {
            get
            {
                return faceImageBytes;
            }
            set
            {
                faceImageBytes = value;
                isFaceImageChanged = true;
            }
        }

        [DataMember]
        public byte[] PlateImageBytes
        {
            get
            {
                return plateImageBytes;
            }
            set
            {
                plateImageBytes = value;
                isPlateImageChanged = true;
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Lấy về hình chụp mặt xe dưới dạng Image
        /// </summary>
        /// <returns></returns>
        public Image GetFaceImage()
        {
            if (faceImageBytes == null)
            {
                return null;
            }
            // Nếu đã convert trước đó thì dùng lại
            if (faceImage == null || isFaceImageChanged)
            {
                faceImage = ImageUtils.ByteArrayToImage(faceImageBytes);
            }
            return faceImage;
        }

        /// <summary>
        /// Lấy về hình chụp biển số xe dưới dạng Image
        /// </summary>
        /// <returns></returns>
        public Image GetPlateImage()
        {
            if (plateImageBytes == null)
            {
                return null;
            }
            // Nếu đã convert trước đó thì dùng lại
            if (plateImage == null || isPlateImageChanged)
            {
                plateImage = ImageUtils.ByteArrayToImage(plateImageBytes);
            }
            return plateImage;
        }

        #endregion
    }
}
