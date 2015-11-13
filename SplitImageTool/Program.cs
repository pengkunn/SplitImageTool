using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplitImage.Core;

namespace SplitImageTool
{
    class Program
    {
        static void Main(string[] args)
        {
            //SplitImageClass.SplitImageDiretory(@"D:\work\3xrpg\美术\正式资源\特效\new", 4, 4);
            SplitImageClass.SplitImageFile(@"D:\work\3xrpg\美术\正式资源\特效\new\etherBall.png", 8, 4);
        }
    }
}
