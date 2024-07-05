# ![icon](PathEd/app.ico) PathEd

[English](README.md) | 简体中文

通过命令添加或删除 PATH 变量中的路径

- PathEd 除了 .NET Framework 4.0 之外没有任何依赖项，并且可以与任何安装程序一起部署。
- 在设置中编辑 PATH 只需一个 exec 命令，而无需使用专有的 PATH 操作插件等。

## 使用方法

`path.exe [/a] [/A] [/d] [/D] [/v] [/V] [/?] 要添加\或删除的\文件夹路径`

| 参数 | 操作 | 级别 |
| ---- | ---- | ---- |
| `/v` | 查看 | 用户 |
| `/V` | 查看 | 系统 |
| `/a` | 添加 | 用户 |
| `/A` | 添加 | 系统 |
| `/d` | 删除 | 用户 |
| `/D` | 删除 | 系统 |
| `/?` | 帮助 | 　　 |
|  无  | 查看 | 用户 |

## 示例

### 向 Windows PATH 添加一个值

`PathEd.exe /A "C:\example dir\path"`

### 从 Windows PATH 中删除一个值

`PathEd.exe /D "C:\example dir\path"`

### 在 NSIS 安装脚本中的使用

PathEd 在 [RepoZ](https://github.com/awaescher/RepoZ) NSIS 安装脚本中用于向 Windows PATH [添加](https://github.com/awaescher/RepoZ/blob/496d4f7539670112772b81e208c2ce650164e101/_setup/RepoZ.nsi#L59) 和 [删除](https://github.com/awaescher/RepoZ/blob/496d4f7539670112772b81e208c2ce650164e101/_setup/RepoZ.nsi#L92) 应用程序位置。

## 注意事项

PathEd 将:

- 如果值是 PATH 中的新值，则只添加它们。因此可以多次调用它。
- 如果值不是 PATH 的一部分，则忽略删除。因此也可以多次调用它。
- 将值与 PATH 进行比较（无论它是否应该添加或可以删除​​值），不区分大小写。
- 删除值，即使 PATH 在引号中定义它们。

与往常一样，如果值包含空格，则需要为值添加引号（如示例中所示）。否则，Windows 会将它们拆分为多个参数。

## 许可协议

MIT License.

## 其他

有关更多 Windows 命令行用的迷你小工具，请前往: [kagurazakayashi/NyarukoMiniTools](https://github.com/kagurazakayashi/NyarukoMiniTools)
