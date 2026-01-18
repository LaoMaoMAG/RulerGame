using System.ComponentModel;

namespace RulerGame.Core;

/// <summary>
/// 版本号
/// </summary>
public class VersionCode
{
    /// <summary>
    /// 版本代码
    /// </summary>
    // ReSharper disable once MemberCanBePrivate.Global
    public Version Code { get; }

    /// <summary>
    /// 版本类型
    /// </summary>
    // ReSharper disable once MemberCanBePrivate.Global
    public EnumVersionType Type { get; }

    /// <summary>
    /// 版本名称
    /// </summary>
    // ReSharper disable once MemberCanBePrivate.Global
    public string Name { get; }

    /// <summary>
    /// 创建版本号
    /// </summary>
    /// <param name="major">主版本号</param>
    /// <param name="minor">次版本号</param>
    /// <param name="build">构建号</param>
    /// <param name="revision">修订号</param>
    /// <param name="type">版本类型</param>
    /// <param name="name">版本名称</param>
    public VersionCode(
        int major, int minor, int build, int revision,
        EnumVersionType? type = null, string? name = null
    )
    {
        Code = new Version(major, minor, build, revision);
        Type = type ?? EnumVersionType.None;
        Name = name ?? $"{this} 更新";
    }

    /// <summary>
    /// 转换为字符串
    /// </summary>
    public override string ToString()
    {
        return $"V{Code} {Type}";
    }

    /// <summary>
    /// 是否更新
    /// </summary>
    /// <param name="newVersion">最新版本</param>
    /// <param name="targetType">目标类型</param>
    /// <returns></returns>
    public bool IsUpdate(VersionCode newVersion, EnumVersionType targetType = EnumVersionType.Release)
    {
        if (newVersion.Type != targetType) return false;
        return newVersion.Code > Code;
    }
}

/// <summary>
/// 版本类型枚举
/// </summary>
public enum EnumVersionType
{
    [Description("未知版本")] None,

    [Description("开发版")] Dev,

    [Description("测试版")] Alpha,

    [Description("预览版")] Beta,

    [Description("正式版")] Release
}