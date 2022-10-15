using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CourtHouse.Data
{
    public class FaceId
    {
        public FaceId(IWebHostEnvironment hosting)
        {
            Hosting = hosting;
        }
        public IWebHostEnvironment Hosting { get; }
        public Image<Gray, Byte> faceDetectionImage(Image<Bgr, Byte> img)
        {
            var pathCascade = Path.Combine(Hosting.WebRootPath, "haarcascade_frontalface_alt.xml");
            CascadeClassifier cascade = new CascadeClassifier(pathCascade);
            Image<Gray, Byte> grayFaceResult = null;
            Mat grayImage = new Mat();
            CvInvoke.CvtColor(img, grayImage, ColorConversion.Bgr2Gray);
            CvInvoke.EqualizeHist(grayImage, grayImage);
            Rectangle[] faces = cascade.DetectMultiScale(grayImage, 1.1, 3, Size.Empty, Size.Empty);
            if (faces.Length > 0)
            {
                foreach (var face in faces)
                {
                    Image<Bgr, Byte> resultImage = img.Convert<Bgr, Byte>();
                    resultImage.ROI = face;
                    CvInvoke.Rectangle(img, face, new Bgr(Color.Red).MCvScalar, 2);
                    grayFaceResult = resultImage.Convert<Gray, Byte>().Resize(200, 200, Inter.Cubic);
                }
            }
            return grayFaceResult;
        }
        public EigenFaceRecognizer recogntionFaceImageNormal(List<Image<Gray, Byte>> images, string label)
        {
            var path = Path.Combine(Hosting.WebRootPath, "faceData");
            List<Mat> faceDatas = new List<Mat>();
            List<int> PersonsLabes = new List<int>();
            EigenFaceRecognizer eigen = new EigenFaceRecognizer(19, 1.7976931348623157E+308);
            foreach (var img in images)
            {
                Mat m = new Mat();
                img.Resize(200, 200, Inter.Cubic);
                CvInvoke.EqualizeHist(img, m);
                faceDatas.Add(m);
                PersonsLabes.Add(1);
            }
            eigen.Train(faceDatas.ToArray(), PersonsLabes.ToArray());
            eigen.Write(path + @"\" + label);
            return eigen;
        }
        public FisherFaceRecognizer recogntionFaceImageFisher(List<Image<Gray, Byte>> images, string label)
        {
            var path = Path.Combine(Hosting.WebRootPath, "faceData");
            List<Mat> faceDatas = new List<Mat>();
            List<int> PersonsLabes = new List<int>();
            FisherFaceRecognizer Fishereigen = new FisherFaceRecognizer(19, 1.7976931348623157E+308);
            foreach (var img in images)
            {
                Mat m = new Mat();
                img.Resize(200, 200, Inter.Cubic);
                CvInvoke.EqualizeHist(img, m);
                faceDatas.Add(m);
                PersonsLabes.Add(1);
            }
            PersonsLabes[PersonsLabes.Last()] = 2;
            Fishereigen.Train(faceDatas.ToArray(), PersonsLabes.ToArray());
        //    Fishereigen.Write(path + @"\" + label + " Fisher");
            return Fishereigen;
        }
    }
}
