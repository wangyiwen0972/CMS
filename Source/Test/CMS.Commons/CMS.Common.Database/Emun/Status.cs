using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common.Database.Emun
{
    public enum ContextStatus
    {
        //初始状态
        None,
        //准备同步
        PreSync,
        //同步中
        Syncing,
        //已同步
        Synced
        
    }
    [Flags]
    public enum CommandStatus
    {
        //初始状态
        None = 1,
        //已初始化
        Initialized = 2,
        //执行中
        Executing = 4,
        //回滚中
        Rollbacking = 8,
        //执行完成
        Executed = 16,
        //回滚完成
        Rollbacked = 32
    }
}
