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
    /// 发行平台
    /// </summary>
    // ReSharper disable once MemberCanBePrivate.Global
    public EnumVersionPlatform Platform { get; }

    /// <summary>
    /// 设备类型
    /// </summary>
    // ReSharper disable once MemberCanBePrivate.Global
    public EnumVersionDevice Device { get; }

    /// <summary>
    /// 创建版本号
    /// </summary>
    /// <param name="major">主版本号</param>
    /// <param name="minor">次版本号</param>
    /// <param name="build">构建号</param>
    /// <param name="revision">修订号</param>
    /// <param name="type">版本类型</param>
    /// <param name="platform">发行平台</param>
    /// <param name="device">设备类型</param>
    /// <param name="name">版本名称</param>
    public VersionCode(
        int major, int minor, int build, int revision,
        EnumVersionType type = EnumVersionType.None,
        EnumVersionPlatform platform = EnumVersionPlatform.Official,
        EnumVersionDevice device = EnumVersionDevice.None,
        string? name = null
    )
    {
        Code = new Version(major, minor, build, revision);
        Type = type;
        Platform = platform;
        Device = device;
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
    /// <param name="targetPlatform">目标平台</param>
    /// <param name="targetDevice">目标设备</param>
    /// <returns>如果符合更新返回 true，否则 false</returns>
    // ReSharper disable once MemberCanBePrivate.Global
    public bool IsUpdate(
        VersionCode newVersion,
        EnumVersionType targetType = EnumVersionType.Release,
        EnumVersionPlatform targetPlatform = EnumVersionPlatform.Official,
        EnumVersionDevice targetDevice = EnumVersionDevice.None
    )
    {
        if (newVersion.Type != targetType) return false;
        if (newVersion.Platform != targetPlatform) return false;
        if (newVersion.Device != targetDevice) return false;
        return newVersion.Code > Code;
    }

    /// <summary>
    /// 是否更新
    /// </summary>
    /// <param name="newVersionList">最新版本</param>
    /// <param name="targetType">目标类型</param>
    /// <param name="targetPlatform">目标平台</param>
    /// <param name="targetDevice">目标设备</param>
    /// <returns>返回符合更新条件的版本，如果没有返回空</returns>
    public VersionCode? IsUpdate(
        List<VersionCode> newVersionList,
        EnumVersionType targetType = EnumVersionType.Release,
        EnumVersionPlatform targetPlatform = EnumVersionPlatform.Official,
        EnumVersionDevice targetDevice = EnumVersionDevice.None
    )
    {
        return newVersionList.FirstOrDefault(x =>
            x.IsUpdate(this, targetType, targetPlatform, targetDevice)
        );
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

/// <summary>
/// 版本平台枚举
/// </summary>
public enum EnumVersionPlatform
{
    [Description("官方版")] Official,
    [Description("TapTap")] TapTap,
    [Description("好友快报")] HaoyouKuaibao
}

/// <summary>
/// 设备类型枚举
/// </summary>
public enum EnumVersionDevice
{
    [Description("未知设备")] None,
    [Description("Android")] Android,
    [Description("IOS")] Ios,
    [Description("Windows")] Windows,
    [Description("Linux")] Linux
}