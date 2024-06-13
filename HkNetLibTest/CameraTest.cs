using HkNetLib.Wrapper;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Threading;

namespace HkNetLibTest
{
    [TestClass]
    public class CameraTest
    {
        [TestMethod]       
        public void TestNVRLogin()
        {
            var camera = new HkCamera();            

            Assert.IsNotNull(camera);
            var result = camera.Login(new CameraLoginInfo()
            {
                IP = "192.168.4.19",
                Port = 8000,
                UserName = "admin",
                Password = "Ancn1111",
            });
            Assert.IsTrue(result);
            //DS-7916N-K41620190601CCRRD25542092WCVU
            var sn = camera.GetSerialNumber();
            Assert.IsNotNull(sn);

            var bOnline = camera.IsOnline();
            Assert.IsTrue(bOnline);
        }
        [TestMethod]
        public void TestCameraLogin()
        {
            var camera = new HkCamera();

            Assert.IsNotNull(camera);
            var result = camera.Login(new CameraLoginInfo()
            {
                IP = "192.168.4.172",
                Port = 8000,
                UserName = "admin",
                Password = "1234qwer",
            });
            Assert.IsTrue(result);
            //iDS-2ZMN2507N20230531AARRAB9360262
            var sn = camera.GetSerialNumber();
            Assert.IsNotNull(sn);

            var bOnline = camera.IsOnline();
            Assert.IsTrue(bOnline);
        }
        [TestMethod]
        public void TestInfraredCameraLogin()
        {
            var camera = new HkCamera();

            Assert.IsNotNull(camera);
            var result = camera.Login(new CameraLoginInfo()
            {
                IP = "192.168.4.120",
                Port = 8000,
                UserName = "admin",
                Password = "1234qwer",
            });
            Assert.IsTrue(result);
            //HM-TD2068TU-25C20231113AACHEA0342503
            var sn = camera.GetSerialNumber();
            Assert.IsNotNull(sn);

            var bOnline = camera.IsOnline();
            Assert.IsTrue(bOnline);
        }
        [TestMethod]
        public void TestMultipleLogin()
        {
            var camera = new HkCamera();

            Assert.IsNotNull(camera);
            var result = camera.Login(new CameraLoginInfo()
            {
                IP = "192.168.4.19",
                Port = 8000,
                UserName = "admin",
                Password = "Ancn1111",
                ChannelNo = 8
            });
            Assert.IsTrue(result);
            for(int i = 0; i < 1000; i++)
            {
                result = camera.Login(new CameraLoginInfo()
                {
                    IP = "192.168.4.19",
                    Port = 8000,
                    UserName = "admin",
                    Password = "Ancn1111",
                    ChannelNo = 8
                });
                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public void MultipleLoginLogout()
        {
            var camera = new HkCamera();

            Assert.IsNotNull(camera);
            var result = camera.Login(new CameraLoginInfo()
            {
                IP = "192.168.4.19",
                Port = 8000,
                UserName = "admin",
                Password = "Ancn1111",
                ChannelNo = 8
            });
            Assert.IsTrue(result);
            for (int i = 0; i < 1000; i++)
            {
                result = camera.Login(new CameraLoginInfo()
                {
                    IP = "192.168.4.19",
                    Port = 8000,
                    UserName = "admin",
                    Password = "Ancn1111",
                    ChannelNo = 8
                });
                var bOnline = camera.IsOnline();
                Assert.IsTrue(bOnline);
                camera.Logout();
                bOnline = camera.IsOnline();
                Assert.IsFalse(bOnline);
            }
        }

        [TestMethod]
        public void TestPtzControl()
        {
            var camera = new HkCamera();
            var result = camera.Login(new CameraLoginInfo()
            {
                IP = "192.168.4.172",
                Port = 8000,
                UserName = "admin",
                Password = "1234qwer",
            });

            camera.StartPTZControl(PtzCommand.PAN_LEFT, 3);
            Thread.Sleep(3000);
            var rtn =camera.StopPTZControl(PtzCommand.PAN_LEFT);
            Assert.IsTrue(rtn);
        }
        [TestMethod]
        public void TestCaptureImage()
        {
            var camera = new HkCamera();
            var result = camera.Login(new CameraLoginInfo()
            {
                IP = "192.168.4.172",
                Port = 8000,
                UserName = "admin",
                Password = "1234qwer",
            });
         ;
            //var rtn = camera.CapturePicture(@"d:\a.jpg");
            var rtn = camera.CapturePicture(@"a.jpg");
            Assert.IsTrue(rtn);
        }



    }
}
