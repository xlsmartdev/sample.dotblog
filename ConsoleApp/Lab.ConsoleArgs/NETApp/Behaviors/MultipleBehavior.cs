﻿using System;
using PowerArgs;

namespace NETApp.Behaviors
{
    [ArgExceptionBehavior(ArgExceptionPolicy.StandardExceptionHandling)]
    public class MultipleBehavior
    {
        [HelpHook]
        [ArgShortcut("-?")]
        [ArgDescription("Shows this help")]
        public bool Help { get; set; }

        [ArgActionMethod]
        [ArgDescription("複製")]
        [ArgExample(@"NETApp Copy D:\Source D:\Target *.txt", "省略參數，需按照順序")]
        [ArgExample(@"NETApp Copy /SourceFolder:D:\Source /TargetFolder:D:\Target /SearchPattern:*.txt", "完整參數或是縮寫參數，不需要按照順序")]
        public void Copy(CopyFileRequest args)
        {
            var msg = $"{args.SourceFolder},{args.TargetFolder},{args.SearchPattern}";
            Console.WriteLine(msg);
        }

        [ArgActionMethod]
        [ArgDescription("刪除")]
        [ArgExample(@"NETApp Delete D:\Target *.txt", "省略參數，需按照順序")]
        [ArgExample(@"NETApp Delete /TargetFolder:D:\Target /SearchPattern:*.txt",
                    "完整參數或是縮寫參數，不需要按照順序")]
        public void Delete(DeleteFileRequest args)
        {
            var msg = $"{args.TargetFolder},{args.SearchPattern}";
            Console.WriteLine(msg);
        }
    }
}