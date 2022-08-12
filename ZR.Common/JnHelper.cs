﻿using JinianNet.JNTemplate;
using System;
using System.IO;

namespace ZR.Common
{
    public class JnHelper
    {
        /// <summary>
        /// 读取Jn模板
        /// </summary>
        /// <param name="dirPath"></param>
        /// <param name="tplName"></param>
        /// <returns></returns>
        public static ITemplate ReadTemplate(string dirPath, string tplName)
        {
            string path = Environment.CurrentDirectory;
            string fullName = Path.Combine(path, "wwwroot", dirPath, tplName);
            if (File.Exists(fullName))
            {
                return Engine.LoadTemplate(fullName);
            }
            return null;
        }
    }
}
