using System;
using System.IO;
using Godot;
using RulerGame.Core;

namespace RulerGame.Game;

public partial class Global : Node
{
    /// <summary>
    /// 用户文件夹路径
    /// </summary>
    // ReSharper disable once MemberCanBePrivate.Global
    public static string UserFolderPath { get; } = ProjectSettings.GlobalizePath("user://");
    
    /// <summary>
    /// 数据文件夹路径
    /// </summary>
    // ReSharper disable once MemberCanBePrivate.Global
    public static string DataFolderPath { get; } = Path.Combine(UserFolderPath, "data");

    /// <summary>
    /// 临时文件夹路径
    /// </summary>
    // ReSharper disable once MemberCanBePrivate.Global
    public static string TempFolderPath { get; } = Path.Combine(UserFolderPath, "temp");
    
    /// <summary>
    /// 当前版本
    /// </summary>
    // ReSharper disable once MemberCanBePrivate.Global
    public static VersionCode CurrentVersion { get; } = new VersionCode(0,0,1,0, EnumVersionType.Dev);
    
    /// <summary>
    /// 启动事件
    /// </summary>
    public override void _Ready()
    {
        GD.Print($"📁 用户路径：{UserFolderPath}");
        GD.Print($"📁 数据路径：{DataFolderPath}");
        GD.Print($"📁 临时路径：{TempFolderPath}");
        GD.Print($"🚀 当前版本：{CurrentVersion}");
        GD.Print($"🚀 版本名称：{CurrentVersion.Name}");
        GD.Print("🚀 游戏启动成功！请下达指令～");
    }
}